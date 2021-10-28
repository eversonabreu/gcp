using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class ClassificacaoDoencaModel : Model
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O 'CID' deve der informado obrigatóriamente.")]
        [StringLength(maximumLength: 3, ErrorMessage = "O Tamanho do Campo 'CID' não pode superar 3 caracteres.")]
        public string Cid { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A 'Descrição' da doença deve der informado obrigatóriamente.")]
        [StringLength(maximumLength: 255, ErrorMessage = "O Tamanho do Campo 'Descrição' não pode superar 255 caracteres.")]
        public string Descricao { get; set; }
    }
}