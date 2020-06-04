using NameFacilities.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using NameFacilities.ApplicationServices.Ports.Gateways.Database;

namespace NameFacilities.InfrastructureServices.Gateways.Database
{
    public class NameFacilityEFSqliteGateway : INameFacilityDatabaseGateway
    {
        private readonly NameFacilityContext _nameFacilityContext;

        public NameFacilityEFSqliteGateway(NameFacilityContext transportContext)
            => _nameFacilityContext = transportContext;

        public async Task<NameFacility> GetNameFacility(long id)
           => await _nameFacilityContext.NameFacilities.Where(r => r.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<NameFacility>> GetAllNameFacilities()
            => await _nameFacilityContext.NameFacilities.ToListAsync();
          
        public async Task<IEnumerable<NameFacility>> QueryNameFacilities(Expression<Func<NameFacility, bool>> filter)
            => await _nameFacilityContext.NameFacilities.Where(filter).ToListAsync();

        public async Task AddNameFacility(NameFacility nameFacility)
        {
            _nameFacilityContext.NameFacilities.Add(nameFacility);
            await _nameFacilityContext.SaveChangesAsync();
        }

        public async Task UpdateNameFacility(NameFacility nameFacility)
        {
            _nameFacilityContext.Entry(nameFacility).State = EntityState.Modified;
            await _nameFacilityContext.SaveChangesAsync();
        }

        public async Task RemoveNameFacility(NameFacility nameFacility)
        {
            _nameFacilityContext.NameFacilities.Remove(nameFacility);
            await _nameFacilityContext.SaveChangesAsync();
        }

    }
}
