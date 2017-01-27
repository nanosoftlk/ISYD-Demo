using ISayYouDo_Demo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace ISayYouDo_Demo.Controllers
{
    //This controller will capture the smart button press event and
    //alert the use with a sms
    public class ButtonController : ApiController
    {
        private DbModel db = new DbModel();
        //post url
        //http://example.com/api/CaptureButtonPress
        [HttpPost]
        [Route("api/CaptureButtonPress")]
        public async Task<IHttpActionResult> CapturePress(ButtonRequest buttonRequest)
        {
            //along with button press event we will receive a json body which contains which button triggred etc.
            //all the properties is in the "ButtonRequest" class

            //find for any recipe exists for pressed button
            var inputObject = db.InputObjects.Where(i => i.button_serial == buttonRequest.mac).FirstOrDefault();

            //no recipes found so we return 400
            if (inputObject == null)
            {
                return BadRequest();
            }

            //excute the recipe

            //create output json object
            Models.OutputObject outputObject = new Models.OutputObject()
            {
                button_serial = inputObject.button_serial,
            };

            Models.OutRecipe outRecipe = new Models.OutRecipe()
            {
                activeStatus = 1,
                connectToken = null,
                notifyURL = null,
                sessionId = inputObject.sessionId,
                userId = 0,
                outputObject = outputObject

            };

            //TO-DO
            //Automate access token generation process

            using (var client = new HttpClient())
            {
                string path = "https://ideabiz.lk/apicall/isayyoudo/1.0/invokeUserCondition";
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + "Your Access Token");
                StringContent content = new StringContent(JsonConvert.SerializeObject(outRecipe));
                HttpContent httpcontent = content;
                httpcontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //post request
                HttpResponseMessage response = await client.PostAsync(path, content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return Ok();
                }

            }
            return BadRequest();

        }
    }
}
