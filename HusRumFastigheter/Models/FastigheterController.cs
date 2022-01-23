using System;

namespace HusRumFastigheter.Models
{
    public class FastigheterController
    {
        public int Id { get; set; }

        public DateTime? DateTime { get; set; }

        public string DoorCode { get; set; }

        public String Description { get; set; }
    }
}
