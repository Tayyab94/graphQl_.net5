using Microsoft.EntityFrameworkCore;
using TodoListQL.Models;

namespace TodoListQL.Data
{
    public class ApiDbContext :DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options):base(options)
        {
        }

        public virtual DbSet<ItemData> Items { get; set; }  
        public virtual DbSet<ItemList> Lists { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemData>(entity =>
            {
                entity.HasOne(d => d.ItemList)
                .WithMany(s => s.ItemDatas)
                .HasForeignKey(s => s.ListId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ItemData_ItemList");
            });

        }
    }
}
