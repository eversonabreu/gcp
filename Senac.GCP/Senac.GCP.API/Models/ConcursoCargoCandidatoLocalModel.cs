using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Enums;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Extensions;
using System;
using System.ComponentModel.DataAnnotations;


namespace Senac.GCP.API.Models
{
    public sealed class ConcursoCargoCandidatoLocalModel : Model
    {
        public long IdInscricao{ get; set; }

        public long IdConcursoFaseLocai { get; set; }

    }
}