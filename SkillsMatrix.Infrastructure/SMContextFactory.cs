using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using SkillsMatrix.Infrastructure;
using System.IO;

public class SMContextFactory : IDesignTimeDbContextFactory<SMContext>
{
    public SMContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SMContext>();
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
        optionsBuilder.UseMySql("Server = 127.0.0.1; Port = 3306; Database = skillsmatrixdb; User Id = root; Password = root", serverVersion);

        return new SMContext(optionsBuilder.Options);
    }
}