using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shoppApp.Models;

namespace ShoppApp.Data
{
   
   
    public static class ProductRepository
    {
     static List<Product> _products=null;
     static ProductRepository()
     {
        _products=new List<Product>{
            new Product(){ProductId=1, Name="Samsung S5",Price=4500,Description="iyi bir telefon",IsApproved=false,ImageUrl="1.jpg",CategoryId=1},
            new Product(){ProductId=2,Name="Samsung S6",Price=6500,Description="Çok iyi bir telefon",IsApproved=true,ImageUrl="2.jpg",CategoryId=1},
            new Product(){ProductId=3,Name="Samsung S7",Price=8500,Description="Çok güzel bir telefon",IsApproved=false,ImageUrl="3.jpg",CategoryId=1},
            new Product(){ProductId=4,Name="Samsung S9 pro",Price=10500,Description="Çok çok güzel bir telefon",IsApproved=true,ImageUrl="4.jpg",CategoryId=1},
            new Product(){ProductId=6,Name="Lenovo S6",Price=6500,Description="Çok iyi bir Bilgisayar",IsApproved=true,ImageUrl="9.jpg",CategoryId=2},
            new Product(){ProductId=7,Name="Lenovo S7",Price=8500,Description="Çok güzel bir Bilgisayar",IsApproved=false,ImageUrl="10.jpg",CategoryId=2},
            new Product(){ProductId=8,Name="Lenovo S9 pro",Price=10500,Description="Çok çok güzel bir Bilgisayar",IsApproved=true,ImageUrl="11.jpg",CategoryId=2},
            new Product(){ProductId=9, Name="Asus S5",Price=4500,Description="iyi bir Tablet",IsApproved=false,ImageUrl="1.jpg",CategoryId=3},
            new Product(){ProductId=10,Name="Asus S6",Price=6500,Description="Çok iyi bir Tablet",IsApproved=true,ImageUrl="2.jpg",CategoryId=3},
            new Product(){ProductId=11,Name="Asus S7",Price=8500,Description="Çok güzel bir Tablet",IsApproved=false,ImageUrl="3.jpg",CategoryId=3},
            new Product(){ProductId=12,Name="Asus S9 pro",Price=10500,Description="Çok çok güzel bir Tablet",IsApproved=true,ImageUrl="4.jpg",CategoryId=3}
       
       
        };
        
     }

    public static List<Product> Products{
        get{
            return _products;
        }
    }

    public static void AddProduct(Product product){
        _products.Add(product);
    }


    public static Product GetProductById(int id){
        return _products.FirstOrDefault(p=>p.ProductId==id);
    }

    public static List<Product> GetProductsByCategory(int id){
        return _products.Where(p=>p.CategoryId==id).ToList();
    }

    public static void EditProduct(Product product){
         
         foreach (var p in _products)
         {
            if (product.ProductId==p.ProductId)
            {
                p.Name=product.Name;
                p.Price=product.Price;
                p.Description=product.Description;
                p.ImageUrl=product.ImageUrl;
                p.CategoryId=product.CategoryId;
            }
         }
    }
    public static void DeleteProduct(int id){
       var product=GetProductById(id);
       if (product!=null)
       {
          _products.Remove(product);
       }
    }
    }
}