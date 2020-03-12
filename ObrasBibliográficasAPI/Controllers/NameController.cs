using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObrasBibliográficasAPI.Names;
using ObrasBibliográficasAPI.Models;
using ObrasBibliográficasAPI.Database;
using Microsoft.AspNetCore.Cors;

namespace ObrasBibliográficasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameController : ControllerBase
    {
        // POST: api/Name
        //[DisableCors]
        [HttpPost]
        public dynamic Post([FromBody] Name Name)
        {
            if (Name != null)
            {
                var names = new names();
                // Classe e metodo para conversão do Nome do autor!
                var AuthorName = names.nameProcessPrint(Name.name);
                //Verificação se o nome é valido após o processamento!
                if (AuthorName != null)
                {
                    //ORM Entity Framework Core!
                    using (var dataBase = new DatabaseContext())
                    {
                        //Entity Model
                        var tblNomes = new TblNames();
                        tblNomes.Name = AuthorName;
                        dataBase.TblNames.Add(tblNomes);
                        //Save no database
                        dataBase.SaveChanges();
                        var nameResult = new NameResult();
                        nameResult.result = true;
                        nameResult.Names = dataBase.TblNames.OrderByDescending(a => a.Id).ToList();
                        //Retorna lista seguido do resultado para o FrontEnd Angular em Json.
                        return Ok(nameResult);
                    }
                }
                return BadRequest();
            }

            return BadRequest();
        }
        [HttpGet]
        public dynamic Get()
        {
            using (var dataBase = new DatabaseContext())
            {
                //Entity Model
                var tblNomes = new TblNames();
                var nameResult = new NameResult();
                nameResult.result = true;
                nameResult.Names = dataBase.TblNames.OrderByDescending(a => a.Id).ToList();
                //Retorna lista seguido do resultado para o FrontEnd Angular em Json.
                return Ok(nameResult);
            }

        }




    }
}
