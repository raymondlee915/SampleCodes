// <copyright file="NativeMethods.cs" company="Dell Inc.">
//      Copyright (c) Dell Inc. All rights reserved.
// </copyright>
namespace  Dell.KickStart.Agent.Plugins.Registration.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// This class is shared between assemblies
    /// </summary>
    public static class NativeMethods
    {
        /// <summary>
        /// Get GEO identity of current user.
        /// </summary>
        /// <param name="geoId">GEO identity</param>
        /// <returns>current user GEO identity</returns>
        [DllImport("kernel32.dll")]
        internal static extern int GetUserGeoID(int geoId);

        // Closes HANDLE object
        [DllImport("kernel32.dll")]
        internal static extern bool CloseHandle(IntPtr handleObject);

        // Opens the access token associated with a process
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool OpenProcessToken(IntPtr processHandle, uint desiredAccess, out IntPtr tokenHandle);

        [DllImport("Kernel32")]
        internal static extern IntPtr OpenProcess(int desiredAccess, bool inheritClientHandle, uint processID);

        [DllImport("kernel32.dll")]
        internal static extern int GetLastError();
    }
}
