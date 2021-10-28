using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class NacionalidadeModel : Model
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo'Nacionalidade' Deve ser informada obrigatóriamente.")]
        [StringLength(maximumLength: 255, ErrorMessage = "O tamanho do campo 'Nacionalidade' Não pode superar 255 caracteres.")]
        public string Nome { get; set; }
    }
}