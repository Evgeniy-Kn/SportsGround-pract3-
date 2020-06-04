using NameFacilities.DomainObjects;
using NameFacilities.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NameFacilities.DomainObjects.Repositories
{
    public abstract class ReadOnlyNameFacilityRepositoryDecorator : IReadOnlyNameFacilityRepository
    {
        private readonly IReadOnlyNameFacilityRepository _nameFacilityRepository;

        public ReadOnlyNameFacilityRepositoryDecorator(IReadOnlyNameFacilityRepository nameFacilityRepository)
        {
            _nameFacilityRepository = nameFacilityRepository;
        }

        public virtual async Task<IEnumerable<NameFacility>> GetAllNameFacilities()
        {
            return await _nameFacilityRepository?.GetAllNameFacilities();
        }

        public virtual async Task<NameFacility> GetNameFacility(long id)
        {
            return await _nameFacilityRepository?.GetNameFacility(id);
        }

        public virtual async Task<IEnumerable<NameFacility>> QueryNameFacilities(ICriteria<NameFacility> criteria)
        {
            return await _nameFacilityRepository?.QueryNameFacilities(criteria);
        }
    }
}
