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
        Ready = 0,
        Broken = 1,
        Renting = 2,
    }
}

