using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;

namespace FullControlFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            // string username = "Everyone";
            var rights = System.Security.AccessControl.FileSystemRights.FullControl;
            var folderPath = @"C:\Program Files\Dell\Dell Product Registration";
            var allowOrDeny = System.Security.AccessControl.AccessControlType.Allow;

            bool result = false;
            InheritanceFlags inherits = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;
            var propagateToChildren = PropagationFlags.None;
            var addResetOrRemove = AccessControlModification.Add;

            DirectoryInfo folder = new DirectoryInfo(folderPath);
            DirectorySecurity security = folder.GetAccessControl(AccessControlSections.All);
            FileSystemAccessRule accRule;

            var si = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            accRule = new FileSystemAccessRule(si, rights, inherits, propagateToChildren, allowOrDeny);

            security.ModifyAccessRule(addResetOrRemove, accRule, out result);
            folder.SetAccessControl(security);
            Console.WriteLine("Done");
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }
}
