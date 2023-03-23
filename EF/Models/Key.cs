using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DOG.EF.Models
{
    [Index("Use", Name = "IX_Keys_Use")]
    public partial class Key
    {
        [Key]
        public string Id { get; set; } = null!;
        [Precision(10)]
        public int Version { get; set; }
        [Precision(7)]
        public DateTime Created { get; set; }
        public string? Use { get; set; }
        [StringLength(100)]
        public string Algorithm { get; set; } = null!;
        [Column("IsX509Certificate")]
        [Precision(1)]
        public bool IsX509certificate { get; set; }
        [Precision(1)]
        public bool DataProtected { get; set; }
        public string Data { get; set; } = null!;
    }
}
