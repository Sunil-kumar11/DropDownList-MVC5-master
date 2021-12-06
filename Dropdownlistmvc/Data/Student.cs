using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dropdownlistmvc.Data
{
    public class Student
    {
        public int  Id { get; set; }

        [Required]
        [DisplayName("StudentName")]
        public string StudentName { get; set; }

        [Required]
        [DisplayName("Roll_No")]
        public int Roll_NO { get; set; }

        [Required]
        [DisplayName("Gender")]
        public string Gender { get; set; }

        [Required]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        [Required]
        //TO get Name Details
        public virtual Department Departments { get; set; }
        //To use it with DropDownList Fill
        public virtual IEnumerable<Department> DepartmentsEnum { get; set; }
    }
}