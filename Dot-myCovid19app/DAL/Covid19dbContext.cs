using Dot_myCovid19app.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Dot_myCovid19app.DAL
{
    public class Covid19dbContext:DbContext
    {
        public Covid19dbContext() : base("Covid19Context")
        {
        }

        public DbSet<URL> URLs{ get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<Dot_myCovid19app.Models.Advice> Advices { get; set; }

        public System.Data.Entity.DbSet<Dot_myCovid19app.Models.Notification> Notifications { get; set; }

        public System.Data.Entity.DbSet<Dot_myCovid19app.Models.Treatment> Treatments { get; set; }

        public System.Data.Entity.DbSet<Dot_myCovid19app.Models.Video> Videos { get; set; }

        public System.Data.Entity.DbSet<Dot_myCovid19app.Models.User> Users { get; set; }
    }
}