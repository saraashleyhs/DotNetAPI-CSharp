using System;
using System.Collections;
using System.Collections.Generic;
using Student_API.Models;

namespace Student_API.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAll();
        Student Get(int id);
        Student Add(Student newStudent);
        Student Update(Student newStudent);
        void Remove(Student student);
    }
}
