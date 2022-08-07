using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.LibraryService
{
    public class LibraryService : ILibraryService
    {
        private readonly IGenericRepository<Library> _genericLibraryRepository;
        public LibraryService(IGenericRepository<Library> genericLibraryRepository)
        {
            _genericLibraryRepository = genericLibraryRepository;
        }

        public async Task<IEnumerable<Library>> GetNearestLibraries(Point userLocation, int count = 10)
        {
            return await _genericLibraryRepository.GetAllByPredicate(x =>
            Math.Sqrt(
                       Math.Pow(userLocation.Latitude - x.Location.Latitude, 2)
                       +
                       Math.Pow(userLocation.Longitude - x.Location.Longitude, 2)) < 10);

            //    Math.Sqrt(
            //               Math.Pow(10 - x.Location.Latitude, 2)
            //               +
            //               Math.Pow(5 - x.Location.Longitude, 2)) < 10);
        }
    }
}
