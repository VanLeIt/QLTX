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
		public string VinNumber { get; set; }
		public string License { get; set; }
		public string? Description { get; set; }
        public EMotorbikeStatus Status { get; set; } = EMotorbikeStatus.Ready;
        
        public string CreatedBy { get; set; }
        public DateTime CreationTime { get; set; }
        public string? UpdatedBy { get; set;}
        public DateTime? UpdationTime { get; set; }

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

