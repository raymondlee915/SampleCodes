//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NormalTest
{
    using System;
    using System.Collections.Generic;
    
    public partial class Locale
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DellLanguageId { get; set; }
    
        public virtual DellLanguage DellLanguage { get; set; }
    }
}
