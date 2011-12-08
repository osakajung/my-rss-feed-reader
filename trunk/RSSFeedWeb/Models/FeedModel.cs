using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace RSSFeedWeb.Models
{
    public class FeedModel
    {
        public Int64 Id { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Address { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Url)]
        public string Link { get; set; }

        public string Description { get; set; }

        [Display(Name = "New")]
        public long NonReadItems { get; set; }

        public CategoryModel Category { get; set; }

        public FeedModel(){}

        public FeedModel(DataService.FEED feed)
        {
            DataService.RSSFeedDatabaseEntities ctx = Tools.Context();
            this.Id = feed.feed_id;
            this.Address = feed.feed_address;
            this.Title = feed.feed_title;
            this.Link = feed.feed_link;
            this.Description = feed.feed_description;
            this.Category = (from c in ctx.CATEGORY
                            where c.category_id == feed.category_id
                            select new CategoryModel(c)).FirstOrDefault();
        }
    }
}
