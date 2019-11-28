using HotChocolate;
using HotChocolateTrail.Data;
using HotChocolateTrail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateTrail.Queries
{
    public class Query
    {
        private readonly IUserRep _rep;
        public Query(IUserRep userRep)
        {
            _rep = userRep ?? throw new ArgumentNullException(nameof(userRep));
       
        }
        public Ramco20userUser GetUser(string username)
        {
            return _rep.GetUser(username);
        } 
    }
}
