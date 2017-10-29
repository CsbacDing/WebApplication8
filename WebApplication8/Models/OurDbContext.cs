using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication8.Models
{
    public class OurDbContext : DbContext
    {
        public OurDbContext() : base("MySqlConnect") { }  //ConnectName
        public DbSet<UserAccount> UserAccounts { get; set; }
    }

    
}