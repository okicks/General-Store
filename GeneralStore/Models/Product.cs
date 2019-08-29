using System.ComponentModel.DataAnnotations;

namespace GeneralStore.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        public int InventoryCount { get; set; }

        [Required]
        [Display(Name = "Is it Food?")]
        public bool IsFood { get; set; }
    }
}