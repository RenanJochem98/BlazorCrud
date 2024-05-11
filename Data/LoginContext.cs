using BlazorLogin.Model;
using BlazorLogin.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorLogin.Data
{
    public class LoginContext : IdentityDbContext<Usuario, IdentityRole<long>, long>
    {
        public LoginContext() { }
        public LoginContext(DbContextOptions<LoginContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(AppSettingsService.GetConnectionString());
        }
    
    }
}
