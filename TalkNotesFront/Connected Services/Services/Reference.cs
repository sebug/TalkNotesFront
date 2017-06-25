﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TalkNotesFront.Services {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TalkNote", Namespace="http://schemas.datacontract.org/2004/07/TalkNotesBack")]
    [System.SerializableAttribute()]
    public partial class TalkNote : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BodyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TalkNoteIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Body {
            get {
                return this.BodyField;
            }
            set {
                if ((object.ReferenceEquals(this.BodyField, value) != true)) {
                    this.BodyField = value;
                    this.RaisePropertyChanged("Body");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TalkNoteID {
            get {
                return this.TalkNoteIDField;
            }
            set {
                if ((this.TalkNoteIDField.Equals(value) != true)) {
                    this.TalkNoteIDField = value;
                    this.RaisePropertyChanged("TalkNoteID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Services.ITalkNoteService")]
    public interface ITalkNoteService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITalkNoteService/GetTalkNoteByID", ReplyAction="http://tempuri.org/ITalkNoteService/GetTalkNoteByIDResponse")]
        TalkNotesFront.Services.TalkNote GetTalkNoteByID(int talkNoteID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITalkNoteService/GetTalkNoteByID", ReplyAction="http://tempuri.org/ITalkNoteService/GetTalkNoteByIDResponse")]
        System.Threading.Tasks.Task<TalkNotesFront.Services.TalkNote> GetTalkNoteByIDAsync(int talkNoteID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITalkNoteService/GetAll", ReplyAction="http://tempuri.org/ITalkNoteService/GetAllResponse")]
        TalkNotesFront.Services.TalkNote[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITalkNoteService/GetAll", ReplyAction="http://tempuri.org/ITalkNoteService/GetAllResponse")]
        System.Threading.Tasks.Task<TalkNotesFront.Services.TalkNote[]> GetAllAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITalkNoteServiceChannel : TalkNotesFront.Services.ITalkNoteService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TalkNoteServiceClient : System.ServiceModel.ClientBase<TalkNotesFront.Services.ITalkNoteService>, TalkNotesFront.Services.ITalkNoteService {
        
        public TalkNoteServiceClient() {
        }
        
        public TalkNoteServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TalkNoteServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TalkNoteServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TalkNoteServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public TalkNotesFront.Services.TalkNote GetTalkNoteByID(int talkNoteID) {
            return base.Channel.GetTalkNoteByID(talkNoteID);
        }
        
        public System.Threading.Tasks.Task<TalkNotesFront.Services.TalkNote> GetTalkNoteByIDAsync(int talkNoteID) {
            return base.Channel.GetTalkNoteByIDAsync(talkNoteID);
        }
        
        public TalkNotesFront.Services.TalkNote[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<TalkNotesFront.Services.TalkNote[]> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
    }
}