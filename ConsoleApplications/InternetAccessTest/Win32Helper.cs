//----------------------------------------------------------------------- 
// <copyright file="Win32Helper.cs" company="Dell Inc.">
//     Copyright (c) Dell Inc.. All rights reserved.
//     This material is confidential and a trade secret.  Permission to use this
//     work for any purpose must be obtained in writing from Dell, Inc.
// </copyright>
//-----------------------------------------------------------------------
namespace InternetAccessTest
{

    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// Win 32 API wrapper.
    /// </summary>
    public static class Win32Helper
    {
        /// <summary>
        /// Retrieves the connected state of the local system.
        /// </summary>
        /// <param name="description">Pointer to a variable that receives the connection description.</param>
        /// <param name="reservedValue">reserved value</param>
        /// <returns>True or false</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass", Justification = "Reviewed.")]
        [DllImport("wininet.dll")]
        public static extern bool InternetGetConnectedState(out int description, int reservedValue);

        /// <summary>
        /// Check internet connection, flags == 1 to force connection
        /// </summary>
        /// <param name="lpszUrl">the URL</param>
        /// <param name="dwFlags">flag value</param>
        /// <param name="dwReserved">reserved value</param>
        /// <returns>Internet connected or not</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass", Justification = "Reviewed.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA2101:SpecifyMarshalingForPInvokeStringArguments", MessageId = "0", Justification = "Reviewed.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "dw", Justification = "Windows API")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "lpsz", Justification = "Windows API")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed.")]
        [DllImport("wininet.dll", SetLastError = true)]
        public static extern bool InternetCheckConnection(string lpszUrl, int dwFlags, int dwReserved);
    }

}
