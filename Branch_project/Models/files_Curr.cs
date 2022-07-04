    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
namespace Branch_project.Models
{
    [Table("files_Curr")]
    public partial class files_Curr
    {
        [Key]
        public short currid { get; set; }

        [Required]
        public string currname { get; set; }

        public string currename { get; set; }

        public decimal? currrate { get; set; }

        public string operation { get; set; }

        public decimal? Mfactor { get; set; }

    }
}
