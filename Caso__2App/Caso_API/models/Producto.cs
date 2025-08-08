using System.ComponentModel.DataAnnotations;

namespace Caso_API.Models
{
    public static class ProductCategories
    {
        public const string Futbol = "Fútbol";
        public const string Basquetbol = "Básquetbol";
        public const string Natacion = "Natación";
        public const string Tenis = "Tenis";

        public static readonly string[] All = { Futbol, Basquetbol, Natacion, Tenis };
    }

    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Nombre { get; set; }

        [StringLength(1000)]
        public string Descripcion { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
        public decimal Precio { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        public int Stock { get; set; }

        [Required]
        [RegularExpression("Fútbol|Básquetbol|Natación|Tenis",
            ErrorMessage = "Categoría inválida. Use: Fútbol, Básquetbol, Natación o Tenis.")]
        public string Categoria { get; set; }
    }
}
