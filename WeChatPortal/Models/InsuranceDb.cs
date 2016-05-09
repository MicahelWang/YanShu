using System.Data.Entity.ModelConfiguration.Conventions;

namespace WeChatPortal.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class InsuranceDb : DbContext
    {
        public InsuranceDb()
            : base("name=InsuranceDb")
        {
        }

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<ArticleContent> ArticleContent { get; set; }
        public virtual DbSet<Content> Content { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.Configuration.LazyLoadingEnabled = false;
            modelBuilder.Conventions.Remove< OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Article>()
                .HasMany(e => e.ArticleContent)
                .WithRequired(e => e.Article)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Content>()
                .HasMany(e => e.ArticleContent)
                .WithRequired(e => e.Content)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .Property(e => e.GroupOpenID)
                .IsFixedLength();

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Menu)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Role)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Menu>()
                .HasMany(e => e.Menu1)
                .WithOptional(e => e.Menu2)
                .HasForeignKey(e => e.ParentID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Article)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UpdatedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Content)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UpdatedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Menu)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UpdatedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Product)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UpdatedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Role)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UpdatedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.User1)
                .WithOptional(e => e.User2)
                .HasForeignKey(e => e.ParentID);
        }
    }
}
