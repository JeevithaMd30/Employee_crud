using CRUD_with_SP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUD_with_SP.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Linq.Expressions;
using NuGet.Protocol.Plugins;
using System.Reflection.Metadata.Ecma335;
using CRUD_with_SP.IServices;
using CRUD_with_SP.Services;


namespace CRUD_with_SP.Controllers
{
    [Route("[controller]/[action]")]
    [Controller]
    public class EmployeeController : Controller
    {
        private readonly string _connectionString = @"server=localhost; database=company;integrated security=true;TrustServerCertificate=true";

        private readonly IEmployeeServices _employeeServices;
        private object _employeeService;
      

        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }


        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            //this method get all employee details
            var employees = _employeeServices.GetAllEmployees();
            return View(employees); 
            
        }

        // add employee
        // [HttpGet]
        public IActionResult AddEmployee()
        {
            //this method shows the adding employee
            return View();
        }

        [HttpPost]
        public  IActionResult AddEmployeeData(EmpModel employee)
        {
            _employeeServices.AddEmployeeData(employee);
            return RedirectToAction("GetAllEmployees", "Employee");
        }


        //[HttpPost("updateEmployee/{id}")]

        [HttpPost]
        public IActionResult UpdateEmployee(EmpModel emp1)
        {
            _employeeServices.UpdateEmployee(emp1);
            return RedirectToAction("GetAllEmployees", "Employee");
        }

        public IActionResult Editpage(int Id) 
        {
            EmpModel emp = new EmpModel();
            emp = _employeeServices.EditPage(Id);

          return View(emp);
        }





        // [HttpDelete("DeleteEmployee/{Id}")]

        public IActionResult DeleteEmployee(int Id)
        {
            try
            {
                _employeeServices.DeleteEmployee(Id);
            }
            catch (Exception ex)
            {

                return BadRequest("emp not found");
            }
            return RedirectToAction("GetAllEmployees", "Employee");
        }


        // getempbyid

        // [HttpGet]
        public IActionResult GetEmpById(int id)
        {
            try
            {
                EmpModel emp = _employeeServices.GetEmpById(id); 
                return View("EditPage", emp); 
            }
            catch (Exception ex)
            {
                return RedirectToAction("GetEmpById", "Employee");
            }
        }


    }

}

























