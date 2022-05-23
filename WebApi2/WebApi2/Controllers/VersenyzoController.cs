using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApi2.Models;

namespace WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersenyzoController : ControllerBase
    {
        [HttpGet]
        [Route("GetVersenyzokSzama")]

        public IActionResult GetVersenyzokSzama()
        {
            using (var context = new versenyzesContext())
            {
                try
                {
                    return StatusCode(200, context.Versenyzos.Count());
                }
                catch(Exception e)
                {
                    return StatusCode(400, "Hiba: " + e.Message);
                }
            }
        }

        [HttpGet]
        [Route("GetVersenyzokById")]

        public IActionResult GetVersenyzokById(int id)
        {
            using(var context = new versenyzesContext())
            {
                try
                {
                    return StatusCode(200, context.Versenyzos.Include(x => x.Versenyszamoks).Include(x => x.Versenyzoorszags).FirstOrDefault(x => x.VersenyzoId == id));
                }
                catch(Exception e)
                {
                    return StatusCode(400, e.Message);
                }
            }
        }

        [HttpPost]
        [Route("PostVersenyzo")]

        public IActionResult Post(Versenyzo versenyzo, string uid)
        {
            if(WebApi2.Program.UID == uid)
            {
                using (var context = new versenyzesContext())
                {
                    try
                    {
                        context.Add(versenyzo);
                        context.SaveChanges();

                        return StatusCode(201, "Sikeres versenyzo hozzáadás!");
                    }
                    catch (Exception e)
                    {
                        return StatusCode(401, e.Message);
                    }
                }
            }
            else
            {
                return BadRequest("Nincs jogosultságod!");
            }
        }

        [HttpPut]
        [Route("PutVersenyzo")]

        public IActionResult Put(Versenyzo versenyezo, string uid)
        {
            if(WebApi2.Program.UID == uid)
            {
                using(var context = new versenyzesContext())
                {
                    try
                    {
                        context.Versenyzos.Update(versenyezo);
                        context.SaveChanges();

                        return StatusCode(200, "Sikeresen frissítve");
                    }
                    catch(Exception e)
                    {
                        return StatusCode(401, e.Message);
                    }
                }
            }
            else
            {
                return BadRequest("Nincs jogosultságod!");
            }
        }

        [HttpDelete]
        [Route("DeleteVersenyzo")]

        public IActionResult Delete(int id, string uid)
        {
            if(WebApi2.Program.UID == uid)
            {
                using(var context = new versenyzesContext())
                {
                    try
                    {
                        Versenyzo versenyzo = new Versenyzo();
                        versenyzo.VersenyzoId = id;
                        context.Versenyzos.Remove(versenyzo);
                        context.SaveChanges();

                        //return StatusCode(204, "Sikeres törlés!adsadsadsadsasdasdasdasdasawdeadsdasd");
                        return StatusCode(200, "Sikeres törlés!adsadsadsadsasdasdasdasdasawdeadsdasd");
                    }
                    catch(Exception e)
                    {
                        return StatusCode(402, "Nem sikerült a törlés! " + e.Message);
                    }
                }
            }
            else
            {
                return BadRequest("Nincs jogosultságod!");
            }
        }
    }
}
