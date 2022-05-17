using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistToolClient.Models
{
    class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string email { get; set; }
        public string telnum { get; set; }
        public string nation { get; set; }
        public string dob { get; set; }
        public string bloodtype { get; set; }
        public string address { get; set; }
    }

}
