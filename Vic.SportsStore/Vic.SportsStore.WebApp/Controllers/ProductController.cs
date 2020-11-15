using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Concrete;
using Vic.SportsStore.WebApp.Models;

namespace Vic.SportsStore.WebApp.Controllers
{
    public class ProductController : Controller
    {
        public IProductsRepository ProductsRepository { get; set; }
            = new EFProductRepository();

        public int PageSize = 3;

        public ViewResult List(int page = 1)
        {
            // 1,2,3,   4,5,6,   7,8,9

            // M-V-C

            // M -> ProductsRepository.Products
            // V -> View
            // C -> ProductController

            //var model = ProductsRepository
            //    .Products
            //    .OrderBy(p => p.ProductId)
            //    .Skip((page - 1) * PageSize)
            //    .Take(PageSize);

            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = ProductsRepository
                .Products
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = ProductsRepository.Products.Count()
                }
            };

            return View(model);
        }
    }
}