using NameFacilities.DomainObjects;
using NameFacilities.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NameFacilities.ApplicationServices.Repositories
{
    public class InMemoryNameFacilityRepository : IReadOnlyNameFacilityRepository,
                                           INameFacilityRepository 
    {
        private readonly List<NameFacility> _nameFacilities = new List<NameFacility>();

        public InMemoryNameFacilityRepository(IEnumerable<NameFacility> nameFacilities = null)
        {
            if (nameFacilities != null)
            {
                _nameFacilities.AddRange(nameFacilities);
            }
        }

        public Task AddNameFacility(NameFacility nameFacility)
        {
            _nameFacilities.Add(nameFacility);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<NameFacility>> GetAllNameFacilities()
        {
            return Task.FromResult(_nameFacilities.AsEnumerable());
        }

        public Task<NameFacility> GetNameFacility(long id)
        {
            return Task.FromResult(_nameFacilities.Where(r => r.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<NameFacility>> QueryNameFacilities(ICriteria<NameFacility> criteria)
        {
            return Task.FromResult(_nameFacilities.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveNameFacility(NameFacility nameFacility)
        {
            _nameFacilities.Remove(nameFacility);
            return Task.CompletedTask;
        }

        public Task UpdateNameFacility(NameFacility nameFacility)
        {
            var foundRoute = GetNameFacility(nameFacility.Id).Result;
            if (foundRoute == null)
            {
                AddNameFacility(nameFacility);
            }
            else
            {
                if (foundRoute != nameFacility)
                {
                    _nameFacilities.Remove(foundRoute);
                    _nameFacilities.Add(nameFacility);
                }
            }
            return Task.CompletedTask;
        }
    }
}
