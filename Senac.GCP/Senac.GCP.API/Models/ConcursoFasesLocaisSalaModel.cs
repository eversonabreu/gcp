using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class ConcursoFasesLocaisSalaModel : Model
    {
        public long IdConcursoFasesLocais { get; set; }

        [StringLength(maximumLength: 255, 
            ErrorMessage = "O tamanho do campo 'Descrição' não pode superar 255 Caracteres.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Descrição' deve ser informado obrigatoriamente.")]
        public string Descricao { get; set; }

        //verificar quais tratamentos devo fazer aqui
        public int QuantidadeDeCarteiras { get; set; }
        public int QuantidadeDeCarteirasPcd { get; set; }

    }
}