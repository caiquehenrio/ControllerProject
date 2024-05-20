using ControllerProject.DataBase.Maps;
using ControllerProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject.DataBase
{

    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<ContactModel> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {

            modelBuilder.ApplyConfiguration(new ContactMap());

            base.OnModelCreating(modelBuilder);

        }

    }

}
