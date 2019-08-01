using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Student_API.Models;
using Student_API.Services;


namespace Student_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        // GET api/students
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_studentService.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = _studentService.Get(id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Student newstudent)
        {
            Student student;
            try
            {
                student = _studentService.Add(newstudent);
                if (student == null)
                    return BadRequest();
            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError("AddStudent", ex.Message);
                return BadRequest(ModelState);
            }
            return CreatedAtAction("Get", new { Id = newstudent.Id }, newstudent);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student updatedStudent)
        {
            var student = _studentService.Update(updatedStudent);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var currentstudent = _studentService.Get(id);
            if (currentstudent == null)

                return NotFound();
            _studentService.Remove(currentstudent);
            return Ok();
        }
    }
}
