// Copyright (c) 2015 The Starcounter.Powershell authors.
// Use of this source code is governed by the MIT license.
// See the LICENSE file for more information.

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Starcounter.Powershell.Json
{
    [DataContract]
    class DatabaseJson
    {
        [DataMember(Name = "ID")]
        public string Id { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public string DisplayName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int UserHttpPort { get; set; }

        [DataMember]
        public bool IsRunning { get; set; }

        [DataMember]
        public int Status { get; set; }

        [DataMember]
        public string StatusText { get; set; }

        [DataMember]
        public ErrorMessageJson ErrorMessage { get; set; }

        [DataMember]
        public bool HasErrorMessage { get; set; }

        [DataMember]
        public List<DatabaseApplicationJson> Applications { get; set; }

        [DataMember]
        public List<AppStoreStoreJson> AppStores { get; set; }
    }
}
