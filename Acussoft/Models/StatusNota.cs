using System.ComponentModel.DataAnnotations;

namespace Accusoft.Models
{
    public class StatusNota
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Descricao { get; set; }

        public virtual ICollection<NotaEmitida>? NotasEmitidas { get; set; }
    }
}
