using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
namespace ToDoList.Models
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext() : base("ToDoListContext")
        { }
        public DbSet<ToDoList> ToDoList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}