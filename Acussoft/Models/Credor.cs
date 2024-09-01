using System.ComponentModel.DataAnnotations;

namespace Accusoft.Models
{
    public class Credor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public required string Nome { get; set; }

        public virtual ICollection<NotaEmitida>? NotasEmitidas { get; set; }
    }
}
