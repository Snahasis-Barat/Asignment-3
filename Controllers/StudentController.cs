using Assignment3.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{

    [Route("api/Student")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly StudentDbContext _db;
        public StudentController(StudentDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public ActionResult<Student> CreateStudent([FromBody] Student s)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _db.Students.Add(s);
            _db.SaveChanges();
            return Ok(s);

        }

        [HttpGet]

        public ActionResult<Student> GetStudents()
        {
            
            if(_db.Students.Count()==0)
            { 
                return BadRequest("No records exist"); 
            }
            return Ok(_db.Students);
        }

        [HttpGet("id")]
        public ActionResult<Student> GetStudentById(int id) { 

            var s=_db.Students.FirstOrDefault(x => x.Id == id);
            if(s==null)
            {
                return BadRequest("Invalid id");
            }
            return Ok(s);   
        }

        [HttpPut("id")]
            public ActionResult<Student> UpdateStudent(int id,[FromBody] Student s) {

            Student st = _db.Students.FirstOrDefault(x => x.Id == id);
            if(st==null)
            {
                return BadRequest("Invalid id");
            }
            st.standard=s.standard;
            st.name=s.name;
            st.address=s.address;
            st.age=s.age;
            _db.SaveChanges();
            return Ok(st);
        }

        [HttpPatch("id")]
        public ActionResult<Student> UpdatePartialStudent(int id,JsonPatchDocument<Student> s) {
        
            Student stu=_db.Students.FirstOrDefault(x=>x.Id == id);
            s.ApplyTo(stu,ModelState); 
            _db.SaveChanges();
            return Ok(s);
        
        
        }

        [HttpDelete("id")]
        public ActionResult<Student> DeleteStudent(int id)
        {
            var s= _db.Students.FirstOrDefault(x=>x.Id==id);
            if(s==null)
            {
                return BadRequest("Invalid id");
            }
            _db.Students.Remove(s);
            _db.SaveChanges();
            return Ok(s);
        }
    }
}
