using Dropdownlistmvc.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dropdownlistmvc.Data;

namespace Dropdownlistmvc.Repository
{
    public class StudentRepository : IDepartment
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Department> GetDepartments
        {
            get
            {

                return context.Departments;

            }
        }
    }
}