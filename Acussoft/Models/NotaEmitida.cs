using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Accusoft.Models
{
    public class NotaEmitida
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string NumeroIdentificacao { get; set; }

        [Required]
        public DateTime DataEmissao { get; set; }

        public DateTime? DataCobranca { get; set; }

        public DateTime? DataPagamento { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Valor { get; set; }

        public required string DocumentoNotaFiscal { get; set; }

        public required string DocumentoBoleto { get; set; }

        [Required]
        public int StatusId { get; set; }

        [ForeignKey("StatusId")]
        public virtual StatusNota? StatusNota { get; set; }

        [Required]
        public int CredorId { get; set; }

        [ForeignKey("CredorId")]
        public virtual Credor? Credor { get; set; }
    }
}
