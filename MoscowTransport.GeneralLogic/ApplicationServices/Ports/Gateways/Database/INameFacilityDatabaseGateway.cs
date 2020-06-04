using NameFacilities.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NameFacilities.ApplicationServices.Ports.Gateways.Database
{
    public interface INameFacilityDatabaseGateway
    {
        Task AddNameFacility(NameFacility nameFacility);

        Task RemoveNameFacility(NameFacility nameFacility);

        Task UpdateNameFacility(NameFacility nameFacility);

        Task<NameFacility> GetNameFacility(long id);

        Task<IEnumerable<NameFacility>> GetAllNameFacilities();

        Task<IEnumerable<NameFacility>> QueryNameFacilities(Expression<Func<NameFacility, bool>> filter);
    }
}
