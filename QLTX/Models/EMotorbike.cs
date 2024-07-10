using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace QLTX.Models
{
    public class EMotorbike
    {
		[Key]
		public int Id { get; set; }
		public int TypeMotorbikeId { get; set; }
		public TypeMotorbike TypeMotorbike { get; set; }

		[Required(ErrorMessage = "Số khung là bắt buộc")]
		[StringLength(20, ErrorMessage = "Số khung phải có độ dài từ {2} đến {1} ký tự.", MinimumLength = 2)]
		[Display(Name = "Số khung")]
		public string VinNumber { get; set; }

		[Required(ErrorMessage = "Biển số xe là bắt buộc")]
		[StringLength(20, ErrorMessage = "Biển số xe phải có độ dài từ {2} đến {1} ký tự.", MinimumLength = 2)]
		[Display(Name = "Biển số xe")]
		public string License { get; set; }

		[StringLength(255, ErrorMessage = "Mô tả không vượt quá {1} ký tự.")]
		public string? Description { get; set; }
        public EMotorbikeStatus Status { get; set; } = EMotorbikeStatus.Ready;

		[StringLength(500, ErrorMessage = "Đường dẫn ảnh không vượt quá {1} ký tự.")]
		public string? ImageUrl { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationTime { get; set; }
        public string? UpdatedBy { get; set;}
        public DateTime? UpdationTime { get; set; }
		public bool IsDelete { get; set; }

    }

    public enum EMotorbikeStatus
    {
		[Display(Name = "Sẵn sàng")]
		Ready = 0,

		[Display(Name = "Đang hỏng")]
		Broken = 1,

		[Display(Name = "Đang thuê")]
		Renting = 2
	}
}

