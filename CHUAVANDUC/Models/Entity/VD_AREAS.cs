using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHUAVANDUC.Models.Entity
{
    public class VD_AREAS
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public int Quantity { get; set; }
        public int PersonRegister { get; set; }
        public bool IsActive { get; set; }
        public int zIndex { get; set; }
    }
}