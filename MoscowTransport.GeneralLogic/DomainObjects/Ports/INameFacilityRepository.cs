using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace NameFacilities.DomainObjects.Ports
{
    public interface IReadOnlyNameFacilityRepository
    {
        Task<NameFacility> GetNameFacility(long id);

        Task<IEnumerable<NameFacility>> GetAllNameFacilities();

        Task<IEnumerable<NameFacility>> QueryNameFacilities(ICriteria<NameFacility> criteria);

    }

    public interface INameFacilityRepository
    {
        Task AddNameFacility(NameFacility nameFacility);

        Task RemoveNameFacility(NameFacility nameFacility);

        Task UpdateNameFacility(NameFacility nameFacility);
    }
}
