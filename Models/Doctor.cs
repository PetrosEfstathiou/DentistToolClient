using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistToolClient.Models
{
    class Doctor
    {
        public int Id { get; set; }
        public string specialty { get; set; } = "Test";
        public string Name { get; set; } = "Test";
        public string Surname { get; set; } = "Test";
        public string email { get; set; } = "Test";
        public string telnum { get; set; } = "Test";
        public string address { get; set; } = "Test";
    }
}
