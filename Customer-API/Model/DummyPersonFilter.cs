using Microsoft.IdentityModel.Tokens;

namespace Customer_API.Model
{
    public class DummyPersonFilter : OnlyCurrentPage
    {
        public string? Name { get; set; }
        public string? Sirname { get; set; }

        public List<DummyPerson> Filters(List<DummyPerson> myList)
        {
            if (!Name.IsNullOrEmpty())
                myList = myList.Where(d => d.Name.Contains(Name)).ToList();
            if (!Sirname.IsNullOrEmpty())
                myList = myList.Where(d => d.SirName.Contains(Sirname)).ToList();
            return myList;

        }

    }
}
