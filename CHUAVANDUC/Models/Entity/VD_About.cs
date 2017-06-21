﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHUAVANDUC.Models.Entity
{
    public class VD_About
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}