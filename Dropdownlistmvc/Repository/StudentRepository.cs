using Dropdownlistmvc.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dropdownlistmvc.Data;

namespace Dropdownlistmvc.Repository
{
    public class StudentRepository : IStudent
    {
        EFDbContext context = new EFDbContext();
        public IList<Student> GetStudents
        {
            get
            {
                return context.Students.ToList<Student>();
             }
        }

        public void Delete(int? Id)
        {
            Student std = context.Students.Find(Id);
            if(std != null)
            {
                context.Students.Remove(std);
                context.SaveChanges();
            }

        }

        public Student GetStudent(int? Id)
        {
            return context.Students.Find(Id);
        }

        public void Save(Student student)
        {
            if (student.Id == 0)
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
            else
            {
                Student dbEntry = context.Students.Find(student.Id);
                dbEntry.Id = student.Id;
                dbEntry.StudentName = student.StudentName;
                dbEntry.DepartmentId = student.DepartmentId;
                dbEntry.Roll_NO = student.Roll_NO;
                context.SaveChanges();
            }
        }
    }
}