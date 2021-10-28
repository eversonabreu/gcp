using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System;

namespace Senac.GCP.Domain.Entities
{
    public sealed class ArquivoEntity : Entity
    {
        public string Nome { get; set; }

        public string Extensao { get; set; }

        public byte[] Conteudo { get; set; }

        [NotUpdated]
        public DateTime DataUpload { get; set; }
    }
}
