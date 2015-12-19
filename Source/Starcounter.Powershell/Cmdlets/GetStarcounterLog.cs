// Copyright (c) 2015 The Starcounter.Powershell authors.
// Use of this source code is governed by the MIT license.
// See the LICENSE file for more information.

using System.Collections.Generic;
using System.Management.Automation;

namespace Starcounter.Powershell.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "StarcounterLog")]
    public class GetStarcounterLog : Cmdlet
    {
        [Parameter]
        public LogLevel Level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
            }
        }
        private LogLevel _level = LogLevel.Debug;

        [Parameter]
        public List<string> Sources
        {
            get
            {
                return _sources;
            }
            set
            {
                _sources = value;
            }
        }
        private List<string> _sources = new List<string>();

        [Parameter]
        public int Limit
        {
            get
            {
                return _limit;
            }
            set
            {
                _limit = value;
            }
        }
        private int _limit = 30;

        protected override void ProcessRecord()
        {
            var log = AdministratorClient.GetLog(
                this.Level <= LogLevel.Debug,
                this.Level <= LogLevel.Notice,
                this.Level <= LogLevel.Warning,
                this.Level <= LogLevel.Error,
                this.Sources,
                this.Limit);

            foreach (var logEntry in log.LogEntries)
            {
                this.WriteObject(logEntry);
            }
        }

        public enum LogLevel
        {
            Debug,
            Notice,
            Warning,
            Error
        }
    }
}