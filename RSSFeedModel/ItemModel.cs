using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace RSSFeedModel
{
    public class ItemModel
    {
        public Int64 Id { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Url)]
        public string Link { get; set; }

        public string Description { get; set; }

        public FeedModel Feed { get; set; }

        public ItemModel(DataService.ITEM item)
        {
            this.Id = item.item_id;
            this.Title = item.item_title;
            this.Link = item.item_link;
            this.Description = item.item_description;
            this.Feed = (from f in Tools.context.FEED
                         where f.feed_id == item.feed_id
                         select new FeedModel(f)).FirstOrDefault();
        }
    }
}
