using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }

        public async Task<CastResponseModel> GetCastById(int castId)
        {
            var movieCast = await _castRepository.GetCastById(castId);
            if (movieCast == null) return null;
            var castModel = new CastResponseModel
            {
                Id = movieCast.CastId,
                Name = movieCast.Cast.Name,
                Character = movieCast.Character,
                ProfilePath = movieCast.Cast.ProfilePath
            };
            
            return castModel;
        }
    }
}
