using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistToolClient.Models
{
    class Treatment
    {   public int id { get; set; }
        public int appointment { get; set; }
        public byte[] timage { get; set; }
        public string treatment { get; set; } = "Test";
        public int cost { get; set; }
        public int patient { get; set; }
        public string ListView
        {
            get
            {
                return $"({id}) {cost} {treatment} ";
            }

        }
    }
}
