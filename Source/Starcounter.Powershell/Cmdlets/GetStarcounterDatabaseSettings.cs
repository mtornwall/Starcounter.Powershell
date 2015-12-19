// Copyright (c) 2015 The Starcounter.Powershell authors.
// Use of this source code is governed by the MIT license.
// See the LICENSE file for more information.

using System.Management.Automation;

namespace Starcounter.Powershell.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "StarcounterDatabaseSettings")]
    public class GetStarcounterDatabaseSettings : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string Id { get; set; }

        protected override void ProcessRecord()
        {
            this.WriteObject(AdministratorClient.GetDatabaseSettings(this.Id));
        }
    }
}
