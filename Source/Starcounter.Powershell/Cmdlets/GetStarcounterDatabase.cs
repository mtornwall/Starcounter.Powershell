// Copyright (c) 2015 The Starcounter.Powershell authors.
// Use of this source code is governed by the MIT license.
// See the LICENSE file for more information.

using System.Management.Automation;

namespace Starcounter.Powershell.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "StarcounterDatabase")]
    public class GetStarcounterDatabase : Cmdlet
    {
        [Parameter]
        public string Id { get; set; }

        protected override void ProcessRecord()
        {
            if (this.Id == null)
            {
                foreach (var database in AdministratorClient.GetDatabases())
                {
                    this.WriteObject(database);
                }
            }
            else
            {
                this.WriteObject(AdministratorClient.GetDatabase(this.Id));
            }
        }
    }
}