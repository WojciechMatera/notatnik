using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Notatnik.Models;

namespace Notatnik.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private INotatnikRepository repository;

        public NavigationMenuViewComponent(INotatnikRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
