using System.Threading.Tasks;
using System.Collections.Generic;
using NameFacilities.DomainObjects;
using NameFacilities.DomainObjects.Ports;
using NameFacilities.ApplicationServices.Ports;

namespace NameFacilities.ApplicationServices.GetNameFacilityListUseCase
{
    public class GetNameFacilityListUseCase : IGetNameFacilityListUseCase
    {
        private readonly IReadOnlyNameFacilityRepository _readOnlyNameFacilityRepository;

        public GetNameFacilityListUseCase(IReadOnlyNameFacilityRepository readOnlyNameFacilityRepository) 
            => _readOnlyNameFacilityRepository = readOnlyNameFacilityRepository;

        public async Task<bool> Handle(GetNameFacilityListUseCaseRequest request, IOutputPort<GetNameFacilityListUseCaseResponse> outputPort)
        {
            IEnumerable<NameFacility> nameFacilities = null;
            if (request.NameFacilityId != null)
            {
                var nameFacility = await _readOnlyNameFacilityRepository.GetNameFacility(request.NameFacilityId.Value);
                nameFacilities = (nameFacility != null) ? new List<NameFacility>() { nameFacility } : new List<NameFacility>();
                
            }
            else if (request.NameofSportsGround != null)
            {
                nameFacilities = await _readOnlyNameFacilityRepository.QueryNameFacilities(new TypeofSportsGroundCriteria(request.NameofSportsGround));
            }
            else
            {
                nameFacilities = await _readOnlyNameFacilityRepository.GetAllNameFacilities();
            }
            outputPort.Handle(new GetNameFacilityListUseCaseResponse(nameFacilities));
            return true;
        }
    }
}
