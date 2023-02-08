using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using shoppApp.Models;
using ShoppApp.Data;

namespace shoppApp.Controllers
{
   // [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // ----for view data----

            // var p=new Product() {
            //     Name="Samsung S7",
            //     Price=4000,
            //     Description="iyi bir telefon"
            // };
            // ViewData["Category"]="Telefonlar";
            // ViewData["Product"]=p;

            //----for model----

            var p=new Product() {
                Name="Samsung S7",
                Price=4000,
                Description="iyi bir telefon"
            };
            // ------------------------------------------------
            
            var _ProductViewModel=new ProductViewModel(){
                
                Products=ProductRepository.Products
            };
            return  View(_ProductViewModel);

            // var Category="Telefonlar";
            // ViewBag.Category=Category;
          
        }
         public IActionResult List(int? id, string q)
        {
            // productViewModel/List/3
            // RouteData.Values["Controller"] =>product
            // RouteData.Values["action"] =>list
            // RouteData.Values["id"] =>3
             // Console.WriteLine(q);
            // Console.WriteLine(HttpContext.Request.Query["p"].ToString());
           var _product = ProductRepository.Products;
          
           if(id!=null){
             _product=_product.Where(p=>p.CategoryId==id).ToList();
           }
           if(! string.IsNullOrEmpty(q)){
              _product=  _product.Where(c=>c.Name.ToLower().Contains(q.ToLower())||c.Description.ToLower().Contains(q.ToLower())).ToList();
                // Console.WriteLine(q);
           }
        //     if(min_price!=null){
        //       _product=  _product.Where(c=>c.Price >= (((double)min_price))).ToList();
              
        //    }
            var productViewModel = new ProductViewModel()
            {
                Products = _product
            };
           
            return View(productViewModel);
            
        }
      
        public IActionResult Details(int id){

            // var p=new Product();
              
            //   p.Name="Samsung S6";
            //   p.Price=3000;
            //   p.Description="iyi bir Telefon";

            return View(ProductRepository.GetProductById(id));
        }

        [HttpGet]
      
        public IActionResult Create(){
          
                   ViewBag.Categories=new SelectList(CategoryRepository.Categories,"CategoryId","Name");
                    return View();
        }

        // [HttpPost]
        // public IActionResult Create(string Name,double Price,string Description,string ImgUrl,int CategoryId){
           
        //    Console.WriteLine(Name);
        //    Console.WriteLine(Price);
        //    Console.WriteLine(Description);
        //    Console.WriteLine(ImgUrl);
        //    Console.WriteLine(Name);
           
        //     return View();
        // }
         public IActionResult Create(Product p){
           
        //    Console.WriteLine(p.Name);
        //    Console.WriteLine(p.Price);
        //    Console.WriteLine(p.Description);
        //    Console.WriteLine(p.ImageUrl);
        //    Console.WriteLine(p.CategoryId);

          // ModelState.IsValid==true => validation işlemlerinin hepsinin uygulanmıştır.
            if(ModelState.IsValid){
                ProductRepository.AddProduct(p);
            
                return RedirectToAction ("List" );
            }
            ViewBag.Categories=new SelectList(CategoryRepository.Categories,"CategoryId","Name");
            return View(p);
        }
        [HttpGet]
        public IActionResult Edit(int id){
     
            ViewBag.Categories=new SelectList(CategoryRepository.Categories,"CategoryId","Name");
        
            return View(ProductRepository.GetProductById(id));
        }

        [HttpPost]
        public IActionResult Edit(Product product){
            if(ModelState.IsValid) {
            ProductRepository.EditProduct(product);
            return RedirectToAction("list");
            }
            ViewBag.Categories=new SelectList(CategoryRepository.Categories,"CategoryId","Name");

            return View(product);
        }  
        public IActionResult Delete(int ProductId){
            ProductRepository.DeleteProduct(ProductId);
            return RedirectToAction("list");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
      
    }
}