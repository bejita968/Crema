﻿//Released under the MIT License.
//
//Copyright (c) 2018 Ntreev Soft co., Ltd.
//
//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
//documentation files (the "Software"), to deal in the Software without restriction, including without limitation the 
//rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit 
//persons to whom the Software is furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all copies or substantial portions of the 
//Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE 
//WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR 
//COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR 
//OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ntreev.Crema.RuntimeService.ServiceClient {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.ntreev.com", ConfigurationName="ServiceClient.IRuntimeService")]
    internal interface IRuntimeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IRuntimeService/GetCodeGenerationData", ReplyAction="http://www.ntreev.com/IRuntimeService/GetCodeGenerationDataResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.Runtime.Generation.GenerationSet> GetCodeGenerationData(string dataBaseName, string tags, string filterExpression, long revision);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IRuntimeService/GetDataGenerationData", ReplyAction="http://www.ntreev.com/IRuntimeService/GetDataGenerationDataResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.Runtime.Serialization.SerializationSet> GetDataGenerationData(string dataBaseName, string tags, string filterExpression, bool isDevmode, long revision);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IRuntimeService/GetMetaData", ReplyAction="http://www.ntreev.com/IRuntimeService/GetMetaDataResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.Runtime.Generation.GenerationSet, Ntreev.Crema.Runtime.Serialization.SerializationSet> GetMetaData(string dataBaseName, string tags, string filterExpression, bool isDevmode, long revision);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IRuntimeService/ResetData", ReplyAction="http://www.ntreev.com/IRuntimeService/ResetDataResponse")]
        Ntreev.Crema.ServiceModel.ResultBase ResetData(string dataBaseName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ntreev.com/IRuntimeService/GetRevision", ReplyAction="http://www.ntreev.com/IRuntimeService/GetRevisionResponse")]
        Ntreev.Crema.ServiceModel.ResultBase<long> GetRevision(string dataBaseName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    internal interface IRuntimeServiceChannel : Ntreev.Crema.RuntimeService.ServiceClient.IRuntimeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    internal partial class RuntimeServiceClient : System.ServiceModel.ClientBase<Ntreev.Crema.RuntimeService.ServiceClient.IRuntimeService>, Ntreev.Crema.RuntimeService.ServiceClient.IRuntimeService {
        
        public RuntimeServiceClient() {
        }
        
        public RuntimeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RuntimeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RuntimeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RuntimeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.Runtime.Generation.GenerationSet> GetCodeGenerationData(string dataBaseName, string tags, string filterExpression, long revision) {
            return base.Channel.GetCodeGenerationData(dataBaseName, tags, filterExpression, revision);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.Runtime.Serialization.SerializationSet> GetDataGenerationData(string dataBaseName, string tags, string filterExpression, bool isDevmode, long revision) {
            return base.Channel.GetDataGenerationData(dataBaseName, tags, filterExpression, isDevmode, revision);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<Ntreev.Crema.Runtime.Generation.GenerationSet, Ntreev.Crema.Runtime.Serialization.SerializationSet> GetMetaData(string dataBaseName, string tags, string filterExpression, bool isDevmode, long revision) {
            return base.Channel.GetMetaData(dataBaseName, tags, filterExpression, isDevmode, revision);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase ResetData(string dataBaseName) {
            return base.Channel.ResetData(dataBaseName);
        }
        
        public Ntreev.Crema.ServiceModel.ResultBase<long> GetRevision(string dataBaseName) {
            return base.Channel.GetRevision(dataBaseName);
        }
    }
}