// Copyright (c) 2015 The Starcounter.Powershell authors.
// Use of this source code is governed by the MIT license.
// See the LICENSE file for more information.

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Starcounter.Powershell.Json
{
    [DataContract]
    class AppStoreApplicationJson
    {
        [DataMember(Name = "ID")]
        public string Id { get; set; }

        [DataMember]
        public string AppName { get; set; }

        [DataMember]
        public string DisplayName { get; set; }

        [DataMember]
        public string ImageUri { get; set; }

        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public string VersionDate { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Company { get; set; }

        [DataMember]
        public string DatabseName { get; set; }

        [DataMember]
        public string Heading { get; set; }

        [DataMember]
        public string SourceUrl { get; set; }

        [DataMember]
        public int Rating { get; set; }

        [DataMember]
        public long Size { get; set; }

        [DataMember]
        public AppStoreStoreJson Store { get; set; }

        [DataMember]
        public List<DependencyJson> Dependencies { get; set; }

        [DataMember]
        public bool IsDeployed { get; set; }

        [DataMember]
        public bool IsRunning { get; set; }

        [DataMember]
        public bool IsInstalled { get; set; }

        [DataMember]
        public bool CanBeUninstalled { get; set; }

        [DataMember]
        public bool CanUpgrade { get; set; }

        [DataMember]
        public int Status { get; set; }

        [DataMember]
        public string StatusText { get; set; }

        [DataMember]
        public ErrorMessageJson ErrorMessage { get; set; }

        [DataMember]
        public bool HasErrorMessage { get; set; }

        [DataContract]
        public class DependencyJson
        {
            [DataMember]
            public string Key { get; set; }

            [DataMember]
            public string Value { get; set; }
        }
    }
}
