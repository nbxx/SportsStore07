using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Concrete;

namespace Vic.SportsStore.WebApp.Controllers
{
    public class NavController : Controller
    {
        public IProductsRepository ProductsRepository { get; set; }
            = new EFProductRepository();

        public PartialViewResult Menu()
        {
            IEnumerable<string> categories = ProductsRepository
                .Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return PartialView(categories);
        }

    }
}