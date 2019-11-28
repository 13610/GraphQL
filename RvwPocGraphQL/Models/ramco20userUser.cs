using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvwPocGraphQL.Models
{
    public class Ramco20userUser
    {
        public string UserName { get; set; }
        public string UserDescription { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Error { get; set; }
        IEnumerable<Roles> Roles { get; set; }
        UserDefaults UserDefaults { get; set; }
        UserPreferences UserPreferences { get; set; }
    }

    public class UserPreferences
    {
        public string Amsymbol { get; set; }
        public string Dateformat { get; set; }
        public string Dateseparator { get; set; }
        public string Daystyle { get; set; }
        public string Decimalseparator { get; set; }
        public string Digitgroupformat { get; set; }
        public string Digitgroupsymbol { get; set; }
        public string Hourstyle { get; set; }
        public string Minutestyle { get; set; }
        public string Monthstyle { get; set; }
        public string Negativenumberformat { get; set; }
        public string Pmsymbol { get; set; }
        public string Secondstyle { get; set; }
        public string Timeformat { get; set; }
        public string Timeseparator { get; set; }
        public string Weekstartday { get; set; }
        public string Yearstyle { get; set; }
        public string Error { get; set; }


    }

    public class Ous
    {
        public string Ouname_P { get;set;}
        public string Desc_p { get; set; }
        public string Error { get; set; }
    }

    public class UserDefaults
    {
        public string DefaultLang { get; set; }
        public string LangDescription { get; set; }
        public string OUDescription { get; set; }
        public string DefaultOU { get; set; }
        public string RoleDescription { get; set; }
        public string DefaultRole { get; set; }
        public string Error { get;  set; }
    }

    public class Roles
    {
        public string Userid_p { get; set; }
        public string Name_p { get; set; }
        public string Desc_p { get; set; }
        IEnumerable<Ous> Ous { get; set; }
        public string Error { get; set; }
    }

    public class Response
    {
        public object Data { get; set; }
        public string StatusCode { get; set; }
        

        public Response(object data)
        {
            StatusCode = "200";
            Data = data;
        }
        public Response(string statusCode, object data)
        {
            StatusCode = statusCode;
            Data = data;
            
        }
    }

    public class  Reaction
    {
        public object Data { get; set; }
        public string StatusCode { get; set; }

        public Reaction(object data)
        {
            StatusCode = "200";
            Data = data;
            
        }
        
        public Reaction(string statusCode, object data)
        {
            StatusCode = statusCode;
            Data = data;
            

        }
    }
}
