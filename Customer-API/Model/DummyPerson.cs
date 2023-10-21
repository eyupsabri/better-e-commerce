﻿namespace Customer_API.Model
{
    public class DummyPerson
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string SirName { get; set; }
        public string Address { get; set; }
        public string Departman { get; set; }
        public int Overtime { get; set; }
        public DateTime BirthDate { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime DateOfRecruitment { get; set; }
        public bool IsDeleted { get; set; }

        public DummyPersonResponse toDummyPersonResponse()
        {
            return new DummyPersonResponse() { Id = Id, Name=Name, SirName= SirName, Address=Address, Departman= Departman, Overtime = Overtime,
                BirthDate = BirthDate, PlaceOfBirth= PlaceOfBirth, DateOfRecruitment= DateOfRecruitment};
        }

    }
}
