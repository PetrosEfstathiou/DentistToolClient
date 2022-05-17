﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistToolClient.Models
{
    class Xray
    {
        public int id { get; set; }
        public int patient { get; set; }
        public string xrname { get; set; }
        public byte[] xrimage { get; set; }
        public DateTime xrcreated { get; set; }
    }
}
