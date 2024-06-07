using System.ComponentModel.DataAnnotations;

namespace Féléves_Szerveroldali.Models
{
    public class Csapat
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string? Feladat { get; set; }
        public List<string> Csapattagok { get; set; }
        public string? OwnerId { get; set; }
    }
}
