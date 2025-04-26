using System.Collections.Generic;
using Notatnik.Models;


namespace Notatnik.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set;}   
        public PagingInfo PagingInfo { get; set;}
    }
}