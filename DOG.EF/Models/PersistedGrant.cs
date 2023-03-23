using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DOG.EF.Models
{
    [Index("ConsumedTime", Name = "IX_PersistedGrants_ConsumedTime")]
    [Index("Expiration", Name = "IX_PersistedGrants_Expiration")]
    [Index("SubjectId", "ClientId", "Type", Name = "IX_PersistedGrants_SubjectId_ClientId_Type")]
    [Index("SubjectId", "SessionId", "Type", Name = "IX_PersistedGrants_SubjectId_SessionId_Type")]
    public partial class PersistedGrant
    {
        [Key]
        [StringLength(200)]
        public string Key { get; set; } = null!;
        [StringLength(50)]
        public string Type { get; set; } = null!;
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
        public DateTime? Expiration { get; set; }
        [Precision(7)]
        public DateTime? ConsumedTime { get; set; }
        [Column(TypeName = "NCLOB")]
        public string Data { get; set; } = null!;
    }
}
