// Copyright (c) 2015 The Starcounter.Powershell authors.
// Use of this source code is governed by the MIT license.
// See the LICENSE file for more information.

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Starcounter.Powershell.Json
{
    [DataContract]
    class AppStoreStoreJson
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string DisplayName { get; set; }

        [DataMember]
        public bool ShowCompatibleVersions { get; set; }

        [DataMember]
        public List<AppStoreApplicationJson> Applications { get; set; }
    }
}
