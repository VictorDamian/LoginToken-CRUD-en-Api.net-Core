using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PracticaCore.Models.DAO;
using PracticaCore.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticaCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            ProductoDAO db = new ProductoDAO();
            var lts = db.GetProductos();
            return lts;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            
            return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] Producto value)
        {
            ProductoDAO db = new ProductoDAO();
            db.parameter = new List<SqlParameter>();
            db.parameter.Add(new SqlParameter("@idNumber", value.Id_pro));
            db.parameter.Add(new SqlParameter("@name", value.Nombre));
            db.parameter.Add(new SqlParameter("@mail", value.Costo));
            db.parameter.Add(new SqlParameter("@birthday", value.PrecioUnitario));
            return Ok(db.ExecuteNonQuery());
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
