using Customer_API.LoginHelper;
using Microsoft.IdentityModel.Tokens;

namespace Customer_API.Model
{
    public class DummyPersonFilter : OnlyCurrentPage
    {
        public string? Name { get; set; }
        public string? Sirname { get; set; }

        public List<DummyPersonResponse> Filters(List<DummyPerson> myList)
        {
            if (!Name.IsNullOrEmpty())
                myList = myList.Where(d => d.Name.Contains(Name) && !d.IsDeleted).ToList();
            if (!Sirname.IsNullOrEmpty())
                myList = myList.Where(d => d.SirName.Contains(Sirname) && !d.IsDeleted).ToList();
            return myList.toDummyPeople();

        }

    }
}
