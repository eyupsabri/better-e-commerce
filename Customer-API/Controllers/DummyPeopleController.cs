using Business.DTOs;
using Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Customer_API.Model;

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
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<DummyPerson>))]
        public ActionResult GetDummyPeople()
        {
            DummyPerson dum1 = new DummyPerson() {Id=1, Address = "aaaaa aaaaaa aaaa", BirthDate = new DateTime(2011, 1, 21), DateOfRecruitment= new DateTime(2012,1,1), Departman="Saglik", Name="Osman", Overtime=2, PlaceOfBirth="Izmır", SirName="Igne"};
            DummyPerson dum2 = new DummyPerson() {Id=2, Address = "baaaa aaaaaa aaaa", BirthDate = new DateTime(2010, 1, 21), DateOfRecruitment = new DateTime(2013, 1, 1), Departman = "Temizlik", Name = "Nilgun", Overtime = 2, PlaceOfBirth = "Manisa", SirName = "Brightside" };
            DummyPerson dum3 = new DummyPerson() {Id=3, Address = "caaaa aaaaaa aaaa", BirthDate = new DateTime(2009, 1, 21), DateOfRecruitment = new DateTime(2014, 1, 1), Departman = "Yazilim", Name = "Simge", Overtime = 2, PlaceOfBirth = "Yemen", SirName = "Alper" };
            DummyPerson dum4 = new DummyPerson() { Id = 4, Address = "daaaa aaaaaa aaaa", BirthDate = new DateTime(2008, 1, 21), DateOfRecruitment = new DateTime(2015, 1, 1), Departman = "Insan Kaynaklari", Name = "Cansu", Overtime = 2, PlaceOfBirth = "Canakkale", SirName = "Freud" };
            DummyPerson dum5 = new DummyPerson() {Id = 5, Address = "faaaa aaaaaa aaaa", BirthDate = new DateTime(2007, 1, 21), DateOfRecruitment = new DateTime(2016, 1, 1), Departman = "Yemek", Name = "Merve", Overtime = 2, PlaceOfBirth = "Ankara", SirName = "Tiramisu" };
            DummyPerson dum6 = new DummyPerson() { Id = 6, Address = "gaaaa aaaaaa aaaa", BirthDate = new DateTime(2006, 1, 21), DateOfRecruitment = new DateTime(2017, 1, 1), Departman = "Zuccaciye", Name = "Mehmet", Overtime = 2, PlaceOfBirth = "Istanbul", SirName = "Caydanlik" };
            DummyPerson dum7 = new DummyPerson() {Id = 7, Address = "haaaa aaaaaa aaaa", BirthDate = new DateTime(2005, 1, 21), DateOfRecruitment = new DateTime(2018, 1, 1), Departman = "Atom muhendisi", Name = "Ahmet", Overtime = 2, PlaceOfBirth = "Antalya", SirName = "Proton" };
            DummyPerson dum8 = new DummyPerson() { Id = 8, Address = "kaaaa aaaaaa aaaa", BirthDate = new DateTime(2004, 1, 21), DateOfRecruitment = new DateTime(2019, 1, 1), Departman = "Insan kacakcisi", Name = "Abdullah", Overtime = 2, PlaceOfBirth = "Bursa", SirName = "Shady" };
            DummyPerson dum9 = new DummyPerson() {Id = 9, Address = "laaaa aaaaaa aaaa", BirthDate = new DateTime(2003, 1, 21), DateOfRecruitment = new DateTime(2020, 1, 1), Departman = "Mafya", Name = "Suleyman", Overtime = 2, PlaceOfBirth = "Van", SirName = "Boyaci" };
            DummyPerson dum10 = new DummyPerson() {Id = 10, Address = "maaaa aaaaaa aaaa", BirthDate = new DateTime(2002, 1, 21), DateOfRecruitment = new DateTime(2021, 1, 1), Departman = "Komedyen", Name = "Pinar Su", Overtime = 2, PlaceOfBirth = "Erzincan", SirName = "Goldberg" };
            DummyPerson dum11 = new DummyPerson() {Id = 11, Address = "naaaa aaaaaa aaaa", BirthDate = new DateTime(2001, 1, 21), DateOfRecruitment = new DateTime(2022, 1, 1), Departman = "Manifaturaci", Name = "Fatih Deniz", Overtime = 2, PlaceOfBirth = "Trabzon", SirName = "Teke" };
            DummyPerson dum12 = new DummyPerson() {Id = 12, Address = "oaaaa aaaaaa aaaa", BirthDate = new DateTime(2000, 1, 21), DateOfRecruitment = new DateTime(2023, 1, 1), Departman = "Yazar", Name = "Burhan", Overtime = 2, PlaceOfBirth = "Tokat", SirName = "Altintop" };
            DummyPerson dum13 = new DummyPerson() {Id = 13, Address = "paaaa aaaaaa aaaa", BirthDate = new DateTime(1999, 1, 21), DateOfRecruitment = new DateTime(2005, 1, 1), Departman = "Ghost Writer", Name = "Asli", Overtime = 2, PlaceOfBirth = "Nisantasi", SirName = "Sutcuoglu" };
            DummyPerson dum14 = new DummyPerson() {Id = 14, Address = "raaaa aaaaaa aaaa", BirthDate = new DateTime(1998, 1, 21), DateOfRecruitment = new DateTime(2006, 1, 1), Departman = "Sufleci", Name = "Cem", Overtime = 2, PlaceOfBirth = "Tokyo", SirName = "Onaran" };

            DummyPerson dum15 = new DummyPerson() { Id = 15, Address = "aaaaa aaaaaa aaaa", BirthDate = new DateTime(2011, 1, 21), DateOfRecruitment = new DateTime(2012, 1, 1), Departman = "Saglik", Name = "Osman", Overtime = 2, PlaceOfBirth = "Izmır", SirName = "Igne" };
            DummyPerson dum16 = new DummyPerson() { Id = 16, Address = "baaaa aaaaaa aaaa", BirthDate = new DateTime(2010, 1, 21), DateOfRecruitment = new DateTime(2013, 1, 1), Departman = "Temizlik", Name = "Nilgun", Overtime = 2, PlaceOfBirth = "Manisa", SirName = "Brightside" };
            DummyPerson dum17 = new DummyPerson() { Id = 17, Address = "caaaa aaaaaa aaaa", BirthDate = new DateTime(2009, 1, 21), DateOfRecruitment = new DateTime(2014, 1, 1), Departman = "Yazilim", Name = "Simge", Overtime = 2, PlaceOfBirth = "Yemen", SirName = "Alper" };
            DummyPerson dum18 = new DummyPerson() { Id = 18, Address = "daaaa aaaaaa aaaa", BirthDate = new DateTime(2008, 1, 21), DateOfRecruitment = new DateTime(2015, 1, 1), Departman = "Insan Kaynaklari", Name = "Cansu", Overtime = 2, PlaceOfBirth = "Canakkale", SirName = "Freud" };
            DummyPerson dum19 = new DummyPerson() { Id = 19, Address = "faaaa aaaaaa aaaa", BirthDate = new DateTime(2007, 1, 21), DateOfRecruitment = new DateTime(2016, 1, 1), Departman = "Yemek", Name = "Merve", Overtime = 2, PlaceOfBirth = "Ankara", SirName = "Tiramisu" };
            DummyPerson dum20 = new DummyPerson() { Id = 20, Address = "gaaaa aaaaaa aaaa", BirthDate = new DateTime(2006, 1, 21), DateOfRecruitment = new DateTime(2017, 1, 1), Departman = "Zuccaciye", Name = "Mehmet", Overtime = 2, PlaceOfBirth = "Istanbul", SirName = "Caydanlik" };
            DummyPerson dum21 = new DummyPerson() { Id = 21, Address = "haaaa aaaaaa aaaa", BirthDate = new DateTime(2005, 1, 21), DateOfRecruitment = new DateTime(2018, 1, 1), Departman = "Atom muhendisi", Name = "Ahmet", Overtime = 2, PlaceOfBirth = "Antalya", SirName = "Proton" };
            DummyPerson dum22 = new DummyPerson() { Id = 22, Address = "kaaaa aaaaaa aaaa", BirthDate = new DateTime(2004, 1, 21), DateOfRecruitment = new DateTime(2019, 1, 1), Departman = "Insan kacakcisi", Name = "Abdullah", Overtime = 2, PlaceOfBirth = "Bursa", SirName = "Shady" };
            DummyPerson dum23 = new DummyPerson() { Id = 23, Address = "laaaa aaaaaa aaaa", BirthDate = new DateTime(2003, 1, 21), DateOfRecruitment = new DateTime(2020, 1, 1), Departman = "Mafya", Name = "Suleyman", Overtime = 2, PlaceOfBirth = "Van", SirName = "Boyaci" };
            DummyPerson dum24 = new DummyPerson() { Id = 24, Address = "maaaa aaaaaa aaaa", BirthDate = new DateTime(2002, 1, 21), DateOfRecruitment = new DateTime(2021, 1, 1), Departman = "Komedyen", Name = "Pinar Su", Overtime = 2, PlaceOfBirth = "Erzincan", SirName = "Goldberg" };
            DummyPerson dum25 = new DummyPerson() { Id = 25, Address = "naaaa aaaaaa aaaa", BirthDate = new DateTime(2001, 1, 21), DateOfRecruitment = new DateTime(2022, 1, 1), Departman = "Manifaturaci", Name = "Fatih Deniz", Overtime = 2, PlaceOfBirth = "Trabzon", SirName = "Teke" };
            DummyPerson dum26 = new DummyPerson() { Id = 26, Address = "oaaaa aaaaaa aaaa", BirthDate = new DateTime(2000, 1, 21), DateOfRecruitment = new DateTime(2023, 1, 1), Departman = "Yazar", Name = "Burhan", Overtime = 2, PlaceOfBirth = "Tokat", SirName = "Altintop" };
            DummyPerson dum27 = new DummyPerson() { Id = 27, Address = "paaaa aaaaaa aaaa", BirthDate = new DateTime(1999, 1, 21), DateOfRecruitment = new DateTime(2005, 1, 1), Departman = "Ghost Writer", Name = "Asli", Overtime = 2, PlaceOfBirth = "Nisantasi", SirName = "Sutcuoglu" };
            DummyPerson dum28 = new DummyPerson() { Id = 28, Address = "raaaa aaaaaa aaaa", BirthDate = new DateTime(1998, 1, 21), DateOfRecruitment = new DateTime(2006, 1, 1), Departman = "Sufleci", Name = "Cem", Overtime = 2, PlaceOfBirth = "Tokyo", SirName = "Onaran" };

            List<DummyPerson> list = new List<DummyPerson>() { dum1,dum2,dum3,dum4,dum5,dum6,dum7,dum8,dum9,dum10,dum11,dum12,dum13,dum14, dum15, dum16, dum17, dum18, dum19, dum20, dum21, dum22, dum23, dum24, dum25, dum26, dum27, dum28};

            return Ok(list);
        }

    }
}
