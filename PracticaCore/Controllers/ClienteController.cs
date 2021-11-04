using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PracticaCore.Models.DAO;
using PracticaCore.Models.DTO;
using PracticaCore.Models.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticaCore.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteDAO db = new ClienteDAO();
        private readonly DataResponse response = new DataResponse();
        // GET: api/<ClienteController>
        [HttpGet]
        public IActionResult Get()
        {
            response.Success = 0;
            try
            {
                var lts = db.GetClientes();
                response.Success = 1;
                response.Data = lts;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return Ok(response);
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            response.Success = 0;
            try
            {
                var lts = db.FIndById(id);
                response.Success = 1;
                response.Data = lts;
            }
            catch(Exception e)
            {
                response.Message = e.Message;
            }
            return Ok(response);
        }

        // POST api/<ClienteController>
        [HttpPost]
        [EnableCors("MyPolicy")]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            response.Success = 0;
            try
            {
                db.parameters = new List<SqlParameter>();
                db.parameters.Add(new SqlParameter("@Nombre", cliente.Nombre));
                db.ExecuteNonQuery();
                response.Success = 1;
            }
            catch(Exception e)
            {
                response.Message = e.Message;
            }
            return Ok(response);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        [EnableCors("MyPolicy")]
        public IActionResult Put(int id, [FromBody] Cliente cliente)
        {
            response.Success = 0;
            try
            {
                if (cliente.Id_cli == id)
                {
                    db.parameters = new List<SqlParameter>();
                    db.parameters.Add(new SqlParameter("@Id_cli", cliente.Id_cli));
                    db.parameters.Add(new SqlParameter("@Nombre", cliente.Nombre));
                    db.ExecuteUpdate();
                    response.Success = 1;
                }
            }
            catch(Exception e)
            {
                response.Message = e.Message;
            }
            
            return Ok(response);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            response.Success = 0;
            try
            {
                db.parameters = new List<SqlParameter>();
                db.parameters.Add(new SqlParameter("@id_cli", id));
                db.ExecuteDelete(id);
                response.Success = 1;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return Ok(response);
        }
    }
}
