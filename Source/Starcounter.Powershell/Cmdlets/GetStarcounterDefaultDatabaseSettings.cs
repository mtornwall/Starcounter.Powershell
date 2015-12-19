// Copyright (c) 2015 The Starcounter.Powershell authors.
// Use of this source code is governed by the MIT license.
// See the LICENSE file for more information.

using System.Management.Automation;

namespace Starcounter.Powershell.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "StarcounterDefaultDatabaseSettings")]
    public class StarcounterDefaultDatabaseSettings : Cmdlet
    {
        [Parameter]
        public string Name { get; set; }

        protected override void ProcessRecord()
        {
            var settings = AdministratorClient.GetDefaultDatabaseSettings();

            // If name is given, customize the default settings by injecting the name at template markers.
            if (!string.IsNullOrWhiteSpace(this.Name))
            {
                settings.Name = this.Name;
                settings.DumpDirectory = settings.DumpDirectory.Replace("[DatabaseName]", this.Name);
                settings.TempDirectory = settings.TempDirectory.Replace("[DatabaseName]", this.Name);
                settings.ImageDirectory = settings.ImageDirectory.Replace("[DatabaseName]", this.Name);
                settings.TransactionLogDirectory = settings.TransactionLogDirectory.Replace("[DatabaseName]", this.Name);
            }

            this.WriteObject(settings);
        }
    }
}
