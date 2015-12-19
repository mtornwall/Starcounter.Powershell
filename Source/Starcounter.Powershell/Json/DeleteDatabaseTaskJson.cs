// Copyright (c) 2015 The Starcounter.Powershell authors.
// Use of this source code is governed by the MIT license.
// See the LICENSE file for more information.

using System.Runtime.Serialization;

namespace Starcounter.Powershell.Json
{
    [DataContract]
    class DeleteDatabaseTaskJson
    {
        [DataMember]
        public string DatabaseName { get; set; }
    }
}
