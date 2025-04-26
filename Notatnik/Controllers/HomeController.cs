using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Notatnik.Models;
using Notatnik.Models.ViewModels;

namespace Notatnik.Controllers
{
    public class HomeController : Controller
    {
        private INotatnikRepository repository;
        public int PageSize = 4;

        public HomeController(INotatnikRepository repo)
        {
            repository = repo;
        }
      //  public IActionResult Index() => View(repository.Products);

        public ViewResult Index(int productPage = 1)
            => View(new ProductsListViewModel
            {
                Products = repository.Products
                    .OrderBy(p => p.ProductID)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Count()
                }
            });
    }
}