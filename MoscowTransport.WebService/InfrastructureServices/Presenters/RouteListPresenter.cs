using NameFacilities.ApplicationServices.GetNameFacilityListUseCase;
using System.Net;
using Newtonsoft.Json;
using NameFacilities.ApplicationServices.Ports;

namespace NameFacilities.InfrastructureServices.Presenters
{
    public class NameFacilityListPresenter : IOutputPort<GetNameFacilityListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public NameFacilityListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetNameFacilityListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.NameFacilities) : JsonConvert.SerializeObject(response.Message);
        }
    }
}
