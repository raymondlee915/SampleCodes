// <copyright file="Impersonator.cs" company="Dell Inc.">
//      Copyright (c) Dell Inc. All rights reserved.
// </copyright>
namespace Dell.KickStart.Agent.Plugins.Registration.Common
{
    using System;
    using System.Configuration;
    using System.Management;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security.AccessControl;
    using System.Security.Principal;


    /// <summary>
    /// Get windows use access rights.
    /// </summary>
    public static class Impersonator
    {

        /// <summary>
        /// process ID.
        /// </summary>
        private static uint processId;

        /// <summary>
        /// windows identity.
        /// </summary>
        private static WindowsIdentity identityForImpersonation;

        /// <summary>
        /// Gets or sets the process used for impersonation
        /// </summary>
        public static uint ProcessId
        {
            get { return processId; }
            set { processId = value; }
        }

        /// <summary>
        /// This method wraps an action in some impersonation 
        /// </summary>
        /// <param name="action">Action what to be run under </param>
        /// <returns>Success or not.</returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static bool RunImpersonated(Action action)
        {
            try
            {
                if (action == null)
                {
                    return false;
                }

                var impersonation = GetIdentityForImpersonation();
                {
                    if (impersonation != null)
                    {
                        using (impersonation.Impersonate())
                        {
                            action();
                        }
                    }
                    else
                    {
                        action();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// The Security token used for impersonation
        /// </summary>
        /// <returns>Windows identity.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "To use attribute")]
        [MethodImpl(MethodImplOptions.Synchronized)]
        private static WindowsIdentity GetIdentityForImpersonation()
        {
            if (identityForImpersonation != null)
            {
                return identityForImpersonation;
            }

          //  Log.Debug("Getting identity of desktop user.");

            // step 1: Do we have an existing process?
            if (processId != 0)
            {
                IntPtr securityToken = GetSecurityToken(processId);
                if (securityToken != IntPtr.Zero)
                {
                    //Log.Debug("Getting identity from process id {0}.", processId);
                    identityForImpersonation = new WindowsIdentity(securityToken);
                }
            }

            // step 2: no luck with an existing process ID.  Let's look for explorer.exe
            // NOTE: hard coded
            processId = GetProcessIdFromExePath("C:\\WINDOWS\\EXPLORER.EXE");

            if (processId != 0)
            {
                IntPtr securityToken = GetSecurityToken(processId);
               // Log.Debug("Getting identity from process id {0}.", processId);

                if (securityToken != IntPtr.Zero)
                {
                    identityForImpersonation = new WindowsIdentity(securityToken);
                }
            }

            // if we got here, we failed
            if (identityForImpersonation != null)
            {
                //Log.Info("Retrieved identity of {0} for impersonation.", identityForImpersonation.Name);
            }
            else
            {
                //Log.Debug("Failed to get identity of the desktop user.");
            }

            return identityForImpersonation;
        }

        /// <summary>
        /// Gets the id of a process given an executable path
        /// </summary>
        /// <param name="executablePath">Executable file path.</param>
        /// <returns>Process ID.</returns>
        private static uint GetProcessIdFromExePath(string executablePath)
        {
           // Log.Debug("Getting process ID for '{0}'", executablePath);

            uint processId = 0;

            try
            {
                using (ManagementObjectSearcher procs = new ManagementObjectSearcher("SELECT * FROM Win32_Process"))
                {
                    foreach (ManagementObject proc in procs.Get())
                    {
                        if (proc["ExecutablePath"] == null)
                        {
                            continue;
                        }

                        if (proc["ExecutablePath"].ToString().ToUpperInvariant() == executablePath.ToUpperInvariant())
                        {
                            processId = (uint)proc["ProcessId"];
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               // Log.Debug("Error getting process Id for '{0}': {1}", executablePath, ex.Message);
            }

           // Log.Debug("Returning process ID {0} for '{1}'", processId, executablePath);

            return processId;
        }

        /// <summary>
        /// Returns a security token for a given process ID
        /// </summary>
        /// <param name="procId">process ID.</param>
        /// <returns>Windows pointer.</returns>
        private static IntPtr GetSecurityToken(uint procId)
        {
            const int ProcessAllAccess = -1;
            IntPtr uiProcess = NativeMethods.OpenProcess(ProcessAllAccess, false, procId);
            if (uiProcess == IntPtr.Zero)
            {
              //  Log.Debug("Can't open process id {0} (Error {1})", procId, NativeMethods.GetLastError());
            }
            else
            {
                try
                {
                    IntPtr token;
                    if (!NativeMethods.OpenProcessToken(uiProcess, (uint)TokenAccessLevels.MaximumAllowed, out token))
                    {
                       // Log.Debug("Can't get security token for process id {0} (Error {1})", procId, NativeMethods.GetLastError());
                    }
                    else
                    {
                        return token;
                    }
                }
                catch (Exception ex)
                {
                    //Log.Debug("Error getting token from process id {0}: {1}", procId, ex.Message);
                }
                finally
                {
                    NativeMethods.CloseHandle(uiProcess);
                }
            }

            return IntPtr.Zero;
        }
    }
}
