using NameFacilities.ApplicationServices.Ports.Gateways.Database;
using NameFacilities.DomainObjects;
using NameFacilities.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NameFacilities.ApplicationServices.Repositories
{
    public class DbNameFacilityRepository : IReadOnlyNameFacilityRepository,
                                     INameFacilityRepository
    {
        private readonly INameFacilityDatabaseGateway _databaseGateway;

        public DbNameFacilityRepository(INameFacilityDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<NameFacility> GetNameFacility(long id)
            => await _databaseGateway.GetNameFacility(id);

        public async Task<IEnumerable<NameFacility>> GetAllNameFacilities()
            => await _databaseGateway.GetAllNameFacilities();

        public async Task<IEnumerable<NameFacility>> QueryNameFacilities(ICriteria<NameFacility> criteria)
            => await _databaseGateway.QueryNameFacilities(criteria.Filter);

        public async Task AddNameFacility(NameFacility nameFacility)
            => await _databaseGateway.AddNameFacility(nameFacility);

        public async Task RemoveNameFacility(NameFacility nameFacility)
            => await _databaseGateway.RemoveNameFacility(nameFacility);

        public async Task UpdateNameFacility(NameFacility nameFacility)
            => await _databaseGateway.UpdateNameFacility(nameFacility);
    }
}
