using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace EVACart.Data.EF
{
    public partial class EvacArtistsMetaData
    {
        public int ArtistID { get; set; }

        [Required(ErrorMessage = "Must Enter First Name")]
        [Display(Name = "First Name :")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Must Enter Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Must Enter Artists' Address")]
        [Display(Name = "Address :")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2 :")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Must Enter Artists' City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Must Enter Artists' State")]
        [StringLength(2, ErrorMessage = "State Abbreviation Only")]
        public string State { get; set; }

        [Required(ErrorMessage = "Must Enter Artists'Zip Code")]
        public string Zip { get; set; }

        [Display(Name = "Phone :")]
        public string Phone { get; set; }

        [Display(Name = "Email :")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Must Enter Artists' Date Of Birth")]
        [Display(Name = "D.O.B. :")]
        public System.DateTime D_O_B { get; set; }

        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Must Enter Employees' Hire Date")]
        [Display(Name = "Start Date :")]
        public System.DateTime StartDate { get; set; }

        public string UserId { get; set; }

        public string Image { get; set; }

        public string Notes { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        [Display(Name = "Date Of Separation:")]
        public Nullable<System.DateTime> DateOfSeparation { get; set; }
    }
    [MetadataType(typeof(EvacArtistsMetaData))]
    public partial class EvacArtists { }




    public partial class DepartmentMetaData
    {


        public int DepartmentID { get; set; }
        [Display(Name = "Department :")]
        [Required(ErrorMessage = "Must Enter a Department")]
        public string Name { get; set; }
        [Display(Name = "Department Info :")]
        public string Description { get; set; }
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        [Display(Name = "Available Boarding")]
        public string BoardingAvailable { get; set; }
        public int ArtistID { get; set; }
        public int StaffID { get; set; }
    }

    [MetadataType(typeof(DepartmentMetaData))]
    public partial class Department { }


    public partial class StaffMetadeta
    {

        public int StaffID { get; set; }

        [Required(ErrorMessage = "Must Enter First Name")]
        [Display(Name = "First Name :")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Must Enter Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Must Enter Artists' Address")]
        [Display(Name = "Address :")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2 :")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Must Enter Artists' City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Must Enter Artists' State")]
        [StringLength(2, ErrorMessage = "State Abbreviation Only")]
        public string State { get; set; }

        [Required(ErrorMessage = "Must Enter Artists'Zip Code")]
        public string Zip { get; set; }

        [Display(Name = "Phone 1 :")]
        public string Phone1 { get; set; }

        [Display(Name = "Phone 2 :")]
        public string Phone2 { get; set; }

        [Display(Name = "Email :")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Must Enter Artists' Date Of Birth")]
        [Display(Name = "D.O.B. :")]
        public System.DateTime D_O_B { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Must Enter Employees' Hire Date")]
        [Display(Name = "Start Date :")]
        public System.DateTime StartDate { get; set; }

        public string UserID { get; set; }

        public string Image { get; set; }

        public string Notes { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "Date Of Separation:")]
        public Nullable<System.DateTime> DateOfSeparation { get; set; }
    }
    [MetadataType(typeof(StaffMetadeta))]
    public partial class Staff { }

    public partial class GalleryMetaData
    {


        public int GalleryID { get; set; }
        [Display(Name = "Gallery Name :")]
        [Required(ErrorMessage = "Must Enter a Gallery Name")]
        public string Name { get; set; }
        [Display(Name = "Address 1 :")]
        [Required(ErrorMessage = "Must Enter Address")]
        public string Address1 { get; set; }
        [Display(Name = "Address 2 :")]
        public string Address2 { get; set; }
        [Required(ErrorMessage = "Must Enter State")]
        [StringLength(2, ErrorMessage = "State Abbreviation Only")]
        [Display(Name = "State :")]
        public string State { get; set; }

        [Required(ErrorMessage = "Must Enter Zip Code")]
        [Display(Name = "Zip Code :")]
        public string Zip { get; set; }


        [Required(ErrorMessage = "Must Enter Phone")]
        [Display(Name = "Phone :")]
        public string Phone { get; set; }

        [Display(Name = "Email :")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Must Enter Contact Name")]
        [Display(Name = "Contact Person :")]
        public string ContactName { get; set; }

        public int ArtistID { get; set; }
        public int EventID { get; set; }
        public int DepartmentID { get; set; }
    }

    [MetadataType(typeof(GalleryMetaData))]
    public partial class Gallery { }


    public partial class EventsMetaData
    {


        public int EventID { get; set; }

        [Display(Name = "Event Name :")]
        [Required(ErrorMessage = "Must Enter an Event Name")]
        public string EventName { get; set; }

        [Display(Name = "Address 1 :")]
        [Required(ErrorMessage = "Must Enter Address")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2 :")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Must Enter State")]
        [StringLength(2, ErrorMessage = "State Abbreviation Only")]
        [Display(Name = "State :")]
        public string State { get; set; }

        [Required(ErrorMessage = "Must Enter Zip Code")]
        [Display(Name = "Zip Code :")]
        public string Zip { get; set; }


        [Required(ErrorMessage = "Must Enter Phone")]
        [Display(Name = "Phone :")]
        public string Phone { get; set; }
        
        [Display(Name = "Event Description :")]
        public string Description { get; set; }

        public string Image { get; set; }

        public int ArtistID { get; set; }

        public int GalleryID { get; set; }

        public int DepartmentID { get; set; }

        public int StaffID { get; set; }



    }
    [MetadataType(typeof(EventsMetaData))]
    public partial class Event { }


}


