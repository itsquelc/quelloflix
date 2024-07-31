using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace QuelloFlix.Models;

[Table("AppUser")]

    public class AppUser
    {
        [Key]
        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public IdentityUser UserAccount { get; set; }

        [Required] 
        [StringLength(60)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Required]   
        public DateTime Birthday { get; set; }

        [StringLength(300)]
        public string Photo { get; set; }
    }
