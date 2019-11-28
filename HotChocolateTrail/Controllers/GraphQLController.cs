using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolateTrail.Data;
using HotChocolateTrail.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotChocolateTrail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphQLController : Controller
    {
        private readonly IUserRep rep;

        [HttpGet]
        public Ramco20userUser GetUser(string username)
        {
            return rep.GetUser(username);
        }
    }
}