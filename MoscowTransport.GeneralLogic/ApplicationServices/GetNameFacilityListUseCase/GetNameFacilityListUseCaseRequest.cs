using NameFacilities.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameFacilities.ApplicationServices.GetNameFacilityListUseCase
{
    public class GetNameFacilityListUseCaseRequest : IUseCaseRequest<GetNameFacilityListUseCaseResponse>
    {
        public string NameofSportsGround { get; private set; }
        public long? NameFacilityId { get; private set; }

        private GetNameFacilityListUseCaseRequest()
        { }

        public static GetNameFacilityListUseCaseRequest CreateAllNameFacilitiesRequest()
        {
            return new GetNameFacilityListUseCaseRequest();
        }

        public static GetNameFacilityListUseCaseRequest CreateNameFacilityRequest(long nameFacilityId)
        {
            return new GetNameFacilityListUseCaseRequest() { NameFacilityId = nameFacilityId };
        }
        public static GetNameFacilityListUseCaseRequest CreateNameofSportsgroundNamefacilitiesRequest(string nameofSportsGround)
        {
            return new GetNameFacilityListUseCaseRequest() { NameofSportsGround = nameofSportsGround };
        }
    }
}
