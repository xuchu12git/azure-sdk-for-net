// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Response for ListLoadBalancers API service call. </summary>
    public partial class LoadBalancerListResult
    {
        /// <summary> Initializes a new instance of LoadBalancerListResult. </summary>
        internal LoadBalancerListResult()
        {
        }

        /// <summary> Initializes a new instance of LoadBalancerListResult. </summary>
        /// <param name="value"> A list of load balancers in a resource group. </param>
        /// <param name="nextLink"> The URL to get the next set of results. </param>
        internal LoadBalancerListResult(IReadOnlyList<LoadBalancer> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> A list of load balancers in a resource group. </summary>
        public IReadOnlyList<LoadBalancer> Value { get; }
        /// <summary> The URL to get the next set of results. </summary>
        public string NextLink { get; }
    }
}
