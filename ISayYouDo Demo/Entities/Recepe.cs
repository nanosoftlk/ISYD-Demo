using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ISayYouDo_Demo.Entities
{
    public class Recepe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int sessionId { get; set; }
        public string connectToken { get; set; }
        public string notifyURL { get; set; }
        public int userId { get; set; }
        public int activeStatus { get; set; }
        public int inputObjectId { get; set; }
        [ForeignKey("inputObjectId")]
        public virtual InputObject inputObject { get; set; }
    }
}