using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tp3.Data;
using Tp3.Models;
using Tp3.Services;

namespace Tp3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AmigosController : ControllerBase
    {
        private readonly AmigoService _context;

        public AmigosController(AmigoService context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Amigo> Get()
        {
            return _context.GetAll();
        }

        [HttpGet("{id}")]
        public Amigo Get(Guid id)
        {
            return _context.GetAmigoById(id);
        }

        [HttpPost]
        public void Post([FromBody] Amigo model)
        {
            try
            {
                this._context.Save(model);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            this._context.Delete(id);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Amigo model)
        {
            this._context.Update(id, model);
        }
    }
}
