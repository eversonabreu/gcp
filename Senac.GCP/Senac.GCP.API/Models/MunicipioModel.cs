using Senac.GCP.API.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class MunicipioModel : Model
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Nome' do Município é obrigatório.")]
        [StringLength(maximumLength: 255, ErrorMessage = "O campo 'Nome' do Município não pode ultrapassar 255 carecteres.")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'CodigoIBGE' do Município é obrigatório.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "O código do IBGE é inválido.")]
        public int CodigoIBGE { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'IdEstado' do Município é obrigatório.")]
        [Range(minimum: 1, maximum: long.MaxValue, ErrorMessage = "O código do IdEstado é inválido.")]
        public long IdEstado { get; set; }
    }
}
