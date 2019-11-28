using HotChocolate.Resolvers;
using HotChocolate.Types;
using HotChocolateTrail.Data;
using HotChocolateTrail.Models;
using GreenDonut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateTrail.Types
{
    public class UserType : ObjectType<Ramco20userUser>
    {
        protected override void Configure(IObjectTypeDescriptor<Ramco20userUser> descriptor)
        {
            descriptor.Name("ramco20userUser");
            descriptor.Field(a => a.UserName).Type<StringType>();
            descriptor.Field(a => a.FullName).Type<StringType>();
            descriptor.Field(a => a.Email).Type<StringType>();
            descriptor.Field(a => a.PhoneNumber).Type<StringType>();
            descriptor.Field(a => a.UserDescription).Type<StringType>();
            descriptor.Field(a => a.Error).Type<StringType>();
            descriptor.Field("UserDefaults").Type<UserDefType>().Resolver(context => context.Service<IUserDefRep>().GetUserDef(context.Parent<Ramco20userUser>().UserName));
            descriptor.Field("UserPreferences").Type<UserPrefType>().Resolver(context => context.Service<IUserPrefRep>().GetUserPref(context.Parent<Ramco20userUser>().UserName));
            descriptor.Field("Roles").Type<ListType<UserRoleType>>().Resolver(context => context.Service<IUserRoleRep>().GetRoles(context.Parent<Ramco20userUser>().UserName));
        }
    }
    public class UserDefType : ObjectType<UserDefaults>
    {
        protected override void Configure(IObjectTypeDescriptor<UserDefaults> descriptor)
        {
            descriptor.Name("UserDefaults");
            descriptor.Field(a => a.DefaultLang).Type<StringType>();
            descriptor.Field(a => a.LangDescription).Type<StringType>();
            descriptor.Field(a => a.DefaultOU).Type<StringType>();
            descriptor.Field(a => a.DefaultRole).Type<StringType>();
            descriptor.Field(a => a.OUDescription).Type<StringType>();
            descriptor.Field(a => a.RoleDescription).Type<StringType>();
        }
    }
    public class UserPrefType : ObjectType<UserPreferences>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPreferences> descriptor)
        {
            descriptor.Name("UserPreferences");
            descriptor.Field(a => a.Amsymbol).Type<StringType>();
            descriptor.Field(a => a.Pmsymbol).Type<StringType>();
            descriptor.Field(a => a.Secondstyle).Type<StringType>();
            descriptor.Field(a => a.Minutestyle).Type<StringType>();
            descriptor.Field(a => a.Monthstyle).Type<StringType>();
            descriptor.Field(a => a.Dateformat).Type<StringType>();
            descriptor.Field(a => a.Dateseparator).Type<StringType>();
            descriptor.Field(a => a.Daystyle).Type<StringType>();
            descriptor.Field(a => a.Weekstartday).Type<StringType>();
            descriptor.Field(a => a.Timeformat).Type<StringType>();
            descriptor.Field(a => a.Timeseparator).Type<StringType>();
            descriptor.Field(a => a.Negativenumberformat).Type<StringType>();
            descriptor.Field(a => a.Hourstyle).Type<StringType>();
            descriptor.Field(a => a.Decimalseparator).Type<StringType>();
            descriptor.Field(a => a.Digitgroupformat).Type<StringType>();
            descriptor.Field(a => a.Digitgroupsymbol).Type<StringType>();
            descriptor.Field(a => a.Yearstyle).Type<StringType>(); 
        }
    }

    public class UserRoleType : ObjectType<Roles>
    {
        protected override void Configure(IObjectTypeDescriptor<Roles> descriptor)
        {
            descriptor.Name("Roles");
            descriptor.Field(x => x.Userid_p).Type<StringType>();
            descriptor.Field(x => x.Name_p).Type<StringType>();
            descriptor.Field(x => x.Desc_p).Type<StringType>();
            descriptor.Field(x => x.Error).Type<StringType>();
            descriptor.Field("ous").Type<ListType<UserRoleOUType>>().Resolver(context => context.Service<IUserOusRep>().GetOus(context.Parent<Roles>().Userid_p));
        }
    }

    public class UserRoleOUType : ObjectType<Ous>
    {
        protected override void Configure(IObjectTypeDescriptor<Ous> descriptor)
        {
            descriptor.Name("Ous");
            descriptor.Field(x => x.Ouname_P).Type<StringType>();
            descriptor.Field(x => x.Desc_p).Type<StringType>();
            descriptor.Field(X => X.Error).Type<StringType>();
        }
    }
}
