using System;
using System.Collections.Generic;
using System.Linq;
using Student_API.Models;

namespace Student_API.Services
{
    public class StudentService : IStudentService
    {
        private List<Student> _students = new List<Student>()
        {
            new Student
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(2010, 1, 1),
                Email = "john.doe@test.com",
                Phone = "555.555.5555"
            },
            new Student
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                BirthDate = new DateTime(2012, 1, 1),
                Email = "jane.smith@test.com",
                Phone = "555.555.5555"
            }
        };
        // keep track of next id number
        private int _nextId = 3;

        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        public Student Get(int Id)
        {
            Student currentStudent = _students.FirstOrDefault(s => s.Id == Id);
            return currentStudent;
        }

        public Student Add(Student newStudent)
        {
            ValidateBirthDate(newStudent);
            newStudent.Id = _nextId++;
            _students.Add(newStudent);
            return newStudent;
        }

        public void ValidateBirthDate(Student student)
        {
            if (student.BirthDate > DateTime.Now)
            {
                throw new ApplicationException("BirthDate cannot be in the future.");
            }
            if (DateTime.Today.Year - student.BirthDate.Year > 18)
            {
                throw new ApplicationException("You're too old to be a student!");
            }
        }

        public Student Update(Student updatedstudent)
        {
            Student currentStudent = _students.FirstOrDefault(s => s.Id == updatedstudent.Id);
            if (currentStudent == null)
                return null;
            currentStudent.FirstName = updatedstudent.FirstName;
            currentStudent.LastName = updatedstudent.LastName;
            currentStudent.BirthDate = updatedstudent.BirthDate;
            currentStudent.Email = updatedstudent.Email;
            currentStudent.Phone = updatedstudent.Phone;
            return currentStudent;
        }

        public void Remove(Student student)
        {
            Student currentStudent = _students.FirstOrDefault(s => s.Id == student.Id);
            if (currentStudent != null)
                _students.Remove(student);
            else
            {
                throw new ApplicationException("Student not found");
            }

        }
    }
}
