using WSD_Pract1.Models;

namespace WSD_Pract1.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private static readonly List<Course> Courses =
    [
        new Course
        {
            Id = 1,
            Name = "Web Services",
            Teacher = "Teacher 1",
            Credits = 5,
            Department = "Software Engineering",
            Semester = 5
        },
        new Course
        {
            Id = 2,
            Name = "Databases",
            Teacher = "Teacher 2",
            Credits = 4,
            Department = "Information Systems",
            Semester = 4
        }
    ];

    [HttpGet]
    public ActionResult<List<Course>> GetAll()
    {
        return Ok(Courses);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Course> GetById(int id)
    {
        var course = Courses.FirstOrDefault(course => course.Id == id);

        if (course == null)
        {
            return NotFound();
        }

        return Ok(course);
    }

    [HttpPost]
    public ActionResult<Course> Create(Course course)
    {
        course.Id = Courses.Count == 0
            ? 1
            : Courses.Max(item => item.Id) + 1;

        Courses.Add(course);

        return CreatedAtAction(
            nameof(GetById),
            new { id = course.Id },
            course
        );
    }
}