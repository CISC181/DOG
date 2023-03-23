using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DOG.EF.Models
{
    [Index("DeviceCode1", Name = "IX_DeviceCodes_DeviceCode", IsUnique = true)]
    [Index("Expiration", Name = "IX_DeviceCodes_Expiration")]
    public partial class DeviceCode
    {
        [Key]
        [StringLength(200)]
        public string UserCode { get; set; } = null!;
        [Column("DeviceCode")]
        [StringLength(200)]
        public string DeviceCode1 { get; set; } = null!;
        [StringLength(200)]
        public string? SubjectId { get; set; }
        [StringLength(100)]
        public string? SessionId { get; set; }
        [StringLength(200)]
        public string ClientId { get; set; } = null!;
        [StringLength(200)]
        public string? Description { get; set; }
        [Precision(7)]
        public DateTime CreationTime { get; set; }
        [Precision(7)]
        public DateTime Expiration { get; set; }
        [Column(TypeName = "NCLOB")]
        public string Data { get; set; } = null!;
    }
}
