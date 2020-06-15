using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Marten;
using service.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MartenController : ControllerBase
    {
        IDocumentSession _session;

        public MartenController(IDocumentSession session)
        {
            _session = session;
        }

        [HttpGet]
        public IEnumerable<Issue> Get([FromServices] IDocumentStore store)
        {
            store.Schema.ApplyAllConfiguredChangesToDatabase();
            return _session.Query<Issue>().ToList();
        }

        [HttpPost("/issue")]
        public async Task<Guid> PostIssue([FromServices] IDocumentSession session)
        {
            var issue = new Issue
            {
                Description = "Description"
            };

            session.Store(issue);
            await session.SaveChangesAsync();

            return issue.Id;
        }
    }


}