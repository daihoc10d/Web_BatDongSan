namespace Web_BatDongSan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImagesHouse")]
    public partial class ImagesHouse
    {
        [Key]
        public int IDImagesHouse { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int IDHouse { get; set; }

        [Required]
        [StringLength(500)]
        public string Link { get; set; }

        public int Rank { get; set; }

        public virtual House House { get; set; }
    }
}
