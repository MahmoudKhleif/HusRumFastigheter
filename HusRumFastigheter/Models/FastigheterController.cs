using System;
using System.ComponentModel.DataAnnotations;

namespace HusRumFastigheter.Models
{
    public class FastigheterController
    {   
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime? DateTime { get; set; }

        [Display(Name = "DoorCode")]
        public int DoorId { get; set; }
        public Door Door { get; set; }
        [Display(Name = "DoorEvent")]
        public int EventId { get; set; }
        public Event Event { get; set; }

        [Required, MaxLength(50)]
        public String PersonTag { get; set; }
        [Display(Name = "FullName")]
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }

        [Display(Name = "Type")]
        public int LocationId { get; set; }
        public Location Location{ get; set; }
       
        [Required, MaxLength(50)]
        public String Description { get; set; }


    }
}
