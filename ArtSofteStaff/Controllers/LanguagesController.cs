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
    public class LanguagesController : ControllerBase
    {
        readonly WorkContext db;

        public LanguagesController(WorkContext context)
        {
            db = context;
        }
        // GET api/languages/

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Language>>> Get()
        {
            return await db.Languages.ToListAsync();
        }
        [HttpGet("{id}")]

        
        public async Task<ActionResult<Language>> Get(int id)
        {
            Language language = await db.Languages.FirstOrDefaultAsync(x => x.ID == id);
            if (language == null)
                return NotFound();
            return new ObjectResult(language);
        }

   

        [HttpPost]
        public async Task<ActionResult<Language>> Post(Language language)
        {
            if (language == null)
            {
                return BadRequest();
            }

            db.Languages.Add(language);
            await db.SaveChangesAsync();
            return Ok(language);
        }

     

        [HttpPut]
        public async Task<ActionResult<Language>> Put(Language language)
        {
            if (language == null)
            {
                return BadRequest();
            }
            if (!db.Languages.Any(x => x.ID == language.ID))
            {
                return NotFound();
            }

            db.Update(language);
            await db.SaveChangesAsync();
            return Ok(language);
        }

      
        [HttpDelete("{id}")]
        public async Task<ActionResult<Language>> Delete(int id)
        {
            Language language = db.Languages.FirstOrDefault(x => x.ID == id);
            if (language == null)
            {
                return NotFound();
            }
            db.Languages.Remove(language);
            await db.SaveChangesAsync();
            return Ok(language);
        }
    }
}
