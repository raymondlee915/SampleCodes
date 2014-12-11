using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public class LibraryClass
    {
        public string Getkey()
        {
            Properties.Settings setting = new Properties.Settings();
            return setting.UserKey;
        }

        public void SetKey(string newKey)
        {
            Properties.Settings setting = new Properties.Settings();

            setting.UserKey = newKey;
        }

        public string GetDefaultKey()
        {
            return Properties.Settings.Default.UserKey;
        }
    }
}
