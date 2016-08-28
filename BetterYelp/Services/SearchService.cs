using BetterYelp.Data;
using BetterYelp.Models;
using BetterYelp.Models.Entities;
using BetterYelp.Models.UnitOfWork;
using BetterYelp.Models.ViewModels;
using BetterYelp.ServiceConnectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterYelp.Services
{
    public class SearchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SearchContext _context;
        private readonly YelpClient _yelpClient;

        private readonly YelpSettings _settings;

        public SearchService(IUnitOfWork unitOfWork)
        {
            _context = new SearchContext();
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
