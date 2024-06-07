using System.ComponentModel.DataAnnotations;

namespace Féléves_Szerveroldali.Models
{
    public class Feladat
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string? OwnerId { get; set; }
    }
}
