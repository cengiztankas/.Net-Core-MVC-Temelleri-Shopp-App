using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shoppApp.Models;
using ShoppApp.Data;

namespace shoppApp.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(){
          ViewBag.SelectedCategory=RouteData?.Values["id"];
            return View(CategoryRepository.Categories);
        }
    }
}