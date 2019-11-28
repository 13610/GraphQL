using HotChocolate.Types;
using HotChocolateTrail.Data;
using HotChocolateTrail.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateTrail.Queries
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(t => t.GetUser(default))
                .Name("ramco")
                .Argument("username", a => a.Type<NonNullType<IdType>>())
                .Type<NonNullType<UserType>>();
        }
    }
}
