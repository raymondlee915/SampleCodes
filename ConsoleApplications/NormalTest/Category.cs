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
    
    public partial class Category
    {
        public Category()
        {
            this.Notifications = new HashSet<Notification>();
        }
    
        public string Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
