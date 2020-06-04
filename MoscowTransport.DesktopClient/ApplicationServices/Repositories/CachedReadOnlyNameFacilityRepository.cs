using NameFacilities.ApplicationServices.Ports.Cache;
using NameFacilities.DomainObjects;
using NameFacilities.DomainObjects.Ports;
using NameFacilities.DomainObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NameFacilities.ApplicationServices.Repositories
{
    public class CachedReadOnlyNameFacilityRepository : ReadOnlyNameFacilityRepositoryDecorator
    {
        private readonly IDomainObjectsCache<NameFacility> _nameFacilitiesCache;

        public CachedReadOnlyNameFacilityRepository(IReadOnlyNameFacilityRepository routeRepository, 
                                             IDomainObjectsCache<NameFacility> routesCache)
            : base(routeRepository)
            => _nameFacilitiesCache = routesCache;

        public async override Task<NameFacility> GetNameFacility(long id)
            => _nameFacilitiesCache.GetObject(id) ?? await base.GetNameFacility(id);

        public async override Task<IEnumerable<NameFacility>> GetAllNameFacilities()
            => _nameFacilitiesCache.GetObjects() ?? await base.GetAllNameFacilities();

        public async override Task<IEnumerable<NameFacility>> QueryNameFacilities(ICriteria<NameFacility> criteria)
            => _nameFacilitiesCache.GetObjects()?.Where(criteria.Filter.Compile()) ?? await base.QueryNameFacilities(criteria);

    }
}
