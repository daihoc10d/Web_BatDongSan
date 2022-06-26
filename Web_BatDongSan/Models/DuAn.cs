namespace Web_BatDongSan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DuAn")]
    public partial class DuAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DuAn()
        {
            Houses = new HashSet<House>();
            ImagesDuAns = new HashSet<ImagesDuAn>();
        }

        [Key]
        public int IDDuAn { get; set; }

        public int Block { get; set; }

        public int Floor { get; set; }

        public int House { get; set; }

        [Required]
        [StringLength(3000)]
        public string Sumary { get; set; }

        public int IDInvestor { get; set; }

        public byte State { get; set; }

        [Required]
        [StringLength(128)]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string GiaBan { get; set; }

        [Required]
        [StringLength(50)]
        public string GiaThue { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Investor Investor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<House> Houses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImagesDuAn> ImagesDuAns { get; set; }
    }
}
