using Dropdownlistmvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dropdownlistmvc.Service
{
    public interface IStudent
    {
        IList<IStudent> GetStudents { get; }
        void Save(Student student);
        void Delete(int? Id);

        Student GetStudent(int? Id);
    }
}