using System.Data.Entity;
using LeetcodeMemoApp_V1.Entity;

namespace LeetcodeMemoApp_V1.Model
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(): base("name=DatabaseContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DbContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<LeetcodeMemoEntity> LeetCodeMemo { get; set; }
    }
}
