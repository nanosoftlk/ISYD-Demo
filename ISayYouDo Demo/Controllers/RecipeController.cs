using ISayYouDo_Demo.Entities;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ISayYouDo_Demo.Controllers
{
    //this is the contoller which handles the creation and deletion of recepes
    public class RecipesController : ApiController
    {
        private DbModel db = new DbModel();
        //http://example.com/api/Recepes
        [Route("api/Recipe")]
        [ResponseType(typeof(Recepe))]
        public async Task<IHttpActionResult> PostRecipe(Models.InRecepe recepe)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(recepe));
            
            //since we use the same url end point for recepe creation and deletion we should check the activeStatus
            //if activeStatus = 200 we save recepe details in our database and respond with required json body back to ISYD
            if (recepe.activeStatus == 200)
            {
                // save the recepe
                var rece_input = new InputObject();

                rece_input.button_serial = recepe.inputObject.button_serial;
                rece_input.sessionId = recepe.sessionId;

                var rece = new Recepe();
                rece.activeStatus = recepe.activeStatus;
                rece.connectToken = recepe.connectToken;
                rece.notifyURL = recepe.notifyURL;
                rece.sessionId = recepe.sessionId;
                rece.userId = recepe.userId;
                rece.inputObject = rece_input;

                db.Recipes.Add(rece);
                await db.SaveChangesAsync();

                //set the active status back
                recepe.activeStatus = 1;

                return Ok(recepe);
            }

            //if its a delete request
            if (recepe.activeStatus == 403)
            {
                Recepe re = await db.Recipes.FindAsync(recepe.sessionId);
                if (re == null)
                {
                    return NotFound();
                }
                InputObject io = await db.InputObjects.FindAsync(recepe.sessionId);
                if (io != null)
                {
                    db.InputObjects.Remove(io);
                }

                db.Recipes.Remove(re);
                await db.SaveChangesAsync();

                recepe.activeStatus = 404;
                return Ok(recepe);
            }

            return BadRequest();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
