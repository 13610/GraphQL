using Dapper;
using HotChocolateTrail.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateTrail.Data
{
    public class UserPrefRep : IUserPrefRep
    {
        private readonly string connectionString;
        public UserPrefRep()
        {
            connectionString = @"server=SBURMSCNV02\TECHDEVOPS;Database=DEPDB;Persist Security Info= True;User Id=techdevopslogin;Password=T@chdevops123;";
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
        public UserPreferences GetUserPref(string username)
        {
            
            using (IDbConnection db = Connection)
            {

                var proc = "Core_GetUserPreferences";
                DynamicParameters param = new DynamicParameters();
                param.Add("username", username);
                param.Add("M_errorid", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                try
                {
                    var result = db.QuerySingle<UserPreferences>(proc, param, commandType: CommandType.StoredProcedure);
                    if (result == null)
                    {
                        return null;

                    }
                    else
                    {
                        return result;
                    }
                }
                catch (SqlException ex)
                {
                    return DisplaySqlErrors(ex);

                }

            }
        }
        private UserPreferences DisplaySqlErrors(SqlException exception)
        {
            string error = "0";
            for (int i = 0; i < exception.Errors.Count; i++)
            {
                error = "Index #" + i + "Error: " + exception.Errors[i].ToString();

            }
            UserPreferences a = new UserPreferences
            {
                Error = error
            };
            return a;
        }

    }
    public class UserDefRep : IUserDefRep
    {
        private readonly string connectionString;
        public UserDefRep()
        {
            connectionString = @"server=SBURMSCNV02\TECHDEVOPS;Database=DEPDB;Persist Security Info= True;User Id=techdevopslogin;Password=T@chdevops123;";
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public UserDefaults GetUserDef(string username)
        {
            using (IDbConnection db = Connection)
            {

                var proc = "Core_GetContextDetails_Gql";
                DynamicParameters param = new DynamicParameters();
                param.Add("username", username);
                try
                {
                    var king = db.QuerySingle<UserDefaults>(proc, param, commandType: CommandType.StoredProcedure);
                    return king;


                }
                catch (SqlException ex)
                {
                    return DisplaySqlErrors(ex);
                }
            }
        }
        private UserDefaults DisplaySqlErrors(SqlException exception)
        {
            string error = "0";
            for (int i = 0; i < exception.Errors.Count; i++)
            {
                error = "Index #" + i + "Error: " + exception.Errors[i].ToString();

            }
            UserDefaults a = new UserDefaults
            {
                Error = error
            };
            return a;
        }

    }
    public class UserRep : IUserRep
    {
        private readonly string connectionString;
        public UserRep()
        {
            connectionString = @"server=SBURMSCNV02\TECHDEVOPS;Database=DEPDB;Persist Security Info= True;User Id=techdevopslogin;Password=T@chdevops123;";
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
        public Ramco20userUser GetUser(string username)
        {
            using (IDbConnection db = Connection)
            {

                var proc = "Core_FetchUsersRoleOusServices_Gql";
                DynamicParameters param = new DynamicParameters();
                param.Add("username", username);
                try
                {
                    return db.QuerySingle<Ramco20userUser>(proc, param, commandType: CommandType.StoredProcedure);

                }
                catch (SqlException ex)
                {
                    return DisplaySqlErrors(ex);
                }

            }
        }
        private Ramco20userUser DisplaySqlErrors(SqlException exception)
        {
            string error = "0";
            for (int i = 0; i < exception.Errors.Count; i++)
            {
                error = "Index #" + i + "Error: " + exception.Errors[i].ToString();

            }
            Ramco20userUser a = new Ramco20userUser
            {
                Error = error
            };
            return a;
        }


    }
    public class UserRoleRep : IUserRoleRep
    {
        private readonly string connectionString;
        public UserRoleRep()
        {
            connectionString = @"server=SBURMSCNV02\TECHDEVOPS;Database=DEPDB;Persist Security Info= True;User Id=techdevopslogin;Password=T@chdevops123;";
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
        public IEnumerable<Roles> GetRoles(string username)
        {
            using (IDbConnection db = Connection)
            {

                var proc = "Core_GetUserRoles_Gql";
                DynamicParameters param = new DynamicParameters();
                param.Add("ctxt_user", username);
                try
                {
                    var result = db.Query<Roles>(proc, param, commandType: CommandType.StoredProcedure).ToList();
                    return result;
                }
                catch (SqlException ex)
                {
                    return DisplaySqlErrors(ex);
                }

            }
        }
        private IEnumerable<Roles> DisplaySqlErrors(SqlException exception)
        {
            string error = "0";
            for (int i = 0; i < exception.Errors.Count; i++)
            {
                error = "Index #" + i + "Error: " + exception.Errors[i].ToString();

            }
            Roles a = new Roles
            {
                Error = error
            };
            yield return a;
        }

    }
    public class UserOusRep : IUserOusRep
    {
        private readonly string connectionString;
        public UserOusRep()
        {
            connectionString = @"server=SBURMSCNV02\TECHDEVOPS;Database=DEPDB;Persist Security Info= True;User Id=techdevopslogin;Password=T@chdevops123;";
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
        public IEnumerable<Ous> GetOus(string username)
        {
            using (IDbConnection db = Connection)
            {

                var proc = "Core_GetUserRoleOus_Gql";
                DynamicParameters param = new DynamicParameters();
                param.Add("ctxt_user", username);
                try
                {
                    return db.Query<Ous>(proc, param, commandType: CommandType.StoredProcedure).ToList();

                }
                catch (SqlException ex)
                {
                    return DisplaySqlErrors(ex);
                }

            }
        }
        private IEnumerable<Ous> DisplaySqlErrors(SqlException exception)
        {
            string error = "0";
            for (int i = 0; i < exception.Errors.Count; i++)
            {
                error = "Index #" + i + "Error: " + exception.Errors[i].ToString();

            }
            Ous a = new Ous
            {
                Error = error
            };
            yield return a;
        }

    }
}
