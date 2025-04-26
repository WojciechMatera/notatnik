using System.Linq;

namespace Notatnik.Models
{
    public interface INotatnikRepository
    {
        IQueryable<Product> Products { get; }   
    }
}