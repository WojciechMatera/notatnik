using System.ComponentModel.DataAnnotations.Schema;

namespace Notatnik.Models
{
    public class Product
    {
        public long ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }    
        public string Category { get; set; }
    }
}