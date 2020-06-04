using NameFacilities.DomainObjects;
using NameFacilities.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameFacilities.ApplicationServices.GetNameFacilityListUseCase
{
    public class GetNameFacilityListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<NameFacility> NameFacilities { get; }

        public GetNameFacilityListUseCaseResponse(IEnumerable<NameFacility> nameFacilities) => NameFacilities = nameFacilities;
    }
}
