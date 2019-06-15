using System.ComponentModel.DataAnnotations;

namespace Market.Api.Resources
{
    public class CategoryResourceSave
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
