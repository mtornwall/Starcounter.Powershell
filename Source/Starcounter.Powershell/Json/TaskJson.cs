// Copyright (c) 2015 The Starcounter.Powershell authors.
// Use of this source code is governed by the MIT license.
// See the LICENSE file for more information.

using System.Runtime.Serialization;

namespace Starcounter.Powershell.Json
{
    [DataContract]
    class TaskJson
    {
        [DataMember(Name = "ID")]
        public string Id { get; set; }

        [DataMember]
        public int Status { get; set; }

        [DataMember]
        public string ResourceUri { get; set; }

        [DataMember(Name = "ResourceID")]
        public string ResourceId { get; set; }

        [DataMember]
        public string TaskUri { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string Created { get; set; }
    }
}
