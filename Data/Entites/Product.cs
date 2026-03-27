using System.ComponentModel.DataAnnotations;

namespace Azure_uppgift1_API.Data.Entites
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string PName { get; set; }
        public double Price { get; set; }
        
    }
}
