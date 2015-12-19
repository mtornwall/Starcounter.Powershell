// Copyright (c) 2015 The Starcounter.Powershell authors.
// Use of this source code is governed by the MIT license.
// See the LICENSE file for more information.

using System.Management.Automation;

namespace Starcounter.Powershell.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Start, "StarcounterDatabase")]
    public class StartStarcounterDatabase : Cmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public string Id { get; set; }

        [Parameter]
        public SwitchParameter NoWait { get; set; }

        protected override void ProcessRecord()
        {
            AdministratorClient.StartDatabase(this.Id, !this.NoWait);
        }
    }
}
