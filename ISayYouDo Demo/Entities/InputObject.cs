using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISayYouDo_Demo.Entities
{
    public class InputObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int sessionId { get; set; }
        public string button_serial { get; set; }
        public string button_code { get; set; }
    }
}