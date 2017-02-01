using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISayYouDo_Demo.Models
{
    //this class properties match to "InputObject" object that forward to our application from ISYD
    public class InputObject
    {
        //you should match below properties with the ui obejects you've created in ISYD
        //we'll assume here we have two text boxes with below names
        public string button_serial { get; set; }
    }

    //
    public class InRecepe
    {
        public string connectToken { get; set; }
        public string notifyURL { get; set; }
        public int sessionId { get; set; }
        public int userId { get; set; }
        public int activeStatus { get; set; }
        public InputObject inputObject { get; set; }
    }
}