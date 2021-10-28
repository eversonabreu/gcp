using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Senac.GCP.API.Models
{
    public sealed class TipoCotaModel : Model
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Codigo' Deve Ser Informado Obrigatóriamente.")]
        [StringLength(maximumLength: 50, ErrorMessage = "O Tamanho do Campo 'Codigo' Não Pode Superar 50 Caracteres.")]
        public string Codigo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Descricao' Deve Ser Informado Obrigatóriamente.")]
        [StringLength(maximumLength: 255, ErrorMessage = "O Tamanho do Campo 'Descricao' Não Pode Superar 255 Caracteres.")]
        public string Descricao { get; set; }
    }
}