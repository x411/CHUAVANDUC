using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHUAVANDUC.Models.Entity
{
    public class VD_COURSE_TYPE
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public bool IsActive { get; set; }
        public int zIndex { get; set; }
    }

    public class VD_COURSE
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public int CourseType { get; set; }
        public string CourseTypeName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool IsActive { get; set; }
        public int zIndex { get; set; }
    }
}