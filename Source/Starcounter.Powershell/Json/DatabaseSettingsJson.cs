// Copyright (c) 2015 The Starcounter.Powershell authors.
// Use of this source code is governed by the MIT license.
// See the LICENSE file for more information.

using System.Runtime.Serialization;

namespace Starcounter.Powershell.Json
{
    [DataContract]
    class DatabaseSettingsJson
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int DefaultUserHttpPort { get; set; }

        [DataMember]
        public int SchedulerCount { get; set; }

        [DataMember]
        public int ChunksNumber { get; set; }

        [DataMember]
        public string CollationFile { get; set; }

        [DataMember]
        public string DumpDirectory { get; set; }

        [DataMember]
        public string TempDirectory { get; set; }

        [DataMember]
        public string ImageDirectory { get; set; }

        [DataMember]
        public string TransactionLogDirectory { get; set; }

        [DataMember]
        public bool PolyjuiceDatabaseFlag { get; set; }
    }
}
