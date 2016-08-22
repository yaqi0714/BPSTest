using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CL.Data.Factory
{
    public class Factory
    {
        /*
        private static string dataType = CL.Utility.Config.DataBaseType;
        private static string cacheKey = CL.Utility.Keys.CacheKeys.ClassInstance_.ToString();
        public static object CreateInstance(string className)
        {
            string cacheKey1 = cacheKey + className;
            string typeName = "CL.Data." + dataType + "." + className;
            object obj = CL.Cache.IO.Opation.Get(cacheKey1);
            if (obj == null)
            {
                Type type = Assembly.Load("CL.Data." + dataType).GetType(typeName, true);
                obj = Activator.CreateInstance(type);
             
                CL.Cache.IO.Opation.Set(cacheKey1, obj);
        
                return obj;
            }
            else
            {
                return obj;
            }
        }
        */

        public static Data.Interface.IAppLibrary GetAppLibrary()
        {
            return new Data.MSSQL.AppLibrary();
        }

        public static Data.Interface.IDBConnection GetDBConnection()
        {
            return new Data.MSSQL.DBConnection();
        }

        public static Data.Interface.IDictionary GetDictionary()
        {
            return new Data.MSSQL.Dictionary();
        }

        public static Data.Interface.ILog GetLog()
        {
            return new Data.MSSQL.Log();
        }

        public static Data.Interface.IOrganize GetOrganize()
        {
            return new Data.MSSQL.Organize();
        }

        public static Data.Interface.IRole GetRole()
        {
            return new Data.MSSQL.Role();
        }

        public static Data.Interface.IRoleApp GetRoleApp()
        {
            return new Data.MSSQL.RoleApp();
        }

        public static Data.Interface.IUsers GetUsers()
        {
            return new Data.MSSQL.Users();
        }

        public static Data.Interface.IUsersApp GetUsersApp()
        {
            return new Data.MSSQL.UsersApp();
        }

        public static Data.Interface.IUsersInfo GetUsersInfo()
        {
            return new Data.MSSQL.UsersInfo();
        }

        public static Data.Interface.IUsersRelation GetUsersRelation()
        {
            return new Data.MSSQL.UsersRelation();
        }

        public static Data.Interface.IUsersRole GetUsersRole()
        {
            return new Data.MSSQL.UsersRole();
        }

        public static Data.Interface.IWorkGroup GetWorkGroup()
        {
            return new Data.MSSQL.WorkGroup();
        }
    }
}
