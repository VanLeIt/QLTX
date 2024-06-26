﻿using System.ComponentModel.DataAnnotations;

namespace QLTX.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationTime { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdationTime { get; set; }
        public bool IsDelete { get; set; }
        public List<TypeMotorbike> TypeMotorbikes { get; set; }
    }
}
