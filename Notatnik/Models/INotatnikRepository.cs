using System.Linq;

namespace Notatnik.Models
{
    public interface INotatnikRepository
    {
        IQueryable<Product> Products { get; }   
        
        void SaveProduct(Product p);
        void CreateProduct(Product p);
        void DeleteProduct(Product p);
    }
}