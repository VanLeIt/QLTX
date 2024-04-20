namespace QLTX.Models
{
    public class EMotorbike
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string License { get; set; }
        public EMotorbikeStatus  Status { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
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

