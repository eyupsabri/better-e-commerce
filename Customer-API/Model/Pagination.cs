namespace Customer_API.Model
{
    public class Pagination
    {
        public List<DummyPerson> People { get; set; }
        public int TotalPages { get; set; }
        public Pagination(int pageSize, List<DummyPerson> myList, int currentPage) {

            People = new List<DummyPerson>();
            People = (List<DummyPerson>)myList.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            int peopleCount = myList.Count;
            if(peopleCount % pageSize == 0)
                TotalPages = peopleCount / pageSize;
            else
                TotalPages = (peopleCount / pageSize) + 1;
        }
    }
}
