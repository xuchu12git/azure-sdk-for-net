// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.Management.Network.Models
{
    /// <summary> Stop packet capture parameters. </summary>
    public partial class VpnPacketCaptureStopParameters
    {
        /// <summary> Initializes a new instance of VpnPacketCaptureStopParameters. </summary>
        public VpnPacketCaptureStopParameters()
        {
        }

        /// <summary> Initializes a new instance of VpnPacketCaptureStopParameters. </summary>
        /// <param name="sasUrl"> SAS url for packet capture on virtual network gateway. </param>
        internal VpnPacketCaptureStopParameters(string sasUrl)
        {
            SasUrl = sasUrl;
        }

        /// <summary> SAS url for packet capture on virtual network gateway. </summary>
        public string SasUrl { get; set; }
    }
}
