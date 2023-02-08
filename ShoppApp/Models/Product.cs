using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shoppApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required] 
        [StringLength(60,MinimumLength =5,ErrorMessage ="5-60 arası karakter dizisi")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Fiyat alanı boş bıraklımaz")]
        [Range(1,1000000)]

        public double Price { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}