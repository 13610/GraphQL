using GraphQL.Types;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using RvwPocGraphQL.Models;
using RvwPocGraphQL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvwPocGraphQL.Types
{
    public class Ramco20usersUser : ObjectGraphType<Ramco20userUser>
    {
        public Ramco20usersUser(IUserRoleRep roleRep,IUserDefRep defRep,IUserPrefRep prefRep)
        {
           Field("name",x=>x.UserName, nullable : true);
           Field("description",x=>x.UserDescription, nullable : true);
           Field("fullname",x=>x.FullName, nullable : true);
           Field("emailid",x=>x.Email,nullable : true);
           Field("mobilenumber",x=>x.PhoneNumber, nullable : true);
            Field(x => x.Error, nullable: true);
            Field<ListGraphType<UserRole>>("roles",
                resolve: context=>
                {
                    var result = roleRep.GetRoles(context.Source.UserName);
                    return result;
                });
            Field<ResponseGraphType<Ramco20usersUserUserDef>>("userdefaults",
                resolve: context => 
                {
                    var result = defRep.GetUserDef(context.Source.UserName);
                    if (result == null)
                    {
                        return new Response("400", result.Error);
                    }
                    if (result.Error != null)
                    {
                        return new Response("401", result.Error);
                    }
                    else
                    {
                        return new Response(result);
                    }
                });
            Field<ResponseGraphType<UserPrefType>>("userpreferences",
                resolve: context =>
                {
                    var result = prefRep.GetUserPref(context.Source.UserName);
                    if (result == null)
                    {
                        return new Response("400", result.Error);
                    }
                    if (result.Error != null)
                    {
                        return new Response("401", result.Error);
                    }
                    else
                    {
                        return new Response(result);
                    }
                });
        }
    }

    public class UserRole : ObjectGraphType<Roles>
    {
        public UserRole(IUserOusRep ousRep)
        {
           Field(x => x.Userid_p, nullable: true);
           Field("name",x=>x.Name_p,nullable : true);
           Field("description",x=>x.Desc_p,nullable : true);
            Field(X => X.Error, nullable: true);
            Field<ListGraphType<UserRoleOU>>("ous",
             resolve: context => 
             {
                 var result = (ousRep.GetOus(context.Source.Userid_p));
                 return result;
             }); 
        }
    }

    public class UserRoleOU : ObjectGraphType<Ous>
    {
        public UserRoleOU()
        {
           Field("id",x=>x.Ouname_P, nullable : true);
           Field("description",x=>x.Desc_p, nullable : true);
           Field(X => X.Error, nullable: true);
        }
    }

    public class Ramco20usersUserUserDef : ObjectGraphType<UserDefaults>
    {
        public Ramco20usersUserUserDef()
        {
              Field("langid",x=>x.DefaultLang, nullable : true);
              Field("languagedesc",x=>x.LangDescription, nullable : true);
              Field("oudescription",x=>x.OUDescription, nullable : true);
              Field("ouid",x=>x.DefaultOU, nullable : true);
              Field("roledesc",x=>x.RoleDescription, nullable : true);
              Field("rolename",x=>x.DefaultRole, nullable : true);
              Field(X => X.Error, nullable: true);

        }
    }

    public class UserPrefType : ObjectGraphType<UserPreferences>
    {
        public UserPrefType()
        {
            Field(x=>x.Amsymbol, nullable : true);
            Field(x=>x.Dateformat, nullable : true);
            Field(x=>x.Dateseparator, nullable : true);
            Field(x=>x.Daystyle, nullable : true);
            Field(x=>x.Decimalseparator, nullable : true);
            Field(x=>x.Digitgroupformat, nullable : true);
            Field(x=>x.Digitgroupsymbol, nullable : true);
            Field(x=>x.Hourstyle, nullable : true);
            Field(x=>x.Minutestyle, nullable : true);
            Field(x=>x.Monthstyle, nullable : true);
            Field(x=>x.Negativenumberformat, nullable : true);
            Field(x=>x.Pmsymbol, nullable : true);
            Field(x=>x.Secondstyle, nullable : true);
            Field(x=>x.Timeformat, nullable : true);
            Field(x=>x.Timeseparator, nullable : true);
            Field(x=>x.Weekstartday, nullable : true);
            Field(x=>x.Yearstyle, nullable : true);
            Field(x=>x.Error, nullable: true);
        }
    }

    public class ResponseGraphType<TGraphType> : ObjectGraphType<Response> where TGraphType : GraphType
    {
        public ResponseGraphType()
        {
            Name = $"Response{typeof(TGraphType).Name}";
            Field(x => x.StatusCode, nullable: true).Description("Status code of the request.");
            Field<TGraphType>(
                            "data",
                            "Data returned by query.",
                            resolve: context => context.Source.Data
                        );
        }
    }

    public class ResponseGraphicType<tg> : ObjectGraphType<Reaction> where tg : ListGraphType
    {
        public ResponseGraphicType()
        {
            Name = $"Response{typeof(tg).Name}";
            Field(x => x.StatusCode, nullable: true);
            Field<tg>(
                "data",
                "Data returned by query",
                resolve: context => context.Source.Data);
        }
    }
   

}
