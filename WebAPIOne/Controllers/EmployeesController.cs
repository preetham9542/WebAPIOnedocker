using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIOne.Model;

namespace WebAPIOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        static List<Employee> list = new List<Employee>()
        {
            new Employee{ id=1,Fname="Sam",Lname="preeth",Salary =50000},
              new Employee{ id=2,Fname="ram",Lname="reeth",Salary =50000},
                new Employee{ id=3,Fname="rom",Lname="spreeth",Salary =50000},
                  new Employee{ id=4,Fname="Rim",Lname="rath",Salary =50000},
                    new Employee{ id=5,Fname="prim",Lname="mreeth",Salary =50000},
                      new Employee{ id=6,Fname="yam",Lname="sreeeth",Salary =50000},
        };
        [HttpGet(Name ="GetEmployees")]
        public IEnumerable<Employee> Get()
        {
            return list;
        }
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            Employee emp = list.SingleOrDefault(x=>x.id==id); 
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(emp);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<Employee> Delete(int id)
        {
            Employee emp = list.SingleOrDefault(x => x.id == id);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                list.Remove(emp);
                return NoContent();
            }
        }
        [HttpPost]
        public ActionResult<Employee> Post(Employee newEmp)
        {
            list.Add(newEmp);
            return CreatedAtAction(nameof(Get),newEmp);
        }

        [HttpPut ("{id}")]
        public ActionResult<Employee> Put(int id,Employee upEmp)
        {
            Employee existingemp = list.SingleOrDefault(x => x.id == id);
            if (existingemp == null)
            {
                return NotFound();
            }
            else
            {
                existingemp.Fname = upEmp.Fname;
                existingemp.Lname = upEmp.Lname;
                existingemp.Salary = upEmp.Salary;
                return NoContent();
            }
        }
    }
}
