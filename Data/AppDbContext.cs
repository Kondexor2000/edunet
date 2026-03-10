using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Eduworknet.Models;

namespace Worknet.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ApplicationUser> User => Set<ApplicationUser>();
        public DbSet<Subject> Subjects => Set<Subject>();
        public DbSet<CategoryCourse> CategoryCourses => Set<CategoryCourse>();
        public DbSet<TagCourse> TagCourses => Set<TagCourse>();
    }
}