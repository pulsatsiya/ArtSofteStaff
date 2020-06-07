using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtSofteStaff.Models;
using ArtSofteStaff.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtSofteStaff.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        readonly WorkContext db;

        public EmployeesController(WorkContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Worker>>> Get()
        {
            return await db.Workers.ToListAsync();
        }

        [HttpGet("{id}")]

        // GET api/employees/id
        public async Task<ActionResult<Worker>> Get(int id)
        {
            Worker worker = await db.Workers.FirstOrDefaultAsync(x => x.ID == id);
            if (worker == null)
                return NotFound();
            return new ObjectResult(worker);
        }
        // POST api/employees
        
        [HttpPost]
        public async Task<ActionResult<Worker>> Post(Worker worker)
        {
            if (worker == null)
            {
                return BadRequest();
            }

            db.Workers.Add(worker);
            await db.SaveChangesAsync();
            return Ok(worker);
        }

        // PUT api/employees/
        
        [HttpPut]
        public async Task<ActionResult<Worker>> Put(Worker worker)
        {
            if (worker == null)
            {
                return BadRequest();
            }
            if (!db.Workers.Any(x => x.ID== worker.ID))
            {
                return NotFound();
            }

            db.Update(worker);
            await db.SaveChangesAsync();
            return Ok(worker);
        }

        // DELETE api/employees/ip
        [HttpDelete("{id}")]
        public async Task<ActionResult<Worker>> Delete(int id)
        {
            Worker worker = db.Workers.FirstOrDefault(x => x.ID == id);
            if (worker == null)
            {
                return NotFound();
            }
            db.Workers.Remove(worker);
            await db.SaveChangesAsync();
            return Ok(worker);
        }

    }

}

