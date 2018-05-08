using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProductHunt.Service.IServices;

namespace ProductHunt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;

        public HomeController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<ActionResult> Index()
        {
            var categories = await _categoryService.FindAllAsync();
            return View(categories);
        }


    }
}