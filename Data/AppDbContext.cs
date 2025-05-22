using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DocumentStorage.Models;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace DocumentStorage.Data;
public class AppDbContext : IdentityDbContext<AppUser>
{
    public DbSet<Document> Documents { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}