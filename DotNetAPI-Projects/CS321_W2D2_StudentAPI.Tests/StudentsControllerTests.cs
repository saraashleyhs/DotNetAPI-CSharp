using System;
using Xunit;
using Student_API.Controllers;
using Student_API.Services;
using Student_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Student_API.Tests
{
    public class StudentsControllerTests
    {
        [Fact]
        public void Post_ShouldReturnBadRequestWhenBirthDateIsInTheFuture()
        {
            // Ensure that Post() returns BadRequest status code if
            // the given birthdate is in the future

            // act - call Post() with a student with a bad birthdate
            var result = TryPost(new Student
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(2999, 1, 1), // in the future
                Email = "test@test.com",
                Phone = "555-555-5555"
            });

            // assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Post_ShouldReturnBadRequestWhenBirthDateIsTooEarly()
        {
            // Ensure that Post() returns BadRequest status code if
            // the given birthdate is in the future

            // act - call Post() with a student with a bad birthdate
            var result = TryPost(new Student
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(1899, 1, 1), // too old
                Email = "test@test.com",
                Phone = "555-555-5555"
            });

            // assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Post_ShouldReturnBadRequestWhenEmailIsInvalid()
        {
            // Ensure that Post() returns BadRequest status code if
            // the given email is invalid

            // act - call Post() with a student with a bad email
            var result = TryPost(new Student
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(1899, 1, 1),
                Email = "a.bad.email", // bad email
                Phone = "555-555-5555"
            });

            // assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Post_ShouldReturnBadRequestWhenPhoneIsInvalid()
        {
            // Ensure that Post() returns BadRequest status code if
            // the given email is invalid

            // act - call Post() with a student with a bad phone
            var result = TryPost(new Student
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(1899, 1, 1),
                Email = "test@test.com",
                Phone = "5555-5555-5555" // bad phone
            });

            // assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Post_ShouldReturnBadRequestWhenFirstNameIsMissing()
        {
            // Ensure that Post() returns BadRequest status code if
            // the given email is invalid

            // act - call Post() with a student with a bad phone
            var result = TryPost(new Student
            {
                // FirstName = "John", // missing
                LastName = "Doe", 
                BirthDate = new DateTime(1899, 1, 1),
                Email = "test@test.com",
                Phone = "5555-5555-5555" // bad phone
            });

            // assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Post_ShouldReturnBadRequestWhenLastNameIsMissing()
        {
            // Ensure that Post() returns BadRequest status code if
            // the given email is invalid

            // act - call Post() with a student with a bad phone
            var result = TryPost(new Student
            {
                FirstName = "John",
                // LastName = "Doe", // missing
                BirthDate = new DateTime(1899, 1, 1),
                Email = "test@test.com",
                Phone = "5555-5555-5555" // bad phone
            });

            // assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Post_ShouldReturnOkWhenStudentIsValid()
        {
            // Ensure that Post() returns Created status code if
            // the given student object is valid

            var result = TryPost(new Student
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(2009, 1, 1),
                Email = "test@test.com",
                Phone = "555-555-5555"
            });

            // assert
            Assert.IsType<CreatedAtActionResult>(result);
        }

        public IActionResult TryPost(Student student)
        {
            // arrange - create a new controller
            var controller = new StudentsController(new StudentService());

            // act - call Post() with given student 
            return controller.Post(student);
        }
    }
}
