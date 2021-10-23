using Senac.GCP.API.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class EstadoModel : Model
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O Nome Do Estado Deve Ser Informado Obrigatóriamente.")]
        [StringLength(maximumLength: 255, ErrorMessage = "O Tamanho do Campo 'Nome' Não Pode Superar 255 Caracteres.")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A Sigla Do Estado Deve Ser Informado Obrigatóriamente.")]
        [StringLength(maximumLength: 255, ErrorMessage = "O Tamanho do Campo 'SiglaUF' Não Pode Superar 2 Caracteres.")]
        public string SiglaUF { get; set; }
    }
}