using WeShouldGo.Data;
using WeShouldGo.Models;
using WeShouldGo.Models.Entities;
using WeShouldGo.Models.UnitOfWork;
using WeShouldGo.Models.ViewModels;
using WeShouldGo.ServiceConnectors;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeShouldGo.Services
{
    public class SearchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbContext _context;
        private readonly YelpClient _yelpClient;

        private readonly YelpSettings _settings;

        public SearchService(IUnitOfWork unitOfWork, DbContext context)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public object SearchYelp(SearchViewModel vm)
        {
            var entity = Search.DtoToEntity(vm);

            var results = _yelpClient.SearchBusinesses(entity.Term, entity.Location);

            return results;
        }
    }
}
