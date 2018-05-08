using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ProductHunt.Domain.Models;
using ProductHunt.Service.IServices;

namespace ProductHunt.Controllers
{
    [Route("{action=index}")]
    public class ArticleController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;

        public ArticleController(ICategoryService categoryService, IArticleService articleService)
        {
            _categoryService = categoryService;
            _articleService = articleService;
        }
        public async Task<ActionResult> Index()
        {
            var categories = await _categoryService.FindAllAsync();
            return View(categories);
        }

        [Route("{categoryName}")]
        public async Task<ActionResult> Category(string categoryName)
        {
            var articles = await _articleService.FindAllAsync(p => p.Category.Name == categoryName);
            ViewBag.Category = categoryName;
            return View(articles);
        }

        [Route("{categoryName}/{articleName}", Name = "article")]
        public async Task<ActionResult> Article(string categoryName, string articleName)
        {
            var article = await _articleService.FindAsync(p => p.Category.Name == categoryName && p.Name == articleName.Replace("-", " "));
            ViewBag.Category = categoryName;
            return View(article);
        }


        [Route("{categoryName}/{articleName}/edit", Name = "article-edit")]
        public async Task<ActionResult> EditArticle(string categoryName, string articleName)
        {
            var article = await _articleService.FindAsync(p => p.Category.Name == categoryName && p.Name == articleName.Replace("-", " "));
            var categories = await _categoryService.FindAllAsync();
            ViewBag.CategoryList = categories.Select(p => new SelectListItem() { Text = p.Name, Value = p.Id.ToString() });
            return View(article);
        }

        [Route("{categoryName}/{articleName}/edit", Name = "article-edit-post")]
        [HttpPost]
        public async Task<ActionResult> EditArticle(string categoryName, string articleName, ArticleModel model)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.FindAllAsync();
                ViewBag.CategoryList = categories.Select(p => new SelectListItem() { Text = p.Name, Value = p.Id.ToString() });
                return View(model);
            }
            model.Price = (model.PriceWithVAT * 12.5m) / 100 - model.Price;
            var article  = await _articleService.Update(model);
            return RedirectToRoutePermanent("article", new { categoryName = article.CategoryName, articleName = article.Name.Replace(" ", "-") });
        }

    }
}