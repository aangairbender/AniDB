using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AniDB.Application.UseCases.Databases.Commands.CreateDatabase;
using AniDB.Application.UseCases.Databases.Queries.GetDatabasesList;
using AniDB.Application.UseCases.Databases.Queries.GetSerializedDatabase;
using AniDB.Application.UseCases.Tables.Queries.GetTablesList;
using AniDB.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AniDB.AspNetApi.Controllers
{
    [Route("api/[controller]")]
    public class DatabasesController : Controller
    {
        private IMediator Mediator => (IMediator)HttpContext.RequestServices.GetService(typeof(IMediator));
        // GET: api/<controller>
        [HttpGet]
        public async Task<DatabasesListModel> Get()
        {
            var result = await Mediator.Send(new GetDatabasesListQuery());
            return result;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<string> Get(string id)
        {
            return await Mediator.Send(new GetSerializedDatabaseQuery {DatabaseId = Guid.Parse(id)});
        }

        // GET api/<controller>/5
        [HttpGet("{id}/tables")]
        public async Task<TablesListModel> GetTables(string id)
        {
            return await Mediator.Send(new GetTablesListQuery { DatabaseId = Guid.Parse(id) });
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/name
        [HttpPut("{name}")]
        public async Task<Unit> Put(string name)
        {
            return await Mediator.Send(new CreateDatabaseCommand {Name = name});
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
