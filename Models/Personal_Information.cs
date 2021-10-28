namespace Project5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Personal Information")]
    public partial class Personal_Information
    {
        public int ID { get; set; }

        [Column("First Name")]
        [Required]
        [StringLength(20)]
        public string First_Name { get; set; }

        [Column("Last Name ")]
        [Required]
        [StringLength(20)]
        public string Last_Name_ { get; set; }

        [Column("National Id ")]
        public int National_Id_ { get; set; }

        [Column("Phone Number ")]
        [StringLength(11)]
        public string Phone_Number_ { get; set; }

        public string ImagePath { get; set; }

        [StringLength(200)]
        public string ImageName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }
    }
}
