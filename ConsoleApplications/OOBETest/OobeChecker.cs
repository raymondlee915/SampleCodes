//----------------------------------------------------------------------- 
// <copyright file="OobeChecker.cs" company="Dell Inc.">
//     Copyright (c) Dell Inc.. All rights reserved.
//     This material is confidential and a trade secret.  Permission to use this
//     work for any purpose must be obtained in writing from Dell, Inc.
// </copyright>
//-----------------------------------------------------------------------
namespace OOBETest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This class defines 
    /// </summary>
    public class OobeChecker
    {
        [DllImport("kernel32.dll")]
        internal static extern int GetLastError();

        [DllImport("Kernel32.dll")]
        internal static extern bool OOBEComplete(out bool OOBEComplete);

        [DllImport("Kernel32.dll")]
        internal static extern bool RegisterWaitUntilOOBECompleted(OOBE_COMPLETED_CALLBACK OOBECompletedCallback, IntPtr CallbackContext, out IntPtr WaitHandle);

        internal delegate void OOBE_COMPLETED_CALLBACK(IntPtr CallbackContext);
    }
}
