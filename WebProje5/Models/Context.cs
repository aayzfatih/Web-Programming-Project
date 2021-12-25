using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProje5.Models
{
    public class Context:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; database=coreWeb; integrated security=true;");
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdresBlog> AdresBlogs { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Hakkimizda> Hakkimizdas { get; set; }
        public DbSet<Iletisim> Iletisims { get; set; }
        public DbSet<Yorumlar> Yorumlars { get; set; }
        public DbSet<Kullanici> Kullanicis { get; set; }

        public DbSet<KullaniciBlog> kullaniciBlogs { get; set; }



    }
}
