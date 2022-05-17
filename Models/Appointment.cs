using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistToolClient.Models
{
    class Appointment
    {
        public int id { get; set; }
        public bool cancelled { get; set; } = false;
        public string CancelReason { get; set; } = "Sample";
        public DateTime dateTime { get; set; }
        public int mduration { get; set; }
        public string AppReason { get; set; } = "Sample";
        public int patient { get; set; }
    }
}
