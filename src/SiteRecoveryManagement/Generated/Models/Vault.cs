// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Common.Internals;
using Microsoft.WindowsAzure.Management.RecoveryServices.Models;

namespace Microsoft.WindowsAzure.Management.RecoveryServices.Models
{
    /// <summary>
    /// SRS Resource : Vault
    /// </summary>
    public partial class Vault
    {
        private string _eTag;
        
        /// <summary>
        /// Optional. ETag.
        /// </summary>
        public string ETag
        {
            get { return this._eTag; }
            set { this._eTag = value; }
        }
        
        private string _label;
        
        /// <summary>
        /// Optional. Label for the resource
        /// </summary>
        public string Label
        {
            get { return this._label; }
            set { this._label = value; }
        }
        
        private string _name;
        
        /// <summary>
        /// Optional. Name of the vault
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        
        private ResourceOperationStatus _operationStatus;
        
        /// <summary>
        /// Optional. Operation Status for the operation for the resource
        /// </summary>
        public ResourceOperationStatus OperationStatus
        {
            get { return this._operationStatus; }
            set { this._operationStatus = value; }
        }
        
        private IList<OutputItem> _outputItems;
        
        /// <summary>
        /// Optional. List of OutputItems, key value paired properties
        /// </summary>
        public IList<OutputItem> OutputItems
        {
            get { return this._outputItems; }
            set { this._outputItems = value; }
        }
        
        private string _plan;
        
        /// <summary>
        /// Optional. Plan
        /// </summary>
        public string Plan
        {
            get { return this._plan; }
            set { this._plan = value; }
        }
        
        private string _resourceProviderNamespace;
        
        /// <summary>
        /// Optional. Namespace of the Resource Provider
        /// </summary>
        public string ResourceProviderNamespace
        {
            get { return this._resourceProviderNamespace; }
            set { this._resourceProviderNamespace = value; }
        }
        
        private string _schemaVersion;
        
        /// <summary>
        /// Optional. SchemaVersion for the resource
        /// </summary>
        public string SchemaVersion
        {
            get { return this._schemaVersion; }
            set { this._schemaVersion = value; }
        }
        
        private string _state;
        
        /// <summary>
        /// Optional. State of the resource
        /// </summary>
        public string State
        {
            get { return this._state; }
            set { this._state = value; }
        }
        
        private string _subState;
        
        /// <summary>
        /// Optional. SubState of the resource
        /// </summary>
        public string SubState
        {
            get { return this._subState; }
            set { this._subState = value; }
        }
        
        private string _type;
        
        /// <summary>
        /// Optional. Type of the resource
        /// </summary>
        public string Type
        {
            get { return this._type; }
            set { this._type = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the Vault class.
        /// </summary>
        public Vault()
        {
            this.OutputItems = new LazyList<OutputItem>();
        }
    }
}
