using sodsag.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace sodsag.Data;
public class AppicationDbContext : IdentityDbContext<AppUser>
{
    // public AppicationDbContext(DbContextOptions<AppicationDbContext> options)
    //     : base(options)
    //     {

    //     }
   public AppicationDbContext(DbContextOptions<AppicationDbContext> options) : base(options)
    {

    }
    
    public DbSet<NurseRequest> NurseRequests {get; set;}
    public DbSet<Patient> Patients {get; set;}
  
}
