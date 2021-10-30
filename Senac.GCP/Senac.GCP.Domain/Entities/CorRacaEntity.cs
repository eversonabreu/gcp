using Senac.GCP.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senac.GCP.Domain.Entities
{
    class CorRacaEntity : Entity
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
