using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Week_Project.Areas.Identity.Data;
using Week_Project.Models;

namespace Week_Project.Data;

public class Week_ProjectContext : IdentityDbContext<Week_ProjectUser>
{
    public Week_ProjectContext(DbContextOptions<Week_ProjectContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    public DbSet<Admin_pg> Admin_Pgs { get; set; }
    public DbSet<Doctor_Detail> Doctor_Details { get; set; }
    public DbSet<Patient> Patients { get; set; }
}
