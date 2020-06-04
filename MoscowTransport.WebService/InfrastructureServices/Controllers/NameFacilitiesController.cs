using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NameFacilities.DomainObjects;
using NameFacilities.ApplicationServices.GetNameFacilityListUseCase;
using NameFacilities.InfrastructureServices.Presenters;

namespace NameFacilities.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NameFacilitiesController : ControllerBase
    {
        private readonly ILogger<NameFacilitiesController> _logger;
        private readonly IGetNameFacilityListUseCase _getNameFacilityListUseCase;

        public NameFacilitiesController(ILogger<NameFacilitiesController> logger,
                                IGetNameFacilityListUseCase getNameFacilityListUseCase)
        {
            _logger = logger;
            _getNameFacilityListUseCase = getNameFacilityListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllNameFacilities()
        {
            var presenter = new NameFacilityListPresenter();
            await _getNameFacilityListUseCase.Handle(GetNameFacilityListUseCaseRequest.CreateAllNameFacilitiesRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{nameFacilityId}")]
        public async Task<ActionResult> GetNameFacility(long nameFacilityId)
        {
            var presenter = new NameFacilityListPresenter();
            await _getNameFacilityListUseCase.Handle(GetNameFacilityListUseCaseRequest.CreateNameFacilityRequest(nameFacilityId), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("NameofSportsGround/{nameofSportsGround}")]
        public async Task<ActionResult> GetNameofSportsGroundFilter(string nameofSportsGround)
        {
            var presenter = new NameFacilityListPresenter();
            await _getNameFacilityListUseCase.Handle(GetNameFacilityListUseCaseRequest.CreateNameofSportsgroundNamefacilitiesRequest(nameofSportsGround), presenter);
            return presenter.ContentResult;
        }
    }
}
