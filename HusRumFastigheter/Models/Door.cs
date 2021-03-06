using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HusRumFastigheter.Models
{
    public class Door
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required , MaxLength(15)]
        public string DoorCode { get; set; }
    }
}
