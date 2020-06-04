using NameFacilities.ApplicationServices.Ports.Cache;
using NameFacilities.DomainObjects;
using NameFacilities.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NameFacilities.InfrastructureServices.Repositories
{
    public class NetworkNameFacilityRepository : NetworkRepositoryBase, IReadOnlyNameFacilityRepository
    {
        private readonly IDomainObjectsCache<NameFacility> _nameFacilityCache;

        public NetworkNameFacilityRepository(string host, ushort port, bool useTls, IDomainObjectsCache<NameFacility> nameFacilityCache)
            : base(host, port, useTls)
            => _nameFacilityCache = nameFacilityCache;

        public async Task<NameFacility> GetNameFacility(long id)
            => CacheAndReturn(await ExecuteHttpRequest<NameFacility>($"NameFacility/{id}"));

        public async Task<IEnumerable<NameFacility>> GetAllNameFacilities()
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<NameFacility>>($"NameFacility"), allObjects: true);

        public async Task<IEnumerable<NameFacility>> QueryNameFacilities(ICriteria<NameFacility> criteria)
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<NameFacility>>($"NameFacility"), allObjects: true)
               .Where(criteria.Filter.Compile());

        public async Task<IEnumerable<NameFacility>> GetTransportOrganizationRoutes(long transportOrganizationId)
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<NameFacility>>($"routes/organizations/{transportOrganizationId}"));

        private IEnumerable<NameFacility> CacheAndReturn(IEnumerable<NameFacility> nameFacilities, bool allObjects = false)
        {
            if (allObjects)
            {
                _nameFacilityCache.ClearCache();
            }
            _nameFacilityCache.UpdateObjects(nameFacilities, DateTime.Now.AddDays(1), allObjects);
            return nameFacilities;
        }

        private NameFacility CacheAndReturn(NameFacility nameFacility)
        {
            _nameFacilityCache.UpdateObject(nameFacility, DateTime.Now.AddDays(1));
            return nameFacility;
        }
    }
}
