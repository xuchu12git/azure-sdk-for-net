// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.FrontDoor.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the properties of a preconfigured endpoint
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class PreconfiguredEndpoint : Resource
    {
        /// <summary>
        /// Initializes a new instance of the PreconfiguredEndpoint class.
        /// </summary>
        public PreconfiguredEndpoint()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PreconfiguredEndpoint class.
        /// </summary>
        /// <param name="id">Resource ID.</param>
        /// <param name="name">Resource name.</param>
        /// <param name="type">Resource type.</param>
        /// <param name="location">Resource location.</param>
        /// <param name="tags">Resource tags.</param>
        /// <param name="description">The description of the endpoint</param>
        /// <param name="endpoint">The endpoint that is preconfigured</param>
        /// <param name="endpointType">The type of endpoint. Possible values
        /// include: 'AFD', 'AzureRegion', 'CDN', 'ATM'</param>
        /// <param name="backend">The preconfigured endpoint backend</param>
        public PreconfiguredEndpoint(string id = default(string), string name = default(string), string type = default(string), string location = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), string description = default(string), string endpoint = default(string), string endpointType = default(string), string backend = default(string))
            : base(id, name, type, location, tags)
        {
            Description = description;
            Endpoint = endpoint;
            EndpointType = endpointType;
            Backend = backend;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the description of the endpoint
        /// </summary>
        [JsonProperty(PropertyName = "properties.description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the endpoint that is preconfigured
        /// </summary>
        [JsonProperty(PropertyName = "properties.endpoint")]
        public string Endpoint { get; set; }

        /// <summary>
        /// Gets or sets the type of endpoint. Possible values include: 'AFD',
        /// 'AzureRegion', 'CDN', 'ATM'
        /// </summary>
        [JsonProperty(PropertyName = "properties.endpointType")]
        public string EndpointType { get; set; }

        /// <summary>
        /// Gets or sets the preconfigured endpoint backend
        /// </summary>
        [JsonProperty(PropertyName = "properties.backend")]
        public string Backend { get; set; }

    }
}