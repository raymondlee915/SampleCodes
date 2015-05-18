using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace CountryCode
{
    class Program
    {
        private static Dictionary<string, string> countryCodeMapping = null;
        private static List<string> countryNames = null;
        private static Dictionary<string, string> isoMapping = null;

        public static Dictionary<string, string> ISOMapping
        {
            get
            {
                if (isoMapping == null)
                {
                    isoMapping = new Dictionary<string, string>();
                    isoMapping.Add("", "");
                    isoMapping.Add("Afghanistan", "AF");
                    isoMapping.Add("Åland Islands", "AX");
                    isoMapping.Add("Albania", "AL");
                    isoMapping.Add("Algeria", "DZ");
                    isoMapping.Add("American Samoa", "AS");
                    isoMapping.Add("Andorra", "AD");
                    isoMapping.Add("Angola", "AO");
                    isoMapping.Add("Anguilla", "AI");
                    isoMapping.Add("Antarctica", "AQ");
                    isoMapping.Add("Antigua and Barbuda", "AG");
                    isoMapping.Add("Argentina", "AR");
                    isoMapping.Add("Armenia", "AM");
                    isoMapping.Add("Aruba", "AW");
                    isoMapping.Add("Australia", "AU");
                    isoMapping.Add("Austria", "AT");
                    isoMapping.Add("Azerbaijan", "AZ");
                    isoMapping.Add("Bahamas, The", "BS");//Bahamas (the)
                    isoMapping.Add("Bahrain", "BH");
                    isoMapping.Add("Bangladesh", "BD");
                    isoMapping.Add("Barbados", "BB");
                    isoMapping.Add("Belarus", "BY");
                    isoMapping.Add("Belgium", "BE");
                    isoMapping.Add("Belize", "BZ");
                    isoMapping.Add("Benin", "BJ");
                    isoMapping.Add("Bermuda", "BM");
                    isoMapping.Add("Bhutan", "BT");
                    isoMapping.Add("Bolivia", "BO");//Bolivia (Plurinational State of)
                    isoMapping.Add("Bonaire, Sint Eustatius and Saba", "BQ");
                    isoMapping.Add("Bonaire, Saint Eustatius and Saba", "BQ");
                    isoMapping.Add("Bosnia and Herzegovina", "BA");
                    isoMapping.Add("Botswana", "BW");
                    isoMapping.Add("Bouvet Island", "BV");
                    isoMapping.Add("Brazil", "BR");
                    isoMapping.Add("British Antarctic Territory", "BQ");
                    isoMapping.Add("British Indian Ocean Territory", "IO");
                    isoMapping.Add("Brunei", "BN");//Brunei Darussalam
                    isoMapping.Add("Bulgaria", "BG");
                    isoMapping.Add("Burkina Faso", "BF");
                    isoMapping.Add("Burma", "BU");
                    isoMapping.Add("Burundi", "BI");
                    isoMapping.Add("Byelorussian SSR", "BY");
                    isoMapping.Add("Cape Verde", "CV");//Cabo Verde
                    isoMapping.Add("Cambodia", "KH");
                    isoMapping.Add("Cameroon", "CM");
                    isoMapping.Add("Canada", "CA");
                    isoMapping.Add("Canton and Enderbury Islands", "CT");
                    isoMapping.Add("Cayman Islands", "KY");
                    isoMapping.Add("Central African Republic", "CF");
                    isoMapping.Add("Chad", "TD");
                    isoMapping.Add("Chile", "CL");
                    isoMapping.Add("China", "CN");
                    isoMapping.Add("Christmas Island", "CX");
                    isoMapping.Add("Cocos (Keeling) Islands", "CC");
                    isoMapping.Add("Colombia", "CO");
                    isoMapping.Add("Comoros", "KM");//Comoros (the)
                    isoMapping.Add("Congo (DRC)", "CD");//Congo (the Democratic Republic of the)
                    isoMapping.Add("Congo", "CG");//Congo (the)
                    isoMapping.Add("Cook Islands", "CK");
                    isoMapping.Add("Costa Rica", "CR");
                    isoMapping.Add("Côte d'Ivoire", "CI");
                    isoMapping.Add("Croatia", "HR");
                    isoMapping.Add("Cuba", "CU");
                    isoMapping.Add("Curaçao", "CW");
                    isoMapping.Add("Cyprus", "CY");
                    isoMapping.Add("Czech Republic", "CZ");
                    isoMapping.Add("Czechoslovakia", "CS");
                    isoMapping.Add("Dahomey", "DY");
                    isoMapping.Add("Denmark", "DK");
                    isoMapping.Add("Djibouti", "DJ");
                    isoMapping.Add("Dominica", "DM");
                    isoMapping.Add("Dominican Republic", "DO");//Dominican Republic (the)
                    isoMapping.Add("Dronning Maud Land", "NQ");
                    isoMapping.Add("East Timor", "TP");
                    isoMapping.Add("Ecuador", "EC");
                    isoMapping.Add("Egypt", "EG");
                    isoMapping.Add("El Salvador", "SV");
                    isoMapping.Add("Equatorial Guinea", "GQ");
                    isoMapping.Add("Eritrea", "ER");
                    isoMapping.Add("Estonia", "EE");
                    isoMapping.Add("Ethiopia", "ET");
                    isoMapping.Add("Falkland Islands (Islas Malvinas)", "FK");
                    isoMapping.Add("Faroe Islands", "FO");
                    isoMapping.Add("Fiji Islands", "FJ");
                    isoMapping.Add("Finland", "FI");
                    isoMapping.Add("France", "FR");
                    isoMapping.Add("France, Metropolitan", "FX");
                    isoMapping.Add("French Afars and Issas", "AI");
                    isoMapping.Add("French Guiana", "GF");
                    isoMapping.Add("French Polynesia", "PF");
                    isoMapping.Add("French Southern and Antarctic Territories", "FQ");
                    isoMapping.Add("French Southern and Antarctic Lands", "FQ");
                    isoMapping.Add("French Southern Territories", "TF");
                    isoMapping.Add("Gabon", "GA");
                    isoMapping.Add("Gambia, The", "GM");
                    isoMapping.Add("Georgia", "GE");
                    isoMapping.Add("German Democratic Republic", "DD");
                    isoMapping.Add("Germany", "DE");
                    isoMapping.Add("Ghana", "GH");
                    isoMapping.Add("Gibraltar", "GI");
                    isoMapping.Add("Gilbert and Ellice Islands", "GE");
                    isoMapping.Add("Greece", "GR");
                    isoMapping.Add("Greenland", "GL");
                    isoMapping.Add("Grenada", "GD");
                    isoMapping.Add("Guadeloupe", "GP");
                    isoMapping.Add("Guam", "GU");
                    isoMapping.Add("Guatemala", "GT");
                    isoMapping.Add("Guernsey", "GG");
                    isoMapping.Add("Guinea", "GN");
                    isoMapping.Add("Guinea-Bissau", "GW");
                    isoMapping.Add("Guyana", "GY");
                    isoMapping.Add("Haiti", "HT");
                    isoMapping.Add("Heard Island and McDonald Islands", "HM");
                    isoMapping.Add("Holy See", "VA");
                    isoMapping.Add("Vatican City", "VA");
                    isoMapping.Add("Honduras", "HN");
                    isoMapping.Add("Hong Kong S.A.R.", "HK");
                    isoMapping.Add("Hungary", "HU");
                    isoMapping.Add("Iceland", "IS");
                    isoMapping.Add("India", "IN");
                    isoMapping.Add("Indonesia", "ID");
                    isoMapping.Add("Iran", "IR");
                    isoMapping.Add("Iraq", "IQ");
                    isoMapping.Add("Ireland", "IE");
                    isoMapping.Add("Isle of Man", "IM");
                    isoMapping.Add("Man, Isle of", "IM");
                    isoMapping.Add("Israel", "IL");
                    isoMapping.Add("Italy", "IT");
                    isoMapping.Add("Jamaica", "JM");
                    isoMapping.Add("Japan", "JP");
                    isoMapping.Add("Jersey", "JE");
                    isoMapping.Add("Johnston Atoll", "JT");
                    isoMapping.Add("Jordan", "JO");
                    isoMapping.Add("Kazakhstan", "KZ");
                    isoMapping.Add("Kenya", "KE");
                    isoMapping.Add("Kiribati", "KI");
                    isoMapping.Add("North Korea", "KP");
                    isoMapping.Add("Korea", "KR");
                    isoMapping.Add("Kuwait", "KW");
                    isoMapping.Add("Kyrgyzstan", "KG");
                    isoMapping.Add("Laos", "LA");
                    isoMapping.Add("Latvia", "LV");
                    isoMapping.Add("Lebanon", "LB");
                    isoMapping.Add("Lesotho", "LS");
                    isoMapping.Add("Liberia", "LR");
                    isoMapping.Add("Libya", "LY");
                    isoMapping.Add("Liechtenstein", "LI");
                    isoMapping.Add("Lithuania", "LT");
                    isoMapping.Add("Luxembourg", "LU");
                    isoMapping.Add("Macao S.A.R.", "MO");
                    isoMapping.Add("Macedonia (the former Yugoslav Republic of)", "MK");
                    isoMapping.Add("Macedonia, Former Yugoslav Republic of", "MK");
                    isoMapping.Add("Madagascar", "MG");
                    isoMapping.Add("Malawi", "MW");
                    isoMapping.Add("Malaysia", "MY");
                    isoMapping.Add("Maldives", "MV");
                    isoMapping.Add("Mali", "ML");
                    isoMapping.Add("Malta", "MT");
                    isoMapping.Add("Marshall Islands", "MH");
                    isoMapping.Add("Martinique", "MQ");
                    isoMapping.Add("Mauritania", "MR");
                    isoMapping.Add("Mauritius", "MU");
                    isoMapping.Add("Mayotte", "YT");
                    isoMapping.Add("Mexico", "MX");
                    isoMapping.Add("Micronesia", "FM");
                    isoMapping.Add("Midway Islands", "MI");
                    isoMapping.Add("Moldova", "MD");
                    isoMapping.Add("Monaco", "MC");
                    isoMapping.Add("Mongolia", "MN");
                    isoMapping.Add("Montenegro", "ME");
                    isoMapping.Add("Montserrat", "MS");
                    isoMapping.Add("Morocco", "MA");
                    isoMapping.Add("Mozambique", "MZ");
                    isoMapping.Add("Myanmar", "MM");
                    isoMapping.Add("Namibia", "NA");
                    isoMapping.Add("Nauru", "NR");
                    isoMapping.Add("Nepal", "NP");
                    isoMapping.Add("Netherlands", "NL");
                    isoMapping.Add("Netherlands Antilles", "AN");
                    isoMapping.Add("Neutral Zone", "NT");
                    isoMapping.Add("New Caledonia", "NC");
                    isoMapping.Add("New Hebrides", "NH");
                    isoMapping.Add("New Zealand", "NZ");
                    isoMapping.Add("Nicaragua", "NI");
                    isoMapping.Add("Niger", "NE");
                    isoMapping.Add("Nigeria", "NG");
                    isoMapping.Add("Niue", "NU");
                    isoMapping.Add("Norfolk Island", "NF");
                    isoMapping.Add("Northern Mariana Islands", "MP");
                    isoMapping.Add("Norway", "NO");
                    isoMapping.Add("Oman", "OM");
                    isoMapping.Add("Pacific Islands (Trust Territory)", "PC");
                    isoMapping.Add("Pakistan", "PK");
                    isoMapping.Add("Palau", "PW");
                    isoMapping.Add("Palestine, State of", "PS");
                    isoMapping.Add("Palestinian Authority", "PS");

                    isoMapping.Add("Panama", "PA");
                    isoMapping.Add("Panama Canal Zone", "PZ");
                    isoMapping.Add("Papua New Guinea", "PG");
                    isoMapping.Add("Paraguay", "PY");
                    isoMapping.Add("Peru", "PE");
                    isoMapping.Add("Philippines", "PH");
                    isoMapping.Add("Pitcairn", "PN");
                    isoMapping.Add("Poland", "PL");
                    isoMapping.Add("Portugal", "PT");
                    isoMapping.Add("Puerto Rico", "PR");
                    isoMapping.Add("Qatar", "QA");
                    isoMapping.Add("Réunion", "RE");
                    isoMapping.Add("Reunion", "RE");
                    isoMapping.Add("Romania", "RO");
                    isoMapping.Add("Russia", "RU");
                    isoMapping.Add("Rwanda", "RW");
                    isoMapping.Add("Saint Barthélemy", "BL");
                    isoMapping.Add("Ascension", "SH");
                    isoMapping.Add("Ascension Island", "SH");
                    isoMapping.Add("Saint Kitts and Nevis", "KN");
                    isoMapping.Add("Saint Lucia", "LC");
                    isoMapping.Add("Saint Martin (French part)", "MF");
                    isoMapping.Add("Saint Pierre and Miquelon", "PM");
                    isoMapping.Add("Saint Vincent and the Grenadines", "VC");
                    isoMapping.Add("St. Barthélemy", "BL");
                    isoMapping.Add("St. Kitts and Nevis", "KN");
                    isoMapping.Add("St. Lucia", "LC");
                    isoMapping.Add("St. Martin (French part)", "MF");
                    isoMapping.Add("St. Pierre and Miquelon", "PM");
                    isoMapping.Add("St. Vincent and the Grenadines", "VC");
                    isoMapping.Add("Samoa", "WS");
                    isoMapping.Add("San Marino", "SM");
                    isoMapping.Add("Sao Tome and Principe", "ST");
                    isoMapping.Add("São Tomé and Príncipe", "ST");
                    isoMapping.Add("Saudi Arabia", "SA");
                    isoMapping.Add("Senegal", "SN");
                    isoMapping.Add("Serbia", "RS");
                    isoMapping.Add("Serbia and Montenegro", "CS");
                    isoMapping.Add("Serbia and Montenegro (Former)", "CS");
                    isoMapping.Add("Seychelles", "SC");
                    isoMapping.Add("Sierra Leone", "SL");
                    isoMapping.Add("Sikkim", "SK");
                    isoMapping.Add("Singapore", "SG");
                    isoMapping.Add("Sint Maarten (Dutch part)", "SX");
                    isoMapping.Add("Slovakia", "SK");
                    isoMapping.Add("Slovenia", "SI");
                    isoMapping.Add("Solomon Islands", "SB");
                    isoMapping.Add("Somalia", "SO");
                    isoMapping.Add("South Africa", "ZA");
                    isoMapping.Add("South Georgia and the South Sandwich Islands", "GS");
                    isoMapping.Add("South Sudan", "SS");
                    isoMapping.Add("Southern Rhodesia", "RH");
                    isoMapping.Add("Spain", "ES");
                    isoMapping.Add("Sri Lanka", "LK");
                    isoMapping.Add("Sudan", "SD");
                    isoMapping.Add("Suriname", "SR");
                    isoMapping.Add("Svalbard and Jan Mayen", "SJ");
                    isoMapping.Add("Jan Mayen", "SJ");
                    isoMapping.Add("Svalbard", "SJ");
                    isoMapping.Add("Swaziland", "SZ");
                    isoMapping.Add("Sweden", "SE");
                    isoMapping.Add("Switzerland", "CH");
                    isoMapping.Add("Syrian Arab Republic", "SY");
                    isoMapping.Add("Syria", "SY");
                    isoMapping.Add("Taiwan", "TW");
                    isoMapping.Add("Tajikistan", "TJ");
                    isoMapping.Add("Tanzania", "TZ");
                    isoMapping.Add("Thailand", "TH");
                    isoMapping.Add("Timor-Leste", "TL");
                    isoMapping.Add("Democratic Republic of Timor-Leste", "TL");
                    isoMapping.Add("Togo", "TG");
                    isoMapping.Add("Tokelau", "TK");
                    isoMapping.Add("Tonga", "TO");
                    isoMapping.Add("Trinidad and Tobago", "TT");
                    isoMapping.Add("Tunisia", "TN");
                    isoMapping.Add("Turkey", "TR");
                    isoMapping.Add("Turkmenistan", "TM");
                    isoMapping.Add("Turks and Caicos Islands", "TC");
                    isoMapping.Add("Tuvalu", "TV");
                    isoMapping.Add("Uganda", "UG");
                    isoMapping.Add("Ukraine", "UA");
                    isoMapping.Add("United Arab Emirates", "AE");
                    isoMapping.Add("United Kingdom", "GB");
                    isoMapping.Add("U.S. Minor Outlying Islands", "UM");
                    isoMapping.Add("United States Miscellaneous Pacific Islands", "PU");
                    isoMapping.Add("United States", "US");
                    isoMapping.Add("Upper Volta", "HV");
                    isoMapping.Add("Uruguay", "UY");
                    isoMapping.Add("USSR", "SU");
                    isoMapping.Add("Uzbekistan", "UZ");
                    isoMapping.Add("Vanuatu", "VU");
                    isoMapping.Add("Venezuela", "VE");
                    isoMapping.Add("Vietnam", "VN");
                    isoMapping.Add("Virgin Islands, British", "VG");
                    isoMapping.Add("Virgin Islands", "VI");
                    isoMapping.Add("Wake Island", "WK");
                    isoMapping.Add("Wallis and Futuna", "WF");
                    isoMapping.Add("Western Sahara*", "EH");
                    isoMapping.Add("Western Sahara (disputed)", "EH");

                    isoMapping.Add("Yemen", "YE");
                    isoMapping.Add("Yemen, Democratic", "YD");
                    isoMapping.Add("Yugoslavia", "YU");
                    isoMapping.Add("Zaire", "ZR");
                    isoMapping.Add("Zambia", "ZM");
                    isoMapping.Add("Zimbabwe", "ZW");

                    isoMapping.Add("Ashmore and Cartier Islands", "AU");
                    isoMapping.Add("Coral Sea Islands", "AU");
                    isoMapping.Add("Baker Island", "US");
                    isoMapping.Add("Clipperton Island", "FR");
                    isoMapping.Add("Diego Garcia", "GB");
                    isoMapping.Add("Guantanamo Bay", "US");
                    isoMapping.Add("Howland Island", "US");
                    isoMapping.Add("Jarvis Island", "US");
                    isoMapping.Add("Kingman Reef", "US");
                    isoMapping.Add("Pitcairn Islands", "GB");
                    isoMapping.Add("Rota Island", "US");
                    isoMapping.Add("Saipan", "US");
                    isoMapping.Add("Tinian Island", "US");
                    isoMapping.Add("St. Helena", "SH");
                    isoMapping.Add("Tristan da Cunha", "SH");
                    isoMapping.Add("Palmyra Atoll", "US");
                }

                return Program.isoMapping;
            }
        }

        public static List<string> CountryNames
        {
            get
            {
                if (countryNames == null)
                {
                    countryNames = new List<string>();
                    countryNames.Add("Antigua and Barbuda");
                    countryNames.Add("Afghanistan");
                    countryNames.Add("Algeria");
                    countryNames.Add("Azerbaijan");
                    countryNames.Add("Albania");
                    countryNames.Add("Armenia");
                    countryNames.Add("Andorra");
                    countryNames.Add("Angola");
                    countryNames.Add("American Samoa");
                    countryNames.Add("Argentina");
                    countryNames.Add("Australia");
                    countryNames.Add("Austria");
                    countryNames.Add("Bahrain");
                    countryNames.Add("Barbados");
                    countryNames.Add("Botswana");
                    countryNames.Add("Bermuda");
                    countryNames.Add("Belgium");
                    countryNames.Add("Bahamas, The");
                    countryNames.Add("Bangladesh");
                    countryNames.Add("Belize");
                    countryNames.Add("Bosnia and Herzegovina");
                    countryNames.Add("Bolivia");
                    countryNames.Add("Myanmar");
                    countryNames.Add("Benin");
                    countryNames.Add("Belarus");
                    countryNames.Add("Solomon Islands");
                    countryNames.Add("Brazil");
                    countryNames.Add("Bhutan");
                    countryNames.Add("Bulgaria");
                    countryNames.Add("Brunei");
                    countryNames.Add("Burundi");
                    countryNames.Add("Canada");
                    countryNames.Add("Cambodia");
                    countryNames.Add("Chad");
                    countryNames.Add("Sri Lanka");
                    countryNames.Add("Congo");
                    countryNames.Add("Congo (DRC)");
                    countryNames.Add("China");
                    countryNames.Add("Chile");
                    countryNames.Add("Cameroon");
                    countryNames.Add("Comoros");
                    countryNames.Add("Colombia");
                    countryNames.Add("Costa Rica");
                    countryNames.Add("Central African Republic");
                    countryNames.Add("Cuba");
                    countryNames.Add("Cape Verde");
                    countryNames.Add("Cyprus");
                    countryNames.Add("Denmark");
                    countryNames.Add("Djibouti");
                    countryNames.Add("Dominica");
                    countryNames.Add("Dominican Republic");
                    countryNames.Add("Ecuador");
                    countryNames.Add("Egypt");
                    countryNames.Add("Ireland");
                    countryNames.Add("Equatorial Guinea");
                    countryNames.Add("Estonia");
                    countryNames.Add("Eritrea");
                    countryNames.Add("El Salvador");
                    countryNames.Add("Ethiopia");
                    countryNames.Add("Czech Republic");
                    countryNames.Add("Finland");
                    countryNames.Add("Fiji Islands");
                    countryNames.Add("Micronesia");
                    countryNames.Add("Faroe Islands");
                    countryNames.Add("France");
                    countryNames.Add("Gambia, The");
                    countryNames.Add("Gabon");
                    countryNames.Add("Georgia");
                    countryNames.Add("Ghana");
                    countryNames.Add("Gibraltar");
                    countryNames.Add("Grenada");
                    countryNames.Add("Greenland");
                    countryNames.Add("Germany");
                    countryNames.Add("Greece");
                    countryNames.Add("Guatemala");
                    countryNames.Add("Guinea");
                    countryNames.Add("Guyana");
                    countryNames.Add("Haiti");
                    countryNames.Add("Hong Kong S.A.R.");
                    countryNames.Add("Honduras");
                    countryNames.Add("Croatia");
                    countryNames.Add("Hungary");
                    countryNames.Add("Iceland");
                    countryNames.Add("Indonesia");
                    countryNames.Add("India");
                    countryNames.Add("British Indian Ocean Territory");
                    countryNames.Add("Iran");
                    countryNames.Add("Israel");
                    countryNames.Add("Italy");
                    countryNames.Add("Côte d'Ivoire");
                    countryNames.Add("Iraq");
                    countryNames.Add("Japan");
                    countryNames.Add("Jamaica");
                    countryNames.Add("Jan Mayen");
                    countryNames.Add("Jordan");
                    countryNames.Add("Johnston Atoll");
                    countryNames.Add("Kenya");
                    countryNames.Add("Kyrgyzstan");
                    countryNames.Add("North Korea");
                    countryNames.Add("Kiribati");
                    countryNames.Add("Korea");
                    countryNames.Add("Kuwait");
                    countryNames.Add("Kazakhstan");
                    countryNames.Add("Laos");
                    countryNames.Add("Lebanon");
                    countryNames.Add("Latvia");
                    countryNames.Add("Lithuania");
                    countryNames.Add("Liberia");
                    countryNames.Add("Slovakia");
                    countryNames.Add("Liechtenstein");
                    countryNames.Add("Lesotho");
                    countryNames.Add("Luxembourg");
                    countryNames.Add("Libya");
                    countryNames.Add("Madagascar");
                    countryNames.Add("Macao S.A.R.");
                    countryNames.Add("Moldova");
                    countryNames.Add("Mongolia");
                    countryNames.Add("Malawi");
                    countryNames.Add("Mali");
                    countryNames.Add("Monaco");
                    countryNames.Add("Morocco");
                    countryNames.Add("Mauritius");
                    countryNames.Add("Mauritania");
                    countryNames.Add("Malta");
                    countryNames.Add("Oman");
                    countryNames.Add("Maldives");
                    countryNames.Add("Mexico");
                    countryNames.Add("Malaysia");
                    countryNames.Add("Mozambique");
                    countryNames.Add("Niger");
                    countryNames.Add("Vanuatu");
                    countryNames.Add("Nigeria");
                    countryNames.Add("Netherlands");
                    countryNames.Add("Norway");
                    countryNames.Add("Nepal");
                    countryNames.Add("Nauru");
                    countryNames.Add("Suriname");
                    countryNames.Add("Nicaragua");
                    countryNames.Add("New Zealand");
                    countryNames.Add("Palestinian Authority");
                    countryNames.Add("Paraguay");
                    countryNames.Add("Peru");
                    countryNames.Add("Pakistan");
                    countryNames.Add("Poland");
                    countryNames.Add("Panama");
                    countryNames.Add("Portugal");
                    countryNames.Add("Papua New Guinea");
                    countryNames.Add("Palau");
                    countryNames.Add("Guinea-Bissau");
                    countryNames.Add("Qatar");
                    countryNames.Add("Reunion");
                    countryNames.Add("Marshall Islands");
                    countryNames.Add("Romania");
                    countryNames.Add("Philippines");
                    countryNames.Add("Puerto Rico");
                    countryNames.Add("Russia");
                    countryNames.Add("Rwanda");
                    countryNames.Add("Saudi Arabia");
                    countryNames.Add("St. Pierre and Miquelon");
                    countryNames.Add("St. Kitts and Nevis");
                    countryNames.Add("Seychelles");
                    countryNames.Add("South Africa");
                    countryNames.Add("Senegal");
                    countryNames.Add("Slovenia");
                    countryNames.Add("Sierra Leone");
                    countryNames.Add("San Marino");
                    countryNames.Add("Singapore");
                    countryNames.Add("Somalia");
                    countryNames.Add("Spain");
                    countryNames.Add("St. Lucia");
                    countryNames.Add("Sudan");
                    countryNames.Add("Svalbard");
                    countryNames.Add("Sweden");
                    countryNames.Add("Syria");
                    countryNames.Add("Switzerland");
                    countryNames.Add("United Arab Emirates");
                    countryNames.Add("Trinidad and Tobago");
                    countryNames.Add("Thailand");
                    countryNames.Add("Tajikistan");
                    countryNames.Add("Tonga");
                    countryNames.Add("Togo");
                    countryNames.Add("São Tomé and Príncipe");
                    countryNames.Add("Tunisia");
                    countryNames.Add("Turkey");
                    countryNames.Add("Tuvalu");
                    countryNames.Add("Taiwan");
                    countryNames.Add("Turkmenistan");
                    countryNames.Add("Tanzania");
                    countryNames.Add("Uganda");
                    countryNames.Add("Ukraine");
                    countryNames.Add("United Kingdom");
                    countryNames.Add("United States");
                    countryNames.Add("Burkina Faso");
                    countryNames.Add("Uruguay");
                    countryNames.Add("Uzbekistan");
                    countryNames.Add("St. Vincent and the Grenadines");
                    countryNames.Add("Venezuela");
                    countryNames.Add("Vietnam");
                    countryNames.Add("Virgin Islands");
                    countryNames.Add("Vatican City");
                    countryNames.Add("Namibia");
                    countryNames.Add("Western Sahara (disputed)");
                    countryNames.Add("Wake Island");
                    countryNames.Add("Samoa");
                    countryNames.Add("Swaziland");
                    countryNames.Add("Yemen");
                    countryNames.Add("Zambia");
                    countryNames.Add("Zimbabwe");
                    countryNames.Add("Serbia and Montenegro (Former)");
                    countryNames.Add("Montenegro");
                    countryNames.Add("Serbia");
                    countryNames.Add("Curaçao");
                    countryNames.Add("South Sudan");
                    countryNames.Add("Anguilla");
                    countryNames.Add("Antarctica");
                    countryNames.Add("Aruba");
                    countryNames.Add("Ascension Island");
                    countryNames.Add("Ashmore and Cartier Islands");
                    countryNames.Add("Baker Island");
                    countryNames.Add("Bouvet Island");
                    countryNames.Add("Cayman Islands");
                    countryNames.Add("Christmas Island");
                    countryNames.Add("Clipperton Island");
                    countryNames.Add("Cocos (Keeling) Islands");
                    countryNames.Add("Cook Islands");
                    countryNames.Add("Coral Sea Islands");
                    countryNames.Add("Diego Garcia");
                    countryNames.Add("Falkland Islands (Islas Malvinas)");
                    countryNames.Add("French Guiana");
                    countryNames.Add("French Polynesia");
                    countryNames.Add("French Southern and Antarctic Lands");
                    countryNames.Add("Guadeloupe");
                    countryNames.Add("Guam");
                    countryNames.Add("Guantanamo Bay");
                    countryNames.Add("Guernsey");
                    countryNames.Add("Heard Island and McDonald Islands");
                    countryNames.Add("Howland Island");
                    countryNames.Add("Jarvis Island");
                    countryNames.Add("Jersey");
                    countryNames.Add("Kingman Reef");
                    countryNames.Add("Martinique");
                    countryNames.Add("Mayotte");
                    countryNames.Add("Montserrat");
                    countryNames.Add("New Caledonia");
                    countryNames.Add("Niue");
                    countryNames.Add("Norfolk Island");
                    countryNames.Add("Northern Mariana Islands");
                    countryNames.Add("Palmyra Atoll");
                    countryNames.Add("Pitcairn Islands");
                    countryNames.Add("Rota Island");
                    countryNames.Add("Saipan");
                    countryNames.Add("South Georgia and the South Sandwich Islands");
                    countryNames.Add("St. Helena");
                    countryNames.Add("Tinian Island");
                    countryNames.Add("Tokelau");
                    countryNames.Add("Tristan da Cunha");
                    countryNames.Add("Turks and Caicos Islands");
                    countryNames.Add("Virgin Islands, British");
                    countryNames.Add("Wallis and Futuna");
                    countryNames.Add("Man, Isle of");
                    countryNames.Add("Macedonia, Former Yugoslav Republic of");
                    countryNames.Add("Midway Islands");
                    countryNames.Add("Sint Maarten (Dutch part)");
                    countryNames.Add("Saint Martin (French part)");
                    countryNames.Add("Democratic Republic of Timor-Leste");
                    countryNames.Add("Åland Islands");
                    countryNames.Add("Saint Barthélemy");
                    countryNames.Add("U.S. Minor Outlying Islands");
                    countryNames.Add("Bonaire, Saint Eustatius and Saba");
                }

                return countryNames;
            }
        }

        static void Main(string[] args)
        {
            KSRegion[] regions = null;
            using (StreamReader reader = new StreamReader(File.OpenRead("config.js")))
            {
                string output = reader.ReadToEnd();
                regions = JsonConvert.DeserializeObject<KSRegion[]>(output);
            }

            if (regions == null || regions.Length == 0)
            {
                Console.WriteLine("failed to read configruation");
                return;
            }

            foreach (var item in CountryNames)
            {
                if (!ISOMapping.ContainsKey(item))
                {
                    // Console.WriteLine(item);
                }
                else
                {
                    var code = ISOMapping[item];

                    var continent = regions.FirstOrDefault(p => p.countries.Contains(code));
                    if (continent != null)
                    {
                        Console.WriteLine("{0}--{1}", code, continent.file);

                    }
                    else
                    {
                        // cannot find a configruation file for this country.
                        Console.WriteLine("{0}--{1}", code,  item);
                    }
                }
            }
        }
    }
}
