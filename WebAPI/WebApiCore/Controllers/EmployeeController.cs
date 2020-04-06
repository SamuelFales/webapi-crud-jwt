using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCore.Models;

namespace WebApiCore.Controllers
{
   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeDBContext _context;

        public EmployeeController(EmployeeDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> Get()
        {
            var deps = await _context.Employees.ToListAsync();
            return Ok(deps);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Employees>> Get(long id)
        {
            var dep = await _context.Employees.FindAsync(id);

            if (dep == null)
            {
                return NotFound();
            }

            return Ok(dep);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Employees emp)
        {

            _context.Entry(emp).State = EntityState.Modified;

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
        public async Task<ActionResult<Employees>> Post(Employees emp)
        {
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = emp.Id }, emp);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Employees>> Delete(long id)
        {
            var dep = await _context.Employees.FindAsync(id);
            if (dep == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(dep);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}