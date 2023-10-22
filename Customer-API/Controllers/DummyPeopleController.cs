using Business.DTOs;
using Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Customer_API.Model;
using Customer_API.StaticDatabae;

namespace Customer_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DummyPeopleController : ControllerBase
    {
        private ICategoriesService _categoriesService;
        private IProductsService _productsService;
        public DummyPeopleController(ICategoriesService categoriesService, IProductsService productsService)
        {
            _categoriesService = categoriesService;
            _productsService = productsService;
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Pagination))]
        public ActionResult GetDummyPeople(DummyPersonFilter model)
        {
           var filtered = model.Filters(StaticDatabase.list);
           Pagination myPage = new Pagination(filtered, model);


           return Ok(myPage);
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Pagination))]
        [Route("updateperson")]
        public ActionResult UpdateDummyPerson(DummyPerson model)
        {
            DummyPerson personOfInterest = StaticDatabase.list.FirstOrDefault(p => model.Id == p.Id);
            if (personOfInterest != null)
            {
                personOfInterest.Name = model.Name;
                personOfInterest.SirName = model.SirName;
                personOfInterest.Address = model.Address;
                personOfInterest.BirthDate = model.BirthDate;
                personOfInterest.Overtime = model.Overtime;
                personOfInterest.DateOfRecruitment = model.DateOfRecruitment;
                personOfInterest.Departman = model.Departman;
                personOfInterest.PlaceOfBirth = model.PlaceOfBirth;

                return Ok(personOfInterest.toDummyPersonResponse());
            }
            return BadRequest();
            
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Pagination))]
        [Route("createperson")]
        public ActionResult CreateDummyPerson(DummyPerson model)
        {
            int? maxId = StaticDatabase.list.Max(p => p.Id);
            
            if(maxId != null)
            {
                model.Id = maxId + 1;
                StaticDatabase.list.Add(model);
                return Ok(model);
            }
            return BadRequest();
            
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Pagination))]
        [Route("deleteperson")]
        public ActionResult DeleteDummyPerson([FromQuery]int Id)
        {
            DummyPerson personOfInterest = StaticDatabase.list.FirstOrDefault(p => Id == p.Id);
            personOfInterest.IsDeleted = true;

            if(personOfInterest.IsDeleted)
                return Ok();
            return BadRequest();
        }

    }
}
