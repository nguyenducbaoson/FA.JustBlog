using FA.JustBlog.Entities.Configuration;
using FA.JustBlog.Entities.Enum;
using FA.JustBlog.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Entities.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTagMap> PostTagMaps { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=DESKTOP-V56RKEE;Database=JustBlog;Integrated Security=True;Trusted_Connection =True;TrustServerCertificate=True;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TagConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostTagMapConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CommentConfiguration).Assembly);

        modelBuilder.Entity<Post>().HasData(
            new Post { PostId = 1, Title = "Title 1", ShortDecription = "mot", UrlSlug = "Url1", Published = true, PostOn = new DateTime(2012, 12, 25, 1, 3, 12), Modify = DateTime.Now, CategoryId = 1, PostContent = "Post content", CreateAt = DateTime.Now, Status = Status.Actived, },
            new Post { PostId = 2, Title = "Title 2", ShortDecription = "hai", UrlSlug = "Url12", Published = true, PostOn = new DateTime(2021, 12, 25, 1, 3, 12), Modify = DateTime.Now, CategoryId = 1, PostContent = "employee", CreateAt = DateTime.Now, Status = Status.Actived },
            new Post { PostId = 3, Title = "Title 3", ShortDecription = "ba", UrlSlug = "Url3", Published = true, PostOn = new DateTime(2020, 12, 25, 1, 3, 12), Modify = DateTime.Now, CategoryId = 2, PostContent = "Name", CreateAt = DateTime.Now, Status = Status.Actived },
            new Post { PostId = 4, Title = "Title 4", ShortDecription = "bon", UrlSlug = "Url4", Published = false, PostOn = new DateTime(2016, 12, 25, 1, 3, 12), Modify = DateTime.Now, CategoryId = 2, PostContent = "gae", CreateAt = DateTime.Now, Status = Status.Actived },
            new Post { PostId = 5, Title = "Title 5", ShortDecription = "nam", UrlSlug = "Url5", Published = true, PostOn = new DateTime(2015, 12, 25, 1, 3, 12), Modify = DateTime.Now, CategoryId = 1, PostContent = "Car", CreateAt = DateTime.Now, Status = Status.Actived }
               );

            modelBuilder.Entity<Category>().HasData(
     new Category { CategoryId = 1, CategoryName = "Science", UrlSlug = "#", Description = "Delecius", CreateAt = DateTime.Now, Modify = DateTime.Now, Status = Status.Actived },
     new Category { CategoryId = 2, CategoryName = "Social", UrlSlug = "#", Description = "Delecius", CreateAt = DateTime.Now, Modify = DateTime.Now, Status = Status.Actived },
     new Category { CategoryId = 3, CategoryName = "Culture", UrlSlug = "#", Description = "Not good", CreateAt = DateTime.Now, Modify = DateTime.Now, Status = Status.Actived },
     new Category { CategoryId = 4, CategoryName = "Travel", UrlSlug = "#", Description = "Delecius", CreateAt = DateTime.Now, Modify = DateTime.Now, Status = Status.Actived }
     );

            modelBuilder.Entity<Tag>().HasData(
                new Tag { TagId = 1, Name = "Bao Son", Description = "None", UrlSlug = "Tag/what-is-a-url-slug1", Count = 1 },
                new Tag { TagId = 2, Name = "Andreww", Description = "Description", UrlSlug = "Tag/what-is-a-url-slug2", Count = 2 },
                new Tag { TagId = 3, Name = "Nam", Description = "Description 1", UrlSlug = "Tag/what-is-a-url-slug3", Count = 2 },
                new Tag { TagId = 4, Name = "Nhung", Description = "Description 3", UrlSlug = "Tag/what-is-a-url-slug3", Count = 2 }
                );

            modelBuilder.Entity<PostTagMap>().HasData(
                new PostTagMap { PostId = 1, TagId = 1 },
                new PostTagMap { PostId = 2, TagId = 1 },
                new PostTagMap { PostId = 3, TagId = 1 },
                new PostTagMap { PostId = 1, TagId = 2 },
                new PostTagMap { PostId = 1, TagId = 3 }
                );
            modelBuilder.Entity<Comment>().HasData(
                new Comment { CommentId=1,CommentHeader="None",PostId=1,Name="Adnreww",Email="Andreww@gmail.com",CommentText="None",CommentTime=new DateTime(2015, 12, 25, 1, 3, 12)},
                new Comment { CommentId = 2, CommentHeader = "None", PostId = 1, Name = "baoson", Email = "Andreww@gmail.com", CommentText = "None", CommentTime = new DateTime(2015, 12, 25, 1, 3, 12) },
                  new Comment { CommentId = 13, CommentHeader = "None", PostId = 1, Name = "thuyen", Email = "Andreww@gmail.com", CommentText = "None", CommentTime = new DateTime(2015, 12, 25, 1, 3, 12) }
            );
        }
    }
}