// Copyright (c) 2015 The Starcounter.Powershell authors.
// Use of this source code is governed by the MIT license.
// See the LICENSE file for more information.

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Starcounter.Powershell.Json
{
    [DataContract]
    class LogJson
    {
        [DataMember]
        public bool FilterNotice { get; set; }

        [DataMember]
        public bool FilterWarning { get; set; }

        [DataMember]
        public bool FilterError { get; set; }

        [DataMember]
        public bool FilterDebug { get; set; }

        [DataMember]
        public string FilterSource { get; set; }

        [DataMember]
        public int FilterMaxItems { get; set; }

        [DataMember]
        public List<EntryJson> LogEntries { get; set; }

        [DataContract]
        public class EntryJson
        {
            [DataMember(Name = "DateTimeStr")]
            public string DateTime { get; set; }

            [DataMember(Name = "TypeStr")]
            public string Type { get; set; }

            [DataMember]
            public string HostName { get; set; }

            [DataMember]
            public string Source { get; set; }

            [DataMember]
            public string Message { get; set; }
        }
    }
}
