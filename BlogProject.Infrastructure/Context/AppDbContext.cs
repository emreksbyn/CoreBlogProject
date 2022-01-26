using BlogProject.Infrastructure.Utilities;
using BlogProject.Model.Entities.Abstract;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.EntityTypeConfiguration.Concrete;
using BlogProject.Model.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ArticleMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new LikeMap());

            base.OnModelCreating(modelBuilder);
        }

        // Layz Loading açma Ef Core' da Eager Loading defalut olarak bulunmaktadır. projde Layz Loading kullanmak istersek :

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // UseLayzLoadingProxies için Microsoft.EntityFrameworkCore.Proxies paketi kurulur.
        //    optionsBuilder.UseLayzLoadingProxies();
        //    base.OnConfiguring(optionsBuilder);
        //}

        public override int SaveChanges()
        {
            var modifiedEntities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added ||
                          x.State == EntityState.Modified ||
                          x.State == EntityState.Deleted).ToList();

            string computerName = Environment.MachineName;
            string ipAddress = RemoteIpAddress.IpAddress;
            DateTime date = DateTime.Now;

            foreach (var item in modifiedEntities)
            {
                BaseEntity entity = item.Entity as BaseEntity;

                if (item != null)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            entity.CreateDate = date;
                            entity.CreatedComputerName = computerName;
                            entity.CreatedIp = ipAddress;
                            entity.Status = Status.Active;
                            break;
                        case EntityState.Modified:
                            entity.ModifiedDate = date;
                            entity.ModifiedComputerName = computerName;
                            entity.ModifiedIp = ipAddress;
                            entity.Status = Status.Modified;
                            break;
                        case EntityState.Deleted:
                            entity.RemovedDate = date;
                            entity.RemovedComputerName = computerName;
                            entity.RemovedIp = ipAddress;
                            entity.Status = Status.Passive;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
