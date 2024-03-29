﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RSSFeedWeb.AccountService {
    using System.Runtime.Serialization;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ClientType", Namespace="http://schemas.datacontract.org/2004/07/RSSFeedAccountManager")]
    public enum ClientType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        NoClient = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        WebClient = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DesktopClient = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        MobileClient = 3,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AccountService.IAccountManager")]
    public interface IAccountManager {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountManager/logOn", ReplyAction="http://tempuri.org/IAccountManager/logOnResponse")]
        bool logOn(string email, string password, RSSFeedWeb.AccountService.ClientType clientId);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IAccountManager/logOn", ReplyAction="http://tempuri.org/IAccountManager/logOnResponse")]
        System.IAsyncResult BeginlogOn(string email, string password, RSSFeedWeb.AccountService.ClientType clientId, System.AsyncCallback callback, object asyncState);
        
        bool EndlogOn(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountManager/logOff", ReplyAction="http://tempuri.org/IAccountManager/logOffResponse")]
        bool logOff(string email);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IAccountManager/logOff", ReplyAction="http://tempuri.org/IAccountManager/logOffResponse")]
        System.IAsyncResult BeginlogOff(string email, System.AsyncCallback callback, object asyncState);
        
        bool EndlogOff(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountManager/Register", ReplyAction="http://tempuri.org/IAccountManager/RegisterResponse")]
        bool Register(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IAccountManager/Register", ReplyAction="http://tempuri.org/IAccountManager/RegisterResponse")]
        System.IAsyncResult BeginRegister(string email, string password, System.AsyncCallback callback, object asyncState);
        
        bool EndRegister(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountManager/ChangePassword", ReplyAction="http://tempuri.org/IAccountManager/ChangePasswordResponse")]
        bool ChangePassword(string email, string password, string newPassword);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IAccountManager/ChangePassword", ReplyAction="http://tempuri.org/IAccountManager/ChangePasswordResponse")]
        System.IAsyncResult BeginChangePassword(string email, string password, string newPassword, System.AsyncCallback callback, object asyncState);
        
        bool EndChangePassword(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountManager/ResetPassword", ReplyAction="http://tempuri.org/IAccountManager/ResetPasswordResponse")]
        void ResetPassword();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IAccountManager/ResetPassword", ReplyAction="http://tempuri.org/IAccountManager/ResetPasswordResponse")]
        System.IAsyncResult BeginResetPassword(System.AsyncCallback callback, object asyncState);
        
        void EndResetPassword(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountManager/RegisterConfirmation", ReplyAction="http://tempuri.org/IAccountManager/RegisterConfirmationResponse")]
        bool RegisterConfirmation(string key);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IAccountManager/RegisterConfirmation", ReplyAction="http://tempuri.org/IAccountManager/RegisterConfirmationResponse")]
        System.IAsyncResult BeginRegisterConfirmation(string key, System.AsyncCallback callback, object asyncState);
        
        bool EndRegisterConfirmation(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAccountManagerChannel : RSSFeedWeb.AccountService.IAccountManager, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class logOnCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public logOnCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class logOffCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public logOffCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RegisterCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public RegisterCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChangePasswordCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public ChangePasswordCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RegisterConfirmationCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public RegisterConfirmationCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AccountManagerClient : System.ServiceModel.ClientBase<RSSFeedWeb.AccountService.IAccountManager>, RSSFeedWeb.AccountService.IAccountManager {
        
        private BeginOperationDelegate onBeginlogOnDelegate;
        
        private EndOperationDelegate onEndlogOnDelegate;
        
        private System.Threading.SendOrPostCallback onlogOnCompletedDelegate;
        
        private BeginOperationDelegate onBeginlogOffDelegate;
        
        private EndOperationDelegate onEndlogOffDelegate;
        
        private System.Threading.SendOrPostCallback onlogOffCompletedDelegate;
        
        private BeginOperationDelegate onBeginRegisterDelegate;
        
        private EndOperationDelegate onEndRegisterDelegate;
        
        private System.Threading.SendOrPostCallback onRegisterCompletedDelegate;
        
        private BeginOperationDelegate onBeginChangePasswordDelegate;
        
        private EndOperationDelegate onEndChangePasswordDelegate;
        
        private System.Threading.SendOrPostCallback onChangePasswordCompletedDelegate;
        
        private BeginOperationDelegate onBeginResetPasswordDelegate;
        
        private EndOperationDelegate onEndResetPasswordDelegate;
        
        private System.Threading.SendOrPostCallback onResetPasswordCompletedDelegate;
        
        private BeginOperationDelegate onBeginRegisterConfirmationDelegate;
        
        private EndOperationDelegate onEndRegisterConfirmationDelegate;
        
        private System.Threading.SendOrPostCallback onRegisterConfirmationCompletedDelegate;
        
        public AccountManagerClient() {
        }
        
        public AccountManagerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AccountManagerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountManagerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountManagerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<logOnCompletedEventArgs> logOnCompleted;
        
        public event System.EventHandler<logOffCompletedEventArgs> logOffCompleted;
        
        public event System.EventHandler<RegisterCompletedEventArgs> RegisterCompleted;
        
        public event System.EventHandler<ChangePasswordCompletedEventArgs> ChangePasswordCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> ResetPasswordCompleted;
        
        public event System.EventHandler<RegisterConfirmationCompletedEventArgs> RegisterConfirmationCompleted;
        
        public bool logOn(string email, string password, RSSFeedWeb.AccountService.ClientType clientId) {
            return base.Channel.logOn(email, password, clientId);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginlogOn(string email, string password, RSSFeedWeb.AccountService.ClientType clientId, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginlogOn(email, password, clientId, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndlogOn(System.IAsyncResult result) {
            return base.Channel.EndlogOn(result);
        }
        
        private System.IAsyncResult OnBeginlogOn(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string email = ((string)(inValues[0]));
            string password = ((string)(inValues[1]));
            RSSFeedWeb.AccountService.ClientType clientId = ((RSSFeedWeb.AccountService.ClientType)(inValues[2]));
            return this.BeginlogOn(email, password, clientId, callback, asyncState);
        }
        
        private object[] OnEndlogOn(System.IAsyncResult result) {
            bool retVal = this.EndlogOn(result);
            return new object[] {
                    retVal};
        }
        
        private void OnlogOnCompleted(object state) {
            if ((this.logOnCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.logOnCompleted(this, new logOnCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void logOnAsync(string email, string password, RSSFeedWeb.AccountService.ClientType clientId) {
            this.logOnAsync(email, password, clientId, null);
        }
        
        public void logOnAsync(string email, string password, RSSFeedWeb.AccountService.ClientType clientId, object userState) {
            if ((this.onBeginlogOnDelegate == null)) {
                this.onBeginlogOnDelegate = new BeginOperationDelegate(this.OnBeginlogOn);
            }
            if ((this.onEndlogOnDelegate == null)) {
                this.onEndlogOnDelegate = new EndOperationDelegate(this.OnEndlogOn);
            }
            if ((this.onlogOnCompletedDelegate == null)) {
                this.onlogOnCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnlogOnCompleted);
            }
            base.InvokeAsync(this.onBeginlogOnDelegate, new object[] {
                        email,
                        password,
                        clientId}, this.onEndlogOnDelegate, this.onlogOnCompletedDelegate, userState);
        }
        
        public bool logOff(string email) {
            return base.Channel.logOff(email);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginlogOff(string email, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginlogOff(email, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndlogOff(System.IAsyncResult result) {
            return base.Channel.EndlogOff(result);
        }
        
        private System.IAsyncResult OnBeginlogOff(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string email = ((string)(inValues[0]));
            return this.BeginlogOff(email, callback, asyncState);
        }
        
        private object[] OnEndlogOff(System.IAsyncResult result) {
            bool retVal = this.EndlogOff(result);
            return new object[] {
                    retVal};
        }
        
        private void OnlogOffCompleted(object state) {
            if ((this.logOffCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.logOffCompleted(this, new logOffCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void logOffAsync(string email) {
            this.logOffAsync(email, null);
        }
        
        public void logOffAsync(string email, object userState) {
            if ((this.onBeginlogOffDelegate == null)) {
                this.onBeginlogOffDelegate = new BeginOperationDelegate(this.OnBeginlogOff);
            }
            if ((this.onEndlogOffDelegate == null)) {
                this.onEndlogOffDelegate = new EndOperationDelegate(this.OnEndlogOff);
            }
            if ((this.onlogOffCompletedDelegate == null)) {
                this.onlogOffCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnlogOffCompleted);
            }
            base.InvokeAsync(this.onBeginlogOffDelegate, new object[] {
                        email}, this.onEndlogOffDelegate, this.onlogOffCompletedDelegate, userState);
        }
        
        public bool Register(string email, string password) {
            return base.Channel.Register(email, password);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginRegister(string email, string password, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginRegister(email, password, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndRegister(System.IAsyncResult result) {
            return base.Channel.EndRegister(result);
        }
        
        private System.IAsyncResult OnBeginRegister(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string email = ((string)(inValues[0]));
            string password = ((string)(inValues[1]));
            return this.BeginRegister(email, password, callback, asyncState);
        }
        
        private object[] OnEndRegister(System.IAsyncResult result) {
            bool retVal = this.EndRegister(result);
            return new object[] {
                    retVal};
        }
        
        private void OnRegisterCompleted(object state) {
            if ((this.RegisterCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.RegisterCompleted(this, new RegisterCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void RegisterAsync(string email, string password) {
            this.RegisterAsync(email, password, null);
        }
        
        public void RegisterAsync(string email, string password, object userState) {
            if ((this.onBeginRegisterDelegate == null)) {
                this.onBeginRegisterDelegate = new BeginOperationDelegate(this.OnBeginRegister);
            }
            if ((this.onEndRegisterDelegate == null)) {
                this.onEndRegisterDelegate = new EndOperationDelegate(this.OnEndRegister);
            }
            if ((this.onRegisterCompletedDelegate == null)) {
                this.onRegisterCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnRegisterCompleted);
            }
            base.InvokeAsync(this.onBeginRegisterDelegate, new object[] {
                        email,
                        password}, this.onEndRegisterDelegate, this.onRegisterCompletedDelegate, userState);
        }
        
        public bool ChangePassword(string email, string password, string newPassword) {
            return base.Channel.ChangePassword(email, password, newPassword);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginChangePassword(string email, string password, string newPassword, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginChangePassword(email, password, newPassword, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndChangePassword(System.IAsyncResult result) {
            return base.Channel.EndChangePassword(result);
        }
        
        private System.IAsyncResult OnBeginChangePassword(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string email = ((string)(inValues[0]));
            string password = ((string)(inValues[1]));
            string newPassword = ((string)(inValues[2]));
            return this.BeginChangePassword(email, password, newPassword, callback, asyncState);
        }
        
        private object[] OnEndChangePassword(System.IAsyncResult result) {
            bool retVal = this.EndChangePassword(result);
            return new object[] {
                    retVal};
        }
        
        private void OnChangePasswordCompleted(object state) {
            if ((this.ChangePasswordCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.ChangePasswordCompleted(this, new ChangePasswordCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void ChangePasswordAsync(string email, string password, string newPassword) {
            this.ChangePasswordAsync(email, password, newPassword, null);
        }
        
        public void ChangePasswordAsync(string email, string password, string newPassword, object userState) {
            if ((this.onBeginChangePasswordDelegate == null)) {
                this.onBeginChangePasswordDelegate = new BeginOperationDelegate(this.OnBeginChangePassword);
            }
            if ((this.onEndChangePasswordDelegate == null)) {
                this.onEndChangePasswordDelegate = new EndOperationDelegate(this.OnEndChangePassword);
            }
            if ((this.onChangePasswordCompletedDelegate == null)) {
                this.onChangePasswordCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnChangePasswordCompleted);
            }
            base.InvokeAsync(this.onBeginChangePasswordDelegate, new object[] {
                        email,
                        password,
                        newPassword}, this.onEndChangePasswordDelegate, this.onChangePasswordCompletedDelegate, userState);
        }
        
        public void ResetPassword() {
            base.Channel.ResetPassword();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginResetPassword(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginResetPassword(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void EndResetPassword(System.IAsyncResult result) {
            base.Channel.EndResetPassword(result);
        }
        
        private System.IAsyncResult OnBeginResetPassword(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginResetPassword(callback, asyncState);
        }
        
        private object[] OnEndResetPassword(System.IAsyncResult result) {
            this.EndResetPassword(result);
            return null;
        }
        
        private void OnResetPasswordCompleted(object state) {
            if ((this.ResetPasswordCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.ResetPasswordCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void ResetPasswordAsync() {
            this.ResetPasswordAsync(null);
        }
        
        public void ResetPasswordAsync(object userState) {
            if ((this.onBeginResetPasswordDelegate == null)) {
                this.onBeginResetPasswordDelegate = new BeginOperationDelegate(this.OnBeginResetPassword);
            }
            if ((this.onEndResetPasswordDelegate == null)) {
                this.onEndResetPasswordDelegate = new EndOperationDelegate(this.OnEndResetPassword);
            }
            if ((this.onResetPasswordCompletedDelegate == null)) {
                this.onResetPasswordCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnResetPasswordCompleted);
            }
            base.InvokeAsync(this.onBeginResetPasswordDelegate, null, this.onEndResetPasswordDelegate, this.onResetPasswordCompletedDelegate, userState);
        }
        
        public bool RegisterConfirmation(string key) {
            return base.Channel.RegisterConfirmation(key);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginRegisterConfirmation(string key, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginRegisterConfirmation(key, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool EndRegisterConfirmation(System.IAsyncResult result) {
            return base.Channel.EndRegisterConfirmation(result);
        }
        
        private System.IAsyncResult OnBeginRegisterConfirmation(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string key = ((string)(inValues[0]));
            return this.BeginRegisterConfirmation(key, callback, asyncState);
        }
        
        private object[] OnEndRegisterConfirmation(System.IAsyncResult result) {
            bool retVal = this.EndRegisterConfirmation(result);
            return new object[] {
                    retVal};
        }
        
        private void OnRegisterConfirmationCompleted(object state) {
            if ((this.RegisterConfirmationCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.RegisterConfirmationCompleted(this, new RegisterConfirmationCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void RegisterConfirmationAsync(string key) {
            this.RegisterConfirmationAsync(key, null);
        }
        
        public void RegisterConfirmationAsync(string key, object userState) {
            if ((this.onBeginRegisterConfirmationDelegate == null)) {
                this.onBeginRegisterConfirmationDelegate = new BeginOperationDelegate(this.OnBeginRegisterConfirmation);
            }
            if ((this.onEndRegisterConfirmationDelegate == null)) {
                this.onEndRegisterConfirmationDelegate = new EndOperationDelegate(this.OnEndRegisterConfirmation);
            }
            if ((this.onRegisterConfirmationCompletedDelegate == null)) {
                this.onRegisterConfirmationCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnRegisterConfirmationCompleted);
            }
            base.InvokeAsync(this.onBeginRegisterConfirmationDelegate, new object[] {
                        key}, this.onEndRegisterConfirmationDelegate, this.onRegisterConfirmationCompletedDelegate, userState);
        }
    }
}
