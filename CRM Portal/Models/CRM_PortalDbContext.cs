using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace CRM_Portal.Models
{
    public class CRM_PortalDbContext : DbContext
    {
     
        public CRM_PortalDbContext() { }
        public CRM_PortalDbContext(DbContextOptions<CRM_PortalDbContext> options) : base(options)
        {

        }


             public DbSet<Users> tblUsers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer(@"Data Source=1301143-1; Initial Catalog=CRM_DB; persist security info=True; User Id=sa Password=!?fmc@123");
           // optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["Crm_PortalEntities"].ConnectionString);
        }

    }
}
