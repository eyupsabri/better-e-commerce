using System.Linq.Expressions;

namespace Customer_API.Model
{
    public class Pagination
    {
        public List<DummyPerson> People { get; set; }
        public int TotalPages { get; set; }
        public Pagination(List<DummyPerson> myList, OnlyCurrentPage page) {

            People = new List<DummyPerson>();

            if (page.SortAsc)
            {
                switch (page.SortBy)
                {
                    case "Name":
                        People = myList.OrderBy(p => p.Name).Skip((page.CurrentPage - 1) * page.PageSize).Take(page.PageSize).ToList();
                        break;
                    case "SirName":
                        People = myList.OrderBy(p => p.SirName).Skip((page.CurrentPage - 1) * page.PageSize).Take(page.PageSize).ToList();
                        break;
                    case "Address":
                        People = myList.OrderBy(p => p.Address).Skip((page.CurrentPage - 1) * page.PageSize).Take(page.PageSize).ToList();
                        break;
                    default:
                        People = myList.OrderBy(p => p.Id).Skip((page.CurrentPage - 1) * page.PageSize).Take(page.PageSize).ToList();
                        break;
                }
            }else
            {
                switch (page.SortBy)
                {
                    case "Name":
                        People = myList.OrderByDescending(p => p.Name).Skip((page.CurrentPage - 1) * page.PageSize).Take(page.PageSize).ToList();
                        break;
                    case "SirName":
                        People = myList.OrderByDescending(p => p.SirName).Skip((page.CurrentPage - 1) * page.PageSize).Take(page.PageSize).ToList();
                        break;
                    case "Address":
                        People = myList.OrderByDescending(p => p.Address).Skip((page.CurrentPage - 1) * page.PageSize).Take(page.PageSize).ToList();
                        break;
                    default:
                        People = myList.OrderByDescending(p => p.Id).Skip((page.CurrentPage - 1) * page.PageSize).Take(page.PageSize).ToList();
                        break;
                }
            }
                 

            int peopleCount = myList.Count;
            if(peopleCount % page.PageSize == 0)
                TotalPages = peopleCount / page.PageSize;
            else
                TotalPages = (peopleCount / page.PageSize) + 1;
        }
    }
}
