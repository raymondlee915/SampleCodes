//----------------------------------------------------------------------- 
// <copyright file="Settings.cs" company="Dell Inc.">
//     Copyright (c) Dell Inc.. All rights reserved.
//     This material is confidential and a trade secret.  Permission to use this
//     work for any purpose must be obtained in writing from Dell, Inc.
// </copyright>
//-----------------------------------------------------------------------
namespace JSONFileValidator
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This class defines 
    /// </summary>
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static readonly Settings DefaultInstance = (Settings)Synchronized(new Settings());

        public static Settings Default
        {
            get { return DefaultInstance; }
        }

        [UserScopedSetting]
        public string RecentFolder
        {
            get { return (string)this["RecentFolder"]; }
            set
            {
                this["RecentFolder"] = value;
                Save();
            }
        }
    }
}
