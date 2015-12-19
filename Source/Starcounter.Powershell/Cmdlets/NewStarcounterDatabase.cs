// Copyright (c) 2015 The Starcounter.Powershell authors.
// Use of this source code is governed by the MIT license.
// See the LICENSE file for more information.

using Starcounter.Powershell.Json;
using System.Management.Automation;

namespace Starcounter.Powershell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "StarcounterDatabase")]
    public class NewStarcounterDatabase : Cmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int DefaultUserHttpPort { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int SchedulerCount { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int ChunksNumber { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public string CollationFile { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public string DumpDirectory { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public string TempDirectory { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public string ImageDirectory { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public string TransactionLogDirectory { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public bool PolyjuiceDatabaseFlag { get; set; }

        [Parameter]
        public SwitchParameter NoWait { get; set; }

        protected override void ProcessRecord()
        {
            AdministratorClient.CreateDatabase(
                new DatabaseSettingsJson()
                {
                    Name = this.Name,
                    DefaultUserHttpPort = this.DefaultUserHttpPort,
                    SchedulerCount = this.SchedulerCount,
                    ChunksNumber = this.ChunksNumber,
                    CollationFile = this.CollationFile,
                    DumpDirectory = this.DumpDirectory,
                    TempDirectory = this.TempDirectory,
                    ImageDirectory = this.ImageDirectory,
                    TransactionLogDirectory = this.TransactionLogDirectory,
                    PolyjuiceDatabaseFlag = this.PolyjuiceDatabaseFlag
                }, !this.NoWait);
        }
    }
}
