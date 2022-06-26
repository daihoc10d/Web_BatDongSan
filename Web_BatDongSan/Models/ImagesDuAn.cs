namespace Web_BatDongSan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImagesDuAn")]
    public partial class ImagesDuAn
    {
        [Key]
        public int IDImagesDuAn { get; set; }

        public int IDDuAn { get; set; }

        [Required]
        [StringLength(500)]
        public string Link { get; set; }

        public int Rank { get; set; }

        public virtual DuAn DuAn { get; set; }
    }
}
