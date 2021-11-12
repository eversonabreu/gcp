using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;

<<<<<<< HEAD
=======

>>>>>>> 740243cc1b75e4bd28c0382570a27f0bac986808
namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class ConcursoFaseCargoService : Service<ConcursoFaseCargoEntity>, IConcursoFaseCargoService
    {
<<<<<<< HEAD
        public ConcursoFaseCargoService(IConcursoFaseCargoRepository concursoFaseCargoRepository, IHttpContextAccessor httpContextAccessor)
            : base(concursoFaseCargoRepository, httpContextAccessor)
        {
        }
    }
}
=======
        public ConcursoFaseCargoService(IConcursoFaseCargoRepository ConcursoFaseCargoRepository, IHttpContextAccessor httpContextAccessor)
            : base(ConcursoFaseCargoRepository, httpContextAccessor)
        {
        }
    }
}
>>>>>>> 740243cc1b75e4bd28c0382570a27f0bac986808
