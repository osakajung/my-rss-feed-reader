﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RSSFeedWeb.ParserService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ParserService.IFeedParser")]
    public interface IFeedParser {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFeedParser/parseFeed", ReplyAction="http://tempuri.org/IFeedParser/parseFeedResponse")]
        bool parseFeed(string myUrl);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFeedParserChannel : RSSFeedWeb.ParserService.IFeedParser, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FeedParserClient : System.ServiceModel.ClientBase<RSSFeedWeb.ParserService.IFeedParser>, RSSFeedWeb.ParserService.IFeedParser {
        
        public FeedParserClient() {
        }
        
        public FeedParserClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FeedParserClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FeedParserClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FeedParserClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool parseFeed(string myUrl) {
            return base.Channel.parseFeed(myUrl);
        }
    }
}
