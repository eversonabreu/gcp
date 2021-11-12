using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class CargoService : Service<CargoEntity>, ICargoService
    {
        public CargoService(ICargoRepository CargoRepository, IHttpContextAccessor httpContextAccessor)
            : base(CargoRepository, httpContextAccessor)
        {
        }
    }
}