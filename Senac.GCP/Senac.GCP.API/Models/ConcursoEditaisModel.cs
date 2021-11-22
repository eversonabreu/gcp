using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public class ConcursoEditaisModel : Model
    {
        [DateOnly]
        public DateTime DataEdital { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A 'Descrição' deve ser informada obrigatoriamente.")]
        [StringLength(maximumLength: 255, ErrorMessage = "O tamanho do campo 'Descrição' não pode superar 255 caractéres.")]
        [StringOptions(TrimSpace = Domain.Enums.TrimSpaceEnum.Both)]
        public string Descricao { get; set; }

        public long IdConcurso { get; set; }

        public long IdArquivo { get; set; }
    }
}