using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebAPI.Models
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public Guid MaHangHoa { get; set; }
        [Required]
        public string TenHangHoa { get; set; }
        public string MoTa { get; set; }
        [Range(0,double.MaxValue)]
        public Double DonGia { get; set; }
    }

}
