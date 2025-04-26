using System.Linq;

namespace Notatnik.Models
{
public class EFNotatnikRepository : INotatnikRepository {
    private NotatnikDbContext context;

    public EFNotatnikRepository(NotatnikDbContext ctx){
        context = ctx;
    }

    public IQueryable<Product> Products => context.Products;
}
}
