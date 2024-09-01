using Accusoft.Models;
using Microsoft.EntityFrameworkCore;

namespace Accusoft.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AccusoftContext(serviceProvider.GetRequiredService<DbContextOptions<AccusoftContext>>());

            if (context == null || context.NotaEmitida == null)
            {
                throw new ArgumentNullException("Null AccusoftContext");
            }

            // Verifica se já existem registros no banco.
            if (context.NotaEmitida.Any())
            {
                return;   // DB já foi inicializado
            }

            // Adiciona Credores
            var credor1 = new Credor { Nome = "Almeida Tech Solutions" };
            var credor2 = new Credor { Nome = "Transporte e Logística Silva Ltda" };
            var credor3 = new Credor { Nome = "Tech Solutions Ltda" };
            var credor4 = new Credor { Nome = "Global Trade S/A" };
            var credor5 = new Credor { Nome = "Medeiros e Filhos Comércio" };

            context.Credor.AddRange(credor1, credor2, credor3, credor4, credor5);

            // Adiciona Status
            var statusEmitida = new StatusNota { Descricao = "Emitida" };
            var statusCobrancaRealizada = new StatusNota { Descricao = "Cobrança realizada" };
            var statusPagamentoAtraso = new StatusNota { Descricao = "Pagamento em atraso" };
            var statusPagamentoRealizado = new StatusNota { Descricao = "Pagamento realizado" };
            var statusCancelada = new StatusNota { Descricao = "Cancelada" };
            var statusEmRevisao = new StatusNota { Descricao = "Em revisão" };

            context.StatusNota.AddRange(
                statusEmitida,
                statusCobrancaRealizada,
                statusPagamentoAtraso,
                statusPagamentoRealizado,
                statusCancelada,
                statusEmRevisao
            );

            context.SaveChanges();  // Salva para gerar IDs antes de associar nas notas

            // Adiciona Notas Emitidas
            context.NotaEmitida.AddRange(
                new NotaEmitida
                {
                    NumeroIdentificacao = "NF001",
                    DataEmissao = DateTime.Parse("2024-08-01"),
                    Valor = 1000.00M,
                    DocumentoNotaFiscal = "URL_Nota_Fiscal_1",
                    DocumentoBoleto = "URL_Boleto_1",
                    StatusId = statusEmitida.Id,
                    CredorId = credor1.Id
                },
                new NotaEmitida
                {
                    NumeroIdentificacao = "NF002",
                    DataEmissao = DateTime.Parse("2024-08-10"),
                    DataCobranca = DateTime.Parse("2024-08-15"),
                    Valor = 1500.00M,
                    DocumentoNotaFiscal = "URL_Nota_Fiscal_2",
                    DocumentoBoleto = "URL_Boleto_2",
                    StatusId = statusCobrancaRealizada.Id,
                    CredorId = credor2.Id
                },
                new NotaEmitida
                {
                    NumeroIdentificacao = "NF003",
                    DataEmissao = DateTime.Parse("2024-08-20"),
                    DataCobranca = DateTime.Parse("2024-08-25"),
                    DataPagamento = DateTime.Parse("2024-08-27"),
                    Valor = 2000.00M,
                    DocumentoNotaFiscal = "URL_Nota_Fiscal_3",
                    DocumentoBoleto = "URL_Boleto_3",
                    StatusId = statusPagamentoRealizado.Id,
                    CredorId = credor1.Id
                },
                new NotaEmitida
                {
                    NumeroIdentificacao = "NF004",
                    DataEmissao = DateTime.Parse("2024-09-01"),
                    DataCobranca = DateTime.Parse("2024-09-05"),
                    Valor = 2500.00M,
                    DocumentoNotaFiscal = "URL_Nota_Fiscal_4",
                    DocumentoBoleto = "URL_Boleto_4",
                    StatusId = statusEmRevisao.Id,
                    CredorId = credor3.Id
                },
                new NotaEmitida
                {
                    NumeroIdentificacao = "NF005",
                    DataEmissao = DateTime.Parse("2024-09-10"),
                    DataCobranca = DateTime.Parse("2024-09-15"),
                    DataPagamento = DateTime.Parse("2024-09-20"),
                    Valor = 3200.00M,
                    DocumentoNotaFiscal = "URL_Nota_Fiscal_5",
                    DocumentoBoleto = "URL_Boleto_5",
                    StatusId = statusPagamentoRealizado.Id,
                    CredorId = credor4.Id
                },
                new NotaEmitida
                {
                    NumeroIdentificacao = "NF006",
                    DataEmissao = DateTime.Parse("2024-09-15"),
                    Valor = 1800.00M,
                    DocumentoNotaFiscal = "URL_Nota_Fiscal_6",
                    DocumentoBoleto = "URL_Boleto_6",
                    StatusId = statusEmitida.Id,
                    CredorId = credor5.Id
                }
            );

            context.SaveChanges();
        }
    }
}
