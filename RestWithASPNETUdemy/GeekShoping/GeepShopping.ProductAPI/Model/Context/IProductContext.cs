using Microsoft.EntityFrameworkCore;

namespace GeepShopping.ProductAPI.Model.Context
{
    public interface IProductContext
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<TEntity> Set<TEntity> () where TEntity : class;
        public DbSet<Product> Products { get; set; }

    }
}
