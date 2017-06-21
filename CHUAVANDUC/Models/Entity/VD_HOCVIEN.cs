using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHUAVANDUC.Models.Entity
{
    public class VD_HOCVIEN
    {
        public long ID { get; set; }
        public string FullName { get; set; }
        public string CMND { get; set; }
        public string PhapDanh { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Address { get; set; }
        public int zIndex { get; set; }
        public long AreasID { get; set; }
        public string AreasName { get; set; }
        public long CourseID { get; set; }
        public string CourseName { get; set; }
        public string UserTypeID { get; set; }
        public string UserTypeName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsApproval { get; set; }
    }
}