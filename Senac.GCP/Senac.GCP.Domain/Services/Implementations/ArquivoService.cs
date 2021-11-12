using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class ArquivoService : Service<ArquivoEntity>, IArquivoService
    {
        public ArquivoService(IArquivoRepository arquivoRepository, IHttpContextAccessor httpContextAccessor)
            : base(arquivoRepository, httpContextAccessor)
        {
        }

        public override void BeforePost(ArquivoEntity entity)
        {
            entity.DataUpload = DateTime.Now;
        }

        public decimal ObterTamanhoEmMegaBytes(byte[] arquivo)
        {
            if (arquivo is null)
                throw new ArgumentNullException("O arquivo é nulo");

            const int tamanhoEmMegaByte = 1024 * 1024;
            const decimal tamanhoMaximoAceito = tamanhoEmMegaByte * 10;

            if (arquivo.Length > tamanhoMaximoAceito)
                throw new BusinessException("O arquivo não suportado, o mesmo deve conter no maximo 10MB");

            var tamanhoEmMegaBytes = arquivo.Length / tamanhoEmMegaByte;
            return tamanhoEmMegaBytes;
        }
    }
}