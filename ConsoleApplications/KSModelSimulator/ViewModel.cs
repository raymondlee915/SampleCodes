//----------------------------------------------------------------------- 
// <copyright file="ViewModel.cs" company="Dell Inc.">
//     Copyright (c) Dell Inc.. All rights reserved.
//     This material is confidential and a trade secret.  Permission to use this
//     work for any purpose must be obtained in writing from Dell, Inc.
// </copyright>
//-----------------------------------------------------------------------
namespace KSModelSimulator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Windows.Data;

    /// <summary>
    /// This class defines 
    /// </summary>
    public class ViewModel
    {
        private static Dictionary<string, string> isoMapping = null;

        public static Dictionary<string, string> ISOMapping
        {
            get
            {
                if (isoMapping == null)
                {
                    isoMapping = new Dictionary<string, string>();
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

                return isoMapping;
            }
        }

        public ViewModel()
        {
            IList<Pair> list = new List<Pair>();
            list.Add(new Pair("Inspiron 3Dcamera"));
            list.Add(new Pair("Inspiron 20 Model 3043"));
            list.Add(new Pair("Inspiron 20 Model 5348"));
            list.Add(new Pair("Inspiron 7348"));
            list.Add(new Pair("Inspiron 7352"));
            list.Add(new Pair("Inspiron 3542"));
            list.Add(new Pair("Inspiron 3543"));
            list.Add(new Pair("Inspiron 7548"));
            list.Add(new Pair("XPS 13 9343"));
            list.Add(new Pair("XPS 2720"));
            list.Add(new Pair("XPS 2222"));
            list.Add(new Pair("Inspiron 3333"));
            list.Add(new Pair("Latitude 9600"));
            list.Add(new Pair("Vostro 2800"));
            list.Add(new Pair("Optiplex 9600"));
            list.Add(new Pair("Precision 3547"));
            list.Add(new Pair("Venue 11 Pro 5130"));
            list.Add(new Pair("Alienware 15"));
            list.Add(new Pair("Optiplex 7020"));
            list = list.OrderBy(p => p.Text).ToList();
            _models = new CollectionView(list);

            var list2 = new List<Pair>();
            list2.Add(new Pair("ar"));
            list2.Add(new Pair("cs"));
            list2.Add(new Pair("da"));
            list2.Add(new Pair("de"));
            list2.Add(new Pair("el"));
            list2.Add(new Pair("en"));
            list2.Add(new Pair("es"));
            list2.Add(new Pair("fi"));
            list2.Add(new Pair("fr"));
            list2.Add(new Pair("he"));
            list2.Add(new Pair("hu"));
            list2.Add(new Pair("it"));
            list2.Add(new Pair("ja"));
            list2.Add(new Pair("ko"));
            list2.Add(new Pair("nb"));
            list2.Add(new Pair("nl"));
            list2.Add(new Pair("pl"));
            list2.Add(new Pair("pt-BR"));
            list2.Add(new Pair("pt"));
            list2.Add(new Pair("ro"));
            list2.Add(new Pair("ru"));
            list2.Add(new Pair("sk"));
            list2.Add(new Pair("sl"));
            list2.Add(new Pair("sv"));
            list2.Add(new Pair("tr"));
            list2.Add(new Pair("uk"));
            list2.Add(new Pair("zh-CN"));
            list2.Add(new Pair("zh-HK"));
            list2.Add(new Pair("zh-TW"));

            _languages = new CollectionView(list2);

            var countriesList = ISOMapping.Select(p => new Pair(p.Key, p.Value)).ToList();
            _countries = new CollectionView(countriesList);
        }

        private readonly CollectionView _models;

        public CollectionView Models
        {
            get { return _models; }
        }

        private readonly CollectionView _languages;

        public CollectionView Languages
        {
            get { return _languages; }
        } 


        private readonly CollectionView _countries;

        public CollectionView Countries
        {
            get { return _countries; }
        } 


        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class Pair
    {
        public Pair(string text)
        {
            this.Text = text;
        }

        public Pair(string text, string value)
        {
            this.Text = text;
            this.Value = value;
        }

        public string Text { get; set; }
        public string Value { get; set; }
    }
}

