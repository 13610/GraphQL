using HotChocolate.DataLoader;
using HotChocolateTrail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateTrail.Data
{
    public interface IUserRep
    {
        Ramco20userUser GetUser(string username);
    }
    public interface IUserRoleRep
    {
        IEnumerable<Roles> GetRoles(string username);
    }
    public interface IUserDefRep
    {
       UserDefaults GetUserDef(string username);
    }
    public interface IUserPrefRep
    {
        UserPreferences GetUserPref(string username);
    }
    public interface IUserOusRep
    {
        IEnumerable<Ous> GetOus(string username);
    }
}
