using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Enums;
using Senac.GCP.Domain.Exceptions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class CargoModel : Model
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Descrição' Deve Ser Informado Obrigatóriamente.")]
        [StringLength(maximumLength: 255, ErrorMessage = "O Tamanho do Campo 'Descrição' Não Pode Superar 255 Caracteres.")]
        public string Descricao { get; set; }

        public long IdNivelEscolaridade { get; set; }

        public int Codigo { get; set; }
    }
}
