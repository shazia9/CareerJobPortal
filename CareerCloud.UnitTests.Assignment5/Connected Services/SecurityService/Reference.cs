﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CareerCloud.UnitTests.Assignment5.SecurityService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SecurityService.ISecurity")]
    public interface ISecurity {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/AddSecurityLogin", ReplyAction="http://tempuri.org/ISecurity/AddSecurityLoginResponse")]
        void AddSecurityLogin(CareerCloud.Pocos.SecurityLoginPoco[] items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/AddSecurityLogin", ReplyAction="http://tempuri.org/ISecurity/AddSecurityLoginResponse")]
        System.Threading.Tasks.Task AddSecurityLoginAsync(CareerCloud.Pocos.SecurityLoginPoco[] items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/GetAllSecurityLogin", ReplyAction="http://tempuri.org/ISecurity/GetAllSecurityLoginResponse")]
        CareerCloud.Pocos.SecurityLoginPoco[] GetAllSecurityLogin();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/GetAllSecurityLogin", ReplyAction="http://tempuri.org/ISecurity/GetAllSecurityLoginResponse")]
        System.Threading.Tasks.Task<CareerCloud.Pocos.SecurityLoginPoco[]> GetAllSecurityLoginAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/GetSingleSecurityLogin", ReplyAction="http://tempuri.org/ISecurity/GetSingleSecurityLoginResponse")]
        CareerCloud.Pocos.SecurityLoginPoco GetSingleSecurityLogin(string Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/GetSingleSecurityLogin", ReplyAction="http://tempuri.org/ISecurity/GetSingleSecurityLoginResponse")]
        System.Threading.Tasks.Task<CareerCloud.Pocos.SecurityLoginPoco> GetSingleSecurityLoginAsync(string Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/RemoveSecurityLogin", ReplyAction="http://tempuri.org/ISecurity/RemoveSecurityLoginResponse")]
        void RemoveSecurityLogin(CareerCloud.Pocos.SecurityLoginPoco[] items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/RemoveSecurityLogin", ReplyAction="http://tempuri.org/ISecurity/RemoveSecurityLoginResponse")]
        System.Threading.Tasks.Task RemoveSecurityLoginAsync(CareerCloud.Pocos.SecurityLoginPoco[] items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/UpdateSecurityLogin", ReplyAction="http://tempuri.org/ISecurity/UpdateSecurityLoginResponse")]
        void UpdateSecurityLogin(CareerCloud.Pocos.SecurityLoginPoco[] items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/UpdateSecurityLogin", ReplyAction="http://tempuri.org/ISecurity/UpdateSecurityLoginResponse")]
        System.Threading.Tasks.Task UpdateSecurityLoginAsync(CareerCloud.Pocos.SecurityLoginPoco[] items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/AddSecurityLoginsLog", ReplyAction="http://tempuri.org/ISecurity/AddSecurityLoginsLogResponse")]
        void AddSecurityLoginsLog(CareerCloud.Pocos.SecurityLoginsLogPoco[] items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/AddSecurityLoginsLog", ReplyAction="http://tempuri.org/ISecurity/AddSecurityLoginsLogResponse")]
        System.Threading.Tasks.Task AddSecurityLoginsLogAsync(CareerCloud.Pocos.SecurityLoginsLogPoco[] items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/GetAllSecurityLoginsLog", ReplyAction="http://tempuri.org/ISecurity/GetAllSecurityLoginsLogResponse")]
        CareerCloud.Pocos.SecurityLoginsLogPoco[] GetAllSecurityLoginsLog();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/GetAllSecurityLoginsLog", ReplyAction="http://tempuri.org/ISecurity/GetAllSecurityLoginsLogResponse")]
        System.Threading.Tasks.Task<CareerCloud.Pocos.SecurityLoginsLogPoco[]> GetAllSecurityLoginsLogAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/GetSingleSecurityLoginsLog", ReplyAction="http://tempuri.org/ISecurity/GetSingleSecurityLoginsLogResponse")]
        CareerCloud.Pocos.SecurityLoginsLogPoco GetSingleSecurityLoginsLog(string Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/GetSingleSecurityLoginsLog", ReplyAction="http://tempuri.org/ISecurity/GetSingleSecurityLoginsLogResponse")]
        System.Threading.Tasks.Task<CareerCloud.Pocos.SecurityLoginsLogPoco> GetSingleSecurityLoginsLogAsync(string Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/RemoveSecurityLoginsLog", ReplyAction="http://tempuri.org/ISecurity/RemoveSecurityLoginsLogResponse")]
        void RemoveSecurityLoginsLog(CareerCloud.Pocos.SecurityLoginsLogPoco[] items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/RemoveSecurityLoginsLog", ReplyAction="http://tempuri.org/ISecurity/RemoveSecurityLoginsLogResponse")]
        System.Threading.Tasks.Task RemoveSecurityLoginsLogAsync(CareerCloud.Pocos.SecurityLoginsLogPoco[] items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/UpdateSecurityLoginsLog", ReplyAction="http://tempuri.org/ISecurity/UpdateSecurityLoginsLogResponse")]
        void UpdateSecurityLoginsLog(CareerCloud.Pocos.SecurityLoginsLogPoco[] items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/UpdateSecurityLoginsLog", ReplyAction="http://tempuri.org/ISecurity/UpdateSecurityLoginsLogResponse")]
        System.Threading.Tasks.Task UpdateSecurityLoginsLogAsync(CareerCloud.Pocos.SecurityLoginsLogPoco[] items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/AddSecurityLoginsRole", ReplyAction="http://tempuri.org/ISecurity/AddSecurityLoginsRoleResponse")]
        void AddSecurityLoginsRole(CareerCloud.Pocos.SecurityLoginsRolePoco[] items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/AddSecurityLoginsRole", ReplyAction="http://tempuri.org/ISecurity/AddSecurityLoginsRoleResponse")]
        System.Threading.Tasks.Task AddSecurityLoginsRoleAsync(CareerCloud.Pocos.SecurityLoginsRolePoco[] items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/GetAllSecurityLoginsRole", ReplyAction="http://tempuri.org/ISecurity/GetAllSecurityLoginsRoleResponse")]
        CareerCloud.Pocos.SecurityLoginsRolePoco[] GetAllSecurityLoginsRole();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/GetAllSecurityLoginsRole", ReplyAction="http://tempuri.org/ISecurity/GetAllSecurityLoginsRoleResponse")]
        System.Threading.Tasks.Task<CareerCloud.Pocos.SecurityLoginsRolePoco[]> GetAllSecurityLoginsRoleAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/GetSingleSecurityLoginsRole", ReplyAction="http://tempuri.org/ISecurity/GetSingleSecurityLoginsRoleResponse")]
        CareerCloud.Pocos.SecurityLoginsRolePoco GetSingleSecurityLoginsRole(string Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/GetSingleSecurityLoginsRole", ReplyAction="http://tempuri.org/ISecurity/GetSingleSecurityLoginsRoleResponse")]
        System.Threading.Tasks.Task<CareerCloud.Pocos.SecurityLoginsRolePoco> GetSingleSecurityLoginsRoleAsync(string Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/RemoveSecurityLoginsRole", ReplyAction="http://tempuri.org/ISecurity/RemoveSecurityLoginsRoleResponse")]
        void RemoveSecurityLoginsRole(CareerCloud.Pocos.SecurityLoginsRolePoco[] items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/RemoveSecurityLoginsRole", ReplyAction="http://tempuri.org/ISecurity/RemoveSecurityLoginsRoleResponse")]
        System.Threading.Tasks.Task RemoveSecurityLoginsRoleAsync(CareerCloud.Pocos.SecurityLoginsRolePoco[] items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/UpdateSecurityLoginsRole", ReplyAction="http://tempuri.org/ISecurity/UpdateSecurityLoginsRoleResponse")]
        void UpdateSecurityLoginsRole(CareerCloud.Pocos.SecurityLoginsRolePoco[] items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/UpdateSecurityLoginsRole", ReplyAction="http://tempuri.org/ISecurity/UpdateSecurityLoginsRoleResponse")]
        System.Threading.Tasks.Task UpdateSecurityLoginsRoleAsync(CareerCloud.Pocos.SecurityLoginsRolePoco[] items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/AddSecurityRole", ReplyAction="http://tempuri.org/ISecurity/AddSecurityRoleResponse")]
        void AddSecurityRole(CareerCloud.Pocos.SecurityRolePoco[] items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/AddSecurityRole", ReplyAction="http://tempuri.org/ISecurity/AddSecurityRoleResponse")]
        System.Threading.Tasks.Task AddSecurityRoleAsync(CareerCloud.Pocos.SecurityRolePoco[] items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/GetAllSecurityRole", ReplyAction="http://tempuri.org/ISecurity/GetAllSecurityRoleResponse")]
        CareerCloud.Pocos.SecurityRolePoco[] GetAllSecurityRole();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/GetAllSecurityRole", ReplyAction="http://tempuri.org/ISecurity/GetAllSecurityRoleResponse")]
        System.Threading.Tasks.Task<CareerCloud.Pocos.SecurityRolePoco[]> GetAllSecurityRoleAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/GetSingleSecurityRole", ReplyAction="http://tempuri.org/ISecurity/GetSingleSecurityRoleResponse")]
        CareerCloud.Pocos.SecurityRolePoco GetSingleSecurityRole(string Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/GetSingleSecurityRole", ReplyAction="http://tempuri.org/ISecurity/GetSingleSecurityRoleResponse")]
        System.Threading.Tasks.Task<CareerCloud.Pocos.SecurityRolePoco> GetSingleSecurityRoleAsync(string Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/RemoveSecurityRole", ReplyAction="http://tempuri.org/ISecurity/RemoveSecurityRoleResponse")]
        void RemoveSecurityRole(CareerCloud.Pocos.SecurityRolePoco[] items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/RemoveSecurityRole", ReplyAction="http://tempuri.org/ISecurity/RemoveSecurityRoleResponse")]
        System.Threading.Tasks.Task RemoveSecurityRoleAsync(CareerCloud.Pocos.SecurityRolePoco[] items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/UpdateSecurityRole", ReplyAction="http://tempuri.org/ISecurity/UpdateSecurityRoleResponse")]
        void UpdateSecurityRole(CareerCloud.Pocos.SecurityRolePoco[] items);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecurity/UpdateSecurityRole", ReplyAction="http://tempuri.org/ISecurity/UpdateSecurityRoleResponse")]
        System.Threading.Tasks.Task UpdateSecurityRoleAsync(CareerCloud.Pocos.SecurityRolePoco[] items);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISecurityChannel : CareerCloud.UnitTests.Assignment5.SecurityService.ISecurity, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SecurityClient : System.ServiceModel.ClientBase<CareerCloud.UnitTests.Assignment5.SecurityService.ISecurity>, CareerCloud.UnitTests.Assignment5.SecurityService.ISecurity {
        
        public SecurityClient() {
        }
        
        public SecurityClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SecurityClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SecurityClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SecurityClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AddSecurityLogin(CareerCloud.Pocos.SecurityLoginPoco[] items) {
            base.Channel.AddSecurityLogin(items);
        }
        
        public System.Threading.Tasks.Task AddSecurityLoginAsync(CareerCloud.Pocos.SecurityLoginPoco[] items) {
            return base.Channel.AddSecurityLoginAsync(items);
        }
        
        public CareerCloud.Pocos.SecurityLoginPoco[] GetAllSecurityLogin() {
            return base.Channel.GetAllSecurityLogin();
        }
        
        public System.Threading.Tasks.Task<CareerCloud.Pocos.SecurityLoginPoco[]> GetAllSecurityLoginAsync() {
            return base.Channel.GetAllSecurityLoginAsync();
        }
        
        public CareerCloud.Pocos.SecurityLoginPoco GetSingleSecurityLogin(string Id) {
            return base.Channel.GetSingleSecurityLogin(Id);
        }
        
        public System.Threading.Tasks.Task<CareerCloud.Pocos.SecurityLoginPoco> GetSingleSecurityLoginAsync(string Id) {
            return base.Channel.GetSingleSecurityLoginAsync(Id);
        }
        
        public void RemoveSecurityLogin(CareerCloud.Pocos.SecurityLoginPoco[] items) {
            base.Channel.RemoveSecurityLogin(items);
        }
        
        public System.Threading.Tasks.Task RemoveSecurityLoginAsync(CareerCloud.Pocos.SecurityLoginPoco[] items) {
            return base.Channel.RemoveSecurityLoginAsync(items);
        }
        
        public void UpdateSecurityLogin(CareerCloud.Pocos.SecurityLoginPoco[] items) {
            base.Channel.UpdateSecurityLogin(items);
        }
        
        public System.Threading.Tasks.Task UpdateSecurityLoginAsync(CareerCloud.Pocos.SecurityLoginPoco[] items) {
            return base.Channel.UpdateSecurityLoginAsync(items);
        }
        
        public void AddSecurityLoginsLog(CareerCloud.Pocos.SecurityLoginsLogPoco[] items) {
            base.Channel.AddSecurityLoginsLog(items);
        }
        
        public System.Threading.Tasks.Task AddSecurityLoginsLogAsync(CareerCloud.Pocos.SecurityLoginsLogPoco[] items) {
            return base.Channel.AddSecurityLoginsLogAsync(items);
        }
        
        public CareerCloud.Pocos.SecurityLoginsLogPoco[] GetAllSecurityLoginsLog() {
            return base.Channel.GetAllSecurityLoginsLog();
        }
        
        public System.Threading.Tasks.Task<CareerCloud.Pocos.SecurityLoginsLogPoco[]> GetAllSecurityLoginsLogAsync() {
            return base.Channel.GetAllSecurityLoginsLogAsync();
        }
        
        public CareerCloud.Pocos.SecurityLoginsLogPoco GetSingleSecurityLoginsLog(string Id) {
            return base.Channel.GetSingleSecurityLoginsLog(Id);
        }
        
        public System.Threading.Tasks.Task<CareerCloud.Pocos.SecurityLoginsLogPoco> GetSingleSecurityLoginsLogAsync(string Id) {
            return base.Channel.GetSingleSecurityLoginsLogAsync(Id);
        }
        
        public void RemoveSecurityLoginsLog(CareerCloud.Pocos.SecurityLoginsLogPoco[] items) {
            base.Channel.RemoveSecurityLoginsLog(items);
        }
        
        public System.Threading.Tasks.Task RemoveSecurityLoginsLogAsync(CareerCloud.Pocos.SecurityLoginsLogPoco[] items) {
            return base.Channel.RemoveSecurityLoginsLogAsync(items);
        }
        
        public void UpdateSecurityLoginsLog(CareerCloud.Pocos.SecurityLoginsLogPoco[] items) {
            base.Channel.UpdateSecurityLoginsLog(items);
        }
        
        public System.Threading.Tasks.Task UpdateSecurityLoginsLogAsync(CareerCloud.Pocos.SecurityLoginsLogPoco[] items) {
            return base.Channel.UpdateSecurityLoginsLogAsync(items);
        }
        
        public void AddSecurityLoginsRole(CareerCloud.Pocos.SecurityLoginsRolePoco[] items) {
            base.Channel.AddSecurityLoginsRole(items);
        }
        
        public System.Threading.Tasks.Task AddSecurityLoginsRoleAsync(CareerCloud.Pocos.SecurityLoginsRolePoco[] items) {
            return base.Channel.AddSecurityLoginsRoleAsync(items);
        }
        
        public CareerCloud.Pocos.SecurityLoginsRolePoco[] GetAllSecurityLoginsRole() {
            return base.Channel.GetAllSecurityLoginsRole();
        }
        
        public System.Threading.Tasks.Task<CareerCloud.Pocos.SecurityLoginsRolePoco[]> GetAllSecurityLoginsRoleAsync() {
            return base.Channel.GetAllSecurityLoginsRoleAsync();
        }
        
        public CareerCloud.Pocos.SecurityLoginsRolePoco GetSingleSecurityLoginsRole(string Id) {
            return base.Channel.GetSingleSecurityLoginsRole(Id);
        }
        
        public System.Threading.Tasks.Task<CareerCloud.Pocos.SecurityLoginsRolePoco> GetSingleSecurityLoginsRoleAsync(string Id) {
            return base.Channel.GetSingleSecurityLoginsRoleAsync(Id);
        }
        
        public void RemoveSecurityLoginsRole(CareerCloud.Pocos.SecurityLoginsRolePoco[] items) {
            base.Channel.RemoveSecurityLoginsRole(items);
        }
        
        public System.Threading.Tasks.Task RemoveSecurityLoginsRoleAsync(CareerCloud.Pocos.SecurityLoginsRolePoco[] items) {
            return base.Channel.RemoveSecurityLoginsRoleAsync(items);
        }
        
        public void UpdateSecurityLoginsRole(CareerCloud.Pocos.SecurityLoginsRolePoco[] items) {
            base.Channel.UpdateSecurityLoginsRole(items);
        }
        
        public System.Threading.Tasks.Task UpdateSecurityLoginsRoleAsync(CareerCloud.Pocos.SecurityLoginsRolePoco[] items) {
            return base.Channel.UpdateSecurityLoginsRoleAsync(items);
        }
        
        public void AddSecurityRole(CareerCloud.Pocos.SecurityRolePoco[] items) {
            base.Channel.AddSecurityRole(items);
        }
        
        public System.Threading.Tasks.Task AddSecurityRoleAsync(CareerCloud.Pocos.SecurityRolePoco[] items) {
            return base.Channel.AddSecurityRoleAsync(items);
        }
        
        public CareerCloud.Pocos.SecurityRolePoco[] GetAllSecurityRole() {
            return base.Channel.GetAllSecurityRole();
        }
        
        public System.Threading.Tasks.Task<CareerCloud.Pocos.SecurityRolePoco[]> GetAllSecurityRoleAsync() {
            return base.Channel.GetAllSecurityRoleAsync();
        }
        
        public CareerCloud.Pocos.SecurityRolePoco GetSingleSecurityRole(string Id) {
            return base.Channel.GetSingleSecurityRole(Id);
        }
        
        public System.Threading.Tasks.Task<CareerCloud.Pocos.SecurityRolePoco> GetSingleSecurityRoleAsync(string Id) {
            return base.Channel.GetSingleSecurityRoleAsync(Id);
        }
        
        public void RemoveSecurityRole(CareerCloud.Pocos.SecurityRolePoco[] items) {
            base.Channel.RemoveSecurityRole(items);
        }
        
        public System.Threading.Tasks.Task RemoveSecurityRoleAsync(CareerCloud.Pocos.SecurityRolePoco[] items) {
            return base.Channel.RemoveSecurityRoleAsync(items);
        }
        
        public void UpdateSecurityRole(CareerCloud.Pocos.SecurityRolePoco[] items) {
            base.Channel.UpdateSecurityRole(items);
        }
        
        public System.Threading.Tasks.Task UpdateSecurityRoleAsync(CareerCloud.Pocos.SecurityRolePoco[] items) {
            return base.Channel.UpdateSecurityRoleAsync(items);
        }
    }
}
