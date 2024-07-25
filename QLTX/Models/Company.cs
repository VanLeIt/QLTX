using System.ComponentModel.DataAnnotations;

namespace QLTX.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

		[Required(ErrorMessage = "Tên hãng là bắt buộc")]
		[StringLength(100, ErrorMessage = "Tên hãng phải có độ dài từ {2} đến {1} ký tự.", MinimumLength = 2)]
		[Display(Name = "Tên hãng")]
		public string Name { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }
        public DateTime CreationTime { get; set; }

        [StringLength(100)]
        public string? UpdatedBy { get; set; }
        public DateTime? UpdationTime { get; set; }
        public bool IsDelete { get; set; }
        public List<TypeMotorbike> TypeMotorbikes { get; set; }
    }
}
