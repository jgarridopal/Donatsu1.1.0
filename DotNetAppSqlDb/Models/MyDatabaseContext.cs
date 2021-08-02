/*
   DESIGNER: Juan Sebastian Garrido Pallares(ID: 100600388) & Pei Shuen Beh(ID: 100599009)
   EXERCISE: Assignment 2
   TASK: CS CLASS For DATABASECONTEXT PAGE
*/
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Models
{
    public class MyDatabaseContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MyDatabaseContext() : base("name=MyDB")
        {
        }

        public System.Data.Entity.DbSet<DotNetAppSqlDb.Models.Todo> Todoes { get; set; }
    }
}
