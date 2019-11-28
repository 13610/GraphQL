using GraphQL;
using GraphQL.Types;
using RvwPocGraphQL.Models;
using RvwPocGraphQL.Repos;
using RvwPocGraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvwPocGraphQL.Resolvers
{
    public class Query :ObjectGraphType
    {
        public Query(IUserRep userRep)
        {
            Field<ResponseGraphType<Ramco20usersUser>>(
                "ramco20userUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "username", Description = "username" }),
                resolve: context=> 
                {
                    var result = userRep.GetUser(context.GetArgument<string>("username"));
                    if(result == null)
                    {
                        return new Response("400",result.Error);
                    }
                    if(result.Error != null)
                    {
                        return new Response("401",result.Error);

                    }
                    else
                    {
                        return new Response(result);
                    }

                });
        }
    }

    public class RootSchema : Schema
    {
        public RootSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<Query>();
        }
    }
}
