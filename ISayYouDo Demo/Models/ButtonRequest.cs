using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISayYouDo_Demo.Models
{
    public class ButtonRequest
    {
        public string mac { get; set; }
        public string messagetype { get; set; }
        public string in_device_id { get; set; }
        public string brand { get; set; }
        public string type { get; set; }
        public string user_id { get; set; }
        public string event_name { get; set; }
    }
}

//JSON Object
//{
//	"mac": "DB224",
//	"messagetype": "EVENT",
//	"in_device_id": "111151",
//	"brand": "UOM",
//	"type": "BUTTON_V2",
//	"user_id": "55915",
//	"event_name": "PRESSED"
//}