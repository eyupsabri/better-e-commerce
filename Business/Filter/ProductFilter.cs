using Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Filter
{
    public class ProductFilter : IFilterable<Product>
    {  
        
        public string? ProductName { get; set; }

        public double? ProductPrice { get; set; }

        public string? CategoryName { get; set; }
        public int? CategoryId { get; set; }
        
      


        public IQueryable<Product> Filter(IQueryable<Product> list)
        {
            if (!ProductName.IsNullOrEmpty())         
                list = list.Where(p => p.ProductName.Contains(ProductName));            
            if(ProductPrice.HasValue)            
                list = list.Where(p => p.ProductPrice == ProductPrice);
            if(CategoryId.HasValue)
                list = list.Where(p => p.CategoryId == CategoryId.Value);
            if(!CategoryName.IsNullOrEmpty())
                list = list.Where(p => p.Category.CategoryName.Contains(CategoryName));
            return list;
                

        }

        //public IQueryable<LaborCost> Sort(IQueryable<LaborCost> list)
        //{
        //    switch (sortBy)
        //    {
        //        default:
        //            return list.OrderBy(p => p.RecruitmentProcess.AgcStaff.People.FirstName).ThenBy(p => p.RecruitmentProcess.AgcStaff.People.LastName).ThenByDescending(p => p.AgcServiceRecieptPeriod.BeginDate);
        //        case "staff":
        //            return sortAsc ? list.OrderBy(p => p.RecruitmentProcess.AgcStaff.People.FirstName).ThenBy(p => p.RecruitmentProcess.AgcStaff.People.LastName).ThenByDescending(p => p.AgcServiceRecieptPeriod.BeginDate) : list.OrderByDescending(p => p.RecruitmentProcess.AgcStaff.People.FirstName).ThenByDescending(p => p.RecruitmentProcess.AgcStaff.People.LastName).ThenByDescending(p => p.AgcServiceRecieptPeriod.BeginDate);
        //        case "beginDate":
        //            return sortAsc ? list.OrderBy(p => p.AgcServiceRecieptPeriod.BeginDate) : list.OrderByDescending(p => p.AgcServiceRecieptPeriod.BeginDate);
        //        case "endDate":
        //            return sortAsc ? list.OrderBy(p => p.AgcServiceRecieptPeriod.EndDate) : list.OrderByDescending(p => p.AgcServiceRecieptPeriod.EndDate);
        //        case "workDay":
        //            return sortAsc ? list.OrderBy(p => p.CalismaGunu) : list.OrderByDescending(p => p.CalismaGunu);
        //        case "overtime":
        //            return sortAsc ? list.OrderBy(p => p.FazlaMesai) : list.OrderByDescending(p => p.FazlaMesai);
        //        case "state":
        //            return sortAsc ? list.OrderBy(p => p.State) : list.OrderByDescending(p => p.State);
        //        case "registerNo":
        //            return sortAsc ? list.OrderBy(p => p.RecruitmentProcess.RegisterNo) : list.OrderByDescending(p => p.RecruitmentProcess.RegisterNo);
        //        case "period":
        //            return sortAsc ? list.OrderBy(p => p.AgcServiceRecieptPeriod.BeginDate).ThenBy(p => p.RecruitmentProcess.AgcStaff.People.FirstName).ThenBy(p => p.RecruitmentProcess.AgcStaff.People.LastName) : list.OrderByDescending(p => p.AgcServiceRecieptPeriod.BeginDate).ThenBy(p => p.RecruitmentProcess.AgcStaff.People.FirstName).ThenByDescending(p => p.RecruitmentProcess.AgcStaff.People.LastName);

        //    }
        //}
    }
}
