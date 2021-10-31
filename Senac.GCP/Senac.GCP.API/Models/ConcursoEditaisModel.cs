using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senac.GCP.API.Models
{
    public class ConcursoEditaisModel : Model
    {
        [NotUpdated]
        public DateTime DataEdital { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A 'Descrição' deve ser informada obrigatoriamente.")]
        [StringLength(maximumLength: 255, ErrorMessage = "O tamanho do campo 'Descrição' não pode superar 255 caractéres.")]
        public string Descricao { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O 'IdConcurso' deve ser informada obrigatoriamente.")]
        [Range(minimum:1, maximum:long.MaxValue, ErrorMessage = "O campo 'IdMunicipio' é inválido!")]
        public long IdConcurso { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O 'IdArquivo' deve ser informada obrigatoriamente.")]
        [Range(minimum: 1, maximum: long.MaxValue, ErrorMessage = "O campo 'IdArquivo' é inválido!")]
        public long IdArquivo { get; set; }
    }
}
