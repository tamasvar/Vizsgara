Adatbázis létrehozása
-Tervezői nézetben kapcsolatok létrehozása. 
- Indexet adni a foreign key-eknek. Először a primary key-t, aztán a foreign keyt jelöljük ki. Update, delete cascade-re állítani.
2. Projekthez 3 nuggetet hozzáadni
    - Microsoft.EntityFrameworkCore
    - Microsoft.EntityFrameworkCore.Tools
    - MySql.EntityFrameworkCore
3. Scaffold-DbContext "server=localhost;database=company;user=root;password=;ssl mode=none;" mysql.entityframeworkcore -outputdir Models -f
4. Startup.cs
    - services.AddCors(c => { c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });
    - app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
5. JsonIgnore a modellekben
    - public vitrual … fölé kell a [JsonIgnore]
6. Program.cs
    - public static string UID = "12345";

Controllers-be egy üres „StudentController.cs” létrehozunk

´´´
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using gyakorlas.Models;

namespace gyakorlas.Controllers
{
    [Route("api")]
    [ApiController]
    public class CowokerController : ControllerBase
    {
        [HttpGet]
        [Route("GetCoworkerNumber")]
        public IActionResult GetCount()
        {
            using (var context = new companyContext())
            {
                try
                {
                    return StatusCode(200, context.Coworkers.Count());
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpGet]
        [Route("GetCoworkerByEmail")]
        public IActionResult GetCoworker(string email)
        {
            using (var context = new companyContext())
            {
                try
                {
                    return StatusCode(200, context.Coworkers.Include(cw => cw.Notebooks).Include(cw => cw.Phones).FirstOrDefault(cw => cw.Email == email));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPost]
        [Route("AddCoworker")]
        public IActionResult Post(Coworker coworker, string uId)
        {
            if (gyakorlas.Program.UID == uId)
            {
                using (var context = new companyContext())
                {
                    try
                    {
                        context.Coworkers.Add(coworker);
                        context.SaveChanges();
                        return StatusCode(201, "Munkavállaló hozzáadása sikeresen megtörtént.");
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
            }
            else
            {
                return StatusCode(401, "Nincs jogosultsága új versenyző felvételéhez! ");
            }
        }

        [HttpPut]
        [Route("UpdateCoworker")]
        public IActionResult Put(Coworker coworker, string uId)
        {
            if (gyakorlas.Program.UID == uId)
            {
                using (var context = new companyContext())
                {
                    try
                    {
                        context.Coworkers.Update(coworker);
                        context.SaveChanges();
                        return StatusCode(200, "Munkavállaló adatainak a módosítása sikeresen megtörtént.");
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
            }
            else
            {
                return StatusCode(401, "Nincs jogosultsága a versenyző adatainak a módosításához!");
            }
        }

        [HttpDelete]
        [Route("DeleteCoworker")]
        public IActionResult Delete(int Id, string uId)
        {
            if (gyakorlas.Program.UID == uId)
            {
                using (var context = new companyContext())
                {
                    try
                    {
                        Coworker coworker = new Coworker();
                        coworker.Id = Id;
                        context.Coworkers.Remove(coworker);
                        context.SaveChanges();
                        return StatusCode(204, "Munkavállaló adatainak a törlése sikeresen megtörtént.");
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
            }
            else
            {
                return StatusCode(401, "Nincs jogosultsága a versenyző adatainak a törléséhez!");
            }
        }

    }
}
