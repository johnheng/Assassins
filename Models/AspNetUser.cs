//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assassins.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AspNetUser
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string Family { get; set; }
        public string Description { get; set; }
        public int Kills { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public bool Alive { get; set; }
        public Nullable<int> GameID { get; set; }
        public Nullable<int> CurrentTargetID { get; set; }
        public string CurrentTarget { get; set; }
        public bool Admin { get; set; }
    }
}
