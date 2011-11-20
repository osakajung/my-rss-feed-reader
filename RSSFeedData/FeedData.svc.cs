using System.Data.Services;
using System.Data.Services.Common;

namespace RSSFeedData
{
    public class FeedData : DataService<RSSFeedDatabaseEntities>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:

            config.UseVerboseErrors = true;

            config.SetEntitySetAccessRule("*", EntitySetRights.All);
            //config.SetEntitySetAccessRule("CATEGORY", EntitySetRights.AllRead);
            //config.SetEntitySetAccessRule("FEED", EntitySetRights.AllRead);
            //config.SetEntitySetAccessRule("ITEM", EntitySetRights.AllRead);
            //config.SetEntitySetAccessRule("READ", EntitySetRights.AllRead);
            //config.SetEntitySetAccessRule("ROLE", EntitySetRights.AllRead);
            //config.SetEntitySetAccessRule("STATUS", EntitySetRights.All);
            //config.SetEntitySetAccessRule("SUBSCRIBE", EntitySetRights.AllRead);
            //config.SetEntitySetAccessRule("USER", EntitySetRights.All);

            // config.SetServiceOperationAccessRule("MyServiceOperation", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
        }
    }
}
