using Microsoft.EntityFrameworkCore;

namespace ChainOfResponsibilityProject.DAL;

public class Context : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-A6C5CRN\\MSSQLSERVER01;Integrated Security=True;Database=ChainDb;TrustServerCertificate=True");
    }
    public DbSet<CustomerProcess> CustomerProcesses { get; set; }
}
