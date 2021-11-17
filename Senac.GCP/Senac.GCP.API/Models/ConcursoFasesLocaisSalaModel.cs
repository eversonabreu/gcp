using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Enums;
using Senac.GCP.Domain.Exceptions;
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

        public override void AdditionalValidations()
        {
            if (QuantidadeDeCarteiras < 0 || QuantidadeDeCarteirasPcd < 0)
                throw new BusinessException("O valor inserido em uma das colunas de quantidade é inferior a 0 ");

            if (QuantidadeDeCarteiras == 0 && QuantidadeDeCarteirasPcd == 0)
                throw new BusinessException("Os valores inseridos não correspondem a uma quantidade de carteiras valida, pois não ha carteiras ");
        }
    }
}