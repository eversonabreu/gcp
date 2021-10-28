using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Senac.GCP.API.Models
{
    public sealed class ArquivoModel : Model
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O 'Nome de Arquivo' Deve Ser Informado Obrigatóriamente.")]
        [StringLength(maximumLength: 255, ErrorMessage = "O Tamanho do Campo 'Nome de Arquivo' Não Pode Superar 255 Caracteres.")]
        public string Nome { get; set; }

        public string Extensao { get; set; }
 
        [Required(ErrorMessage = "O Campo 'Conteudo' Deve Ser Informado Obrigatóriamente.")]
        public byte[] Conteudo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Campo 'DataUpload' Deve Ser Informado Obrigatóriamente.")]
        public DateTime DataUpload { get; set; }

        public override void AdditionalValidations()
        {
            string nome = Nome;
            Nome = nome.GetFileName();
            Extensao = nome.GetFileExtension();
        }
    }
}