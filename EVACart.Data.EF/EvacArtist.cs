//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EVACart.Data.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class EvacArtists
    {
        public EvacArtists()
        {
            this.Departments = new HashSet<Department>();
            this.Events = new HashSet<Event>();
        }
    
        public int ArtistID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> DateOfSeparation { get; set; }
        public System.DateTime D_O_B { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public int DepartmentID { get; set; }
        public bool IsActive { get; set; }
        public string Phone { get; set; }
        public string UserId { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
    
        public virtual ICollection<Department> Departments { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
