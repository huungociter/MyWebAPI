using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebAPI.Data
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public Guid Mahh { get; set; }

        [Required]
        [MaxLength(100)]
        public string TenHh { get; set; }
        public string MoTa {  get; set; }
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }
    }
}
