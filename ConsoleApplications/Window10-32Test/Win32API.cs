using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Dell.KickStart.Agent.Plugins.Registration.Common
{
    public class Win32Api
    {
        private const int GEOCLASS_NATION = 16;

        //SYSGEOTYPE
        private const int GEO_NATION = 1;
        private const int GEO_LATITUDE = 2;
        private const int GEO_LONGITUDE = 3;
        private const int GEO_ISO2 = 4;
        private const int GEO_ISO3 = 5;
        private const int GEO_RFC1766 = 6;
        private const int GEO_LCID = 7;
        private const int GEO_FRIENDLYNAME = 8;
        private const int GEO_OFFICIALNAME = 9;
        private const int GEO_TIMEZONES = 10;
        private const int GEO_OFFICIALLANGUAGES = 11;


        [DllImport("kernel32.dll")]
        static extern int GetUserGeoID(int geoId);
        [DllImport("kernel32.dll")]
        static extern int GetGeoInfo(int geoid, int GeoType, StringBuilder lpGeoData, int cchData, int langid);
        [DllImport("kernel32.dll")]
        static extern int GetUserDefaultLCID();

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        static extern System.UInt16 GetUserDefaultUILanguage();
        
        /// <summary>
        /// get language.
        /// </summary>
        /// <returns></returns>
        public static string GetLanguage()
        {
            var result = string.Empty;

            Impersonator.RunImpersonated(() =>
            {
                int lcid = GetUserDefaultUILanguage();
                var cultureInfo = new CultureInfo(lcid);
                result = cultureInfo.Name;
            });

            return result;
        }

        public static string GetGeoISOName()
        {
            var result = "US";
           Impersonator.RunImpersonated(() =>
            {
                int geoId = GetUserGeoID(GEOCLASS_NATION);
                result = GetGeoOfficalName(geoId);
            });

            return result;
        }

        public static string GetGeoFriendlyName()
        {
            int geoId = GetUserGeoID(GEOCLASS_NATION);
            int lcid = GetUserDefaultLCID();
            StringBuilder bldr = new StringBuilder(50);
            GetGeoInfo(geoId, GEO_FRIENDLYNAME, bldr, bldr.Capacity, lcid);

            return bldr.ToString();
        }

        private static string GetGeoOfficalName(int geoId)
        {
            int lcid = GetUserDefaultLCID();
            StringBuilder bldr = new StringBuilder(50);
            GetGeoInfo(geoId, GEO_ISO2, bldr, bldr.Capacity, lcid);

            return bldr.ToString();
        }
    }
}
