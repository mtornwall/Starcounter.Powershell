// Copyright (c) 2015 The Starcounter.Powershell authors.
// Use of this source code is governed by the MIT license.
// See the LICENSE file for more information.

using System.Runtime.Serialization;

namespace Starcounter.Powershell.Json
{
    [DataContract]
    class ErrorMessageJson
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string HelpLink { get; set; }
    }
}
