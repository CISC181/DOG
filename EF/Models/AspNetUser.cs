using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DOG.EF.Models
{
    [Index("NormalizedEmail", Name = "EmailIndex")]
    [Index("NormalizedUserName", Name = "UserNameIndex", IsUnique = true)]
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserTokens = new HashSet<AspNetUserToken>();
            Roles = new HashSet<AspNetRole>();
        }

        [Key]
        public string Id { get; set; } = null!;
        [StringLength(256)]
        public string? UserName { get; set; }
        [StringLength(256)]
        public string? NormalizedUserName { get; set; }
        [StringLength(256)]
        public string? Email { get; set; }
        [StringLength(256)]
        public string? NormalizedEmail { get; set; }
        [Precision(1)]
        public bool EmailConfirmed { get; set; }
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public string? PhoneNumber { get; set; }
        [Precision(1)]
        public bool PhoneNumberConfirmed { get; set; }
        [Precision(1)]
        public bool TwoFactorEnabled { get; set; }
        [Precision(7)]
        public DateTimeOffset? LockoutEnd { get; set; }
        [Precision(1)]
        public bool LockoutEnabled { get; set; }
        [Precision(10)]
        public int AccessFailedCount { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        [InverseProperty("User")]
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Users")]
        public virtual ICollection<AspNetRole> Roles { get; set; }
    }
}
