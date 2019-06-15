using System.ComponentModel.DataAnnotations;

namespace Market.Api.Resources
{
    public class CategoryResourcePost
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
