using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISayYouDo_Demo.Models
{
    public class OutRecipe
    {
        public string connectToken { get; set; }
        public string notifyURL { get; set; }
        public int sessionId { get; set; }
        public int userId { get; set; }
        public int activeStatus { get; set; }
        public OutputObject outputObject { get; set; }
    }

    public class OutputObject
    {
        public string button_serial { get; set; }
    }

}