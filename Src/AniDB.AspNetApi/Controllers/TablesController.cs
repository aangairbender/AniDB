using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AniDB.Application.UseCases.Tables.Queries.GetTableData;
using AniDB.Application.UseCases.Tables.Queries.GetTablesList;
using AniDB.Application.UseCases.Tables.Queries.GetTableSchema;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AniDB.AspNetApi.Controllers
{
    [Route("api/[controller]")]
    public class TablesController : Controller
    {
        private IMediator Mediator => (IMediator)HttpContext.RequestServices.GetService(typeof(IMediator));

        // GET: api/<controller>
        [HttpGet("{id}")]
        public async Task<TableDataModel> Get(string id)
        {
            return await Mediator.Send(new GetTableDataQuery {TableId = Guid.Parse(id)});
        }

        // GET: api/<controller>
        [HttpGet("{id}/schema")]
        public async Task<TableSchemaModel> GetSchema(string id)
        {
            return await Mediator.Send(new GetTableSchemaQuery { TableId = Guid.Parse(id) });
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
