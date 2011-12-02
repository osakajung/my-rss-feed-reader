using System;
using System.ComponentModel.DataAnnotations;

namespace RSSFeedWeb.Models
{
    public class CategoryModel
    {
        public Int64 Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [Display(Name = "Category name")]
        public string Name { get; set; }

        public CategoryModel(DataService.CATEGORY category)
        {
            this.Id = category.category_id;
            this.Name = category.category_name;
        }
    }
}
