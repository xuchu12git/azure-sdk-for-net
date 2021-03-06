﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Messaging.ServiceBus.Management
{
    /// <summary>
    /// Represents the metadata description of the topic.
    /// </summary>
    public class TopicDescription : IEquatable<TopicDescription>
    {
        private TimeSpan _duplicateDetectionHistoryTimeWindow = TimeSpan.FromMinutes(1);
        private string _name;
        private TimeSpan _defaultMessageTimeToLive = TimeSpan.MaxValue;
        private TimeSpan _autoDeleteOnIdle = TimeSpan.MaxValue;
        private string _userMetadata = null;

        /// <summary>
        /// Initializes a new instance of TopicDescription class with the specified relative name.
        /// </summary>
        /// <param name="name">Name of the topic relative to the namespace base address.</param>
        public TopicDescription(string name)
        {
            Name = name;
        }

        /// <summary>
        /// The default time to live value for the messages. This is the duration after which the message expires, starting from when
        /// the message is sent to Service Bus. </summary>
        /// <remarks>
        /// This is the default value used when <see cref="ServiceBusMessage.TimeToLive"/> is not set on a
        ///  message itself. Messages older than their TimeToLive value will expire and no longer be retained in the message store.
        ///  Subscribers will be unable to receive expired messages.
        ///  Default value is <see cref="TimeSpan.MaxValue"/>.
        ///  </remarks>
        public TimeSpan DefaultMessageTimeToLive
        {
            get => _defaultMessageTimeToLive;
            set
            {
                Argument.AssertInRange(
                    value,
                    ManagementClientConstants.MinimumAllowedTimeToLive,
                    ManagementClientConstants.MaximumAllowedTimeToLive,
                    nameof(DefaultMessageTimeToLive));

                _defaultMessageTimeToLive = value;
            }
        }

        /// <summary>
        /// The <see cref="TimeSpan"/> idle interval after which the topic is automatically deleted.
        /// </summary>
        /// <remarks>The minimum duration is 5 minutes. Default value is <see cref="TimeSpan.MaxValue"/>.</remarks>
        public TimeSpan AutoDeleteOnIdle
        {
            get => _autoDeleteOnIdle;
            set
            {
                Argument.AssertAtLeast(
                    value,
                    ManagementClientConstants.MinimumAllowedAutoDeleteOnIdle,
                    nameof(AutoDeleteOnIdle));

                _autoDeleteOnIdle = value;
            }
        }

        /// <summary>
        /// The maximum size of the topic in megabytes, which is the size of memory allocated for the topic.
        /// </summary>
        /// <remarks>Default value is 1024.</remarks>
        public long MaxSizeInMegabytes { get; set; } = 1024;

        /// <summary>
        /// This value indicates if the topic requires guard against duplicate messages. If true, duplicate messages having same
        /// <see cref="ServiceBusMessage.MessageId"/> and sent to topic within duration of <see cref="DuplicateDetectionHistoryTimeWindow"/>
        /// will be discarded.
        /// </summary>
        /// <remarks>Defaults to false.</remarks>
        public bool RequiresDuplicateDetection { get; set; } = false;

        /// <summary>
        /// The <see cref="TimeSpan"/> duration of duplicate detection history that is maintained by the service.
        /// </summary>
        /// <remarks>
        /// The default value is 1 minute. Max value is 7 days and minimum is 20 seconds.
        /// </remarks>
        public TimeSpan DuplicateDetectionHistoryTimeWindow
        {
            get => _duplicateDetectionHistoryTimeWindow;
            set
            {
                Argument.AssertInRange(
                    value,
                    ManagementClientConstants.MinimumDuplicateDetectionHistoryTimeWindow,
                    ManagementClientConstants.MaximumDuplicateDetectionHistoryTimeWindow,
                    nameof(DuplicateDetectionHistoryTimeWindow));

                _duplicateDetectionHistoryTimeWindow = value;
            }
        }

        /// <summary>
        /// Name of the topic relative to the namespace base address.
        /// </summary>
        /// <remarks>Max length is 260 chars. Cannot start or end with a slash.
        /// Cannot have restricted characters: '@','?','#','*'</remarks>
        public string Name
        {
            get => _name;
            set
            {
                EntityNameFormatter.CheckValidTopicName(value, nameof(Name));
                _name = value;
            }
        }

        /// <summary>
        /// The <see cref="AuthorizationRules"/> on the topic to control user access at entity level.
        /// </summary>
        public AuthorizationRules AuthorizationRules { get; internal set; } = new AuthorizationRules();

        /// <summary>
        /// The current status of the topic (Enabled / Disabled).
        /// </summary>
        /// <remarks>When an entity is disabled, that entity cannot send or receive messages.</remarks>
        public EntityStatus Status { get; set; } = EntityStatus.Active;

        /// <summary>
        /// Indicates whether the topic is to be partitioned across multiple message brokers.
        /// </summary>
        /// <remarks>Defaults to false.</remarks>
        public bool EnablePartitioning { get; set; } = false;

        /// <summary>
        /// Defines whether ordering needs to be maintained. If true, messages sent to topic will be
        /// forwarded to the subscription in order.
        /// </summary>
        /// <remarks>Defaults to false.</remarks>
        public bool SupportOrdering { get; set; } = false;

        /// <summary>
        /// Indicates whether server-side batched operations are enabled.
        /// </summary>
        /// <remarks>Defaults to true.</remarks>
        public bool EnableBatchedOperations { get; set; } = true;

        /// <summary>
        /// Custom metdata that user can associate with the description.
        /// </summary>
        /// <remarks>Cannot be null. Max length is 1024 chars.</remarks>
        public string UserMetadata
        {
            get => _userMetadata;
            set
            {
                Argument.AssertNotNull(value, nameof(UserMetadata));
                Argument.AssertNotTooLong(
                    value,
                    ManagementClientConstants.MaxUserMetadataLength,
                    nameof(UserMetadata));

                _userMetadata = value;
            }
        }

        /// <summary>
        /// List of properties that were retrieved using GetTopic but are not understood by this version of client is stored here.
        /// The list will be sent back when an already retrieved TopicDescription will be used in UpdateTopic call.
        /// </summary>
        internal List<object> UnknownProperties { get; set; }

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            return Name?.GetHashCode() ?? base.GetHashCode();
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        public override bool Equals(object obj)
        {
            var other = obj as TopicDescription;
            return Equals(other);
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        public bool Equals(TopicDescription other)
        {
            if (other is TopicDescription otherDescription
                && Name.Equals(otherDescription.Name, StringComparison.OrdinalIgnoreCase)
                && AutoDeleteOnIdle.Equals(otherDescription.AutoDeleteOnIdle)
                && DefaultMessageTimeToLive.Equals(otherDescription.DefaultMessageTimeToLive)
                && (!RequiresDuplicateDetection || DuplicateDetectionHistoryTimeWindow.Equals(otherDescription.DuplicateDetectionHistoryTimeWindow))
                && EnableBatchedOperations == otherDescription.EnableBatchedOperations
                && EnablePartitioning == otherDescription.EnablePartitioning
                && MaxSizeInMegabytes == otherDescription.MaxSizeInMegabytes
                && RequiresDuplicateDetection.Equals(otherDescription.RequiresDuplicateDetection)
                && Status.Equals(otherDescription.Status)
                && string.Equals(_userMetadata, otherDescription._userMetadata, StringComparison.OrdinalIgnoreCase)
                && (AuthorizationRules != null && otherDescription.AuthorizationRules != null
                    || AuthorizationRules == null && otherDescription.AuthorizationRules == null)
                && (AuthorizationRules == null || AuthorizationRules.Equals(otherDescription.AuthorizationRules)))
            {
                return true;
            }

            return false;
        }

        /// <summary></summary>
        public static bool operator ==(TopicDescription left, TopicDescription right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            {
                return false;
            }

            return left.Equals(right);
        }

        /// <summary></summary>
        public static bool operator !=(TopicDescription left, TopicDescription right)
        {
            return !(left == right);
        }
    }
}
