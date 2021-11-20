using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class ArquivoModel : Model
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O 'Nome de Arquivo' Deve Ser Informado Obrigatóriamente.")]
        [StringLength(maximumLength: 255, ErrorMessage = "O Tamanho do Campo 'Nome de Arquivo' Não Pode Superar 255 Caracteres.")]
        public string Nome { get; set; }

        public string Extensao { get; set; }

        public byte[] Conteudo { get; set; }

        [DateOnly]
        public DateTime DataUpload { get; set; }

        public override void OnValidate()
        {
            string nome = Nome;
            Nome = nome.GetFileName();
            Extensao = nome.GetFileExtension();

            if (Conteudo is null || Conteudo.Length == 0)
                throw new BusinessException("O arquivo deve ser enviado obrigatóriamente");

        }
    }
}