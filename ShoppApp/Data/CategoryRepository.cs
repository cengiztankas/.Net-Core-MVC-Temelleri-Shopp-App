using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shoppApp.Models;

namespace ShoppApp.Data
{
    public class CategoryRepository
    {
        private static List<Category> _category =null;

        static CategoryRepository()
        {
            _category=new List<Category>{
                new Category(){CategoryId=1,Name="Telefon",Description="Telefon kategorisi"},
                new Category(){CategoryId=2,Name="Bilgisayar",Description="Tablet kategorisi"},
                new Category(){CategoryId=3,Name="Tablet",Description="Bilgisayar kategorisi"},
                new Category(){CategoryId=4,Name="Elektronik",Description="Elektronik kategorisi"}
            };
            
        }

        public static List<Category> Categories{
            get{
                return _category;
            }
        }

        public static void AddCategory(Category category)
        {
            _category.Add(category);
        }
        public static Category GetCategoryById(int id){
            return _category.FirstOrDefault(p=>p.CategoryId==id);
        }
    }
}