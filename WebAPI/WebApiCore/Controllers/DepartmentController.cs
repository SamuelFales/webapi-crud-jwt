using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCore.Core.Department.Domain;
using WebApiCore.Core.Department.Service.Interfaces;
using WebApiCore.Models;

namespace WebApiCore.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private EmployeeDBContext _context;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(EmployeeDBContext context, IDepartmentService departmentService)
        {
            _context = context;
            _departmentService = departmentService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentModel>>> Get()
        {
            var deps = await _departmentService.GetAllAsync();
            return Ok(deps);
        }

     
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentModel>> Get(long id)
        {
            var dep = await _departmentService.GetByIdAsync(id);

            if (dep == null)
            {
                return NotFound();
            }

            return Ok(dep);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Departments dep)
        {

            _context.Entry(dep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                NotFound();
            }

            return Ok(); 
        }

        [HttpPost]
        public async Task<ActionResult<Departments>> Post(Departments dep)
        {
            _context.Departments.Add(dep);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = dep.Id }, dep);
        }

       
        [HttpDelete("{id}")]
        public async Task<ActionResult<Departments>> Delete(long id)
        {
            var dep = await _context.Departments.FindAsync(id);
            if (dep == null)
                return NotFound();

            try
            {
                _context.Departments.Remove(dep);
                await _context.SaveChangesAsync();
            }
            catch 
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}