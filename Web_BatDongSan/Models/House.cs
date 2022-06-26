namespace Web_BatDongSan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("House")]
    public partial class House
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public House()
        {
            ImagesHouses = new HashSet<ImagesHouse>();
        }

        [Key]
        public int IDHouse { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [Required]
        [StringLength(128)]
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(300)]
        public string Sumary { get; set; }

        public int IDDuAn { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public int BedRoom { get; set; }

        public int Area { get; set; }

        public decimal Price { get; set; }

        public byte State { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual DuAn DuAn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImagesHouse> ImagesHouses { get; set; }
    }
}
