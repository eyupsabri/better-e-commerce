using Customer_API.Model;

namespace Customer_API.LoginHelper
{
    public static class ListExtention
    {
        public static List<DummyPersonResponse> toDummyPeople(this List<DummyPerson> myList)
        {
            List<DummyPersonResponse> dummyPeople = new List<DummyPersonResponse>();

            foreach(var person in  myList)
            {
                if(!person.IsDeleted) 
                    dummyPeople.Add(person.toDummyPersonResponse());
            }
            return dummyPeople;
        }
    }
}
