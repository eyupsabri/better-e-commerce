using Business.Sorting;
using Business.United;
using Entities;
using Entities.Enums.ModelEnums;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.Enums.ModelEnums.PriceEnums;

namespace Business.Filter
{
    public class ProductFilter : BaseFilter, IFilterAndSort<Product>
    {

        public string? ProductName { get; set; }

        public double? ProductPrice { get; set; }

        public string? CategoryName { get; set; }
        public int? CategoryId { get; set; }
        public double? UpperPriceLimit { get; set; }
        public double? LowerPriceLimit { get; set; }
        // public bool? Price1 { get; set; } //0-100
        // public bool? Price2 { get; set; } //100-200
        //public bool? Price3 { get; set; } //200-300
        // public bool? Price4 { get; set; } //300-400
        //public bool? Price5 { get; set; } //400-500

        public PriceOptions? Price1 { get; set; }
        public PriceOptions? Price2 { get; set; }
        public PriceOptions? Price3 { get; set; }
        public PriceOptions? Price4 { get; set; }
        public PriceOptions? Price5 { get; set; }




        public IQueryable<Product> Filter(IQueryable<Product> list)
        {
            if (!ProductName.IsNullOrEmpty())
                list = list.Where(p => p.ProductName.Contains(ProductName));
            if (ProductPrice.HasValue)
                list = list.Where(p => p.ProductPrice == ProductPrice);
            if (CategoryId.HasValue)
                list = list.Where(p => p.CategoryId == CategoryId.Value);
            if (!CategoryName.IsNullOrEmpty())
                list = list.Where(p => p.Category.CategoryName.Contains(CategoryName));
            if (UpperPriceLimit.HasValue)
                list = list.Where(p => UpperPriceLimit > p.ProductPrice);
            if (LowerPriceLimit.HasValue)
                list = list.Where(p => p.ProductPrice >= LowerPriceLimit);

            list = ProductPriceFilter(list);

            return list;


        }

        public IQueryable<Product> Sort(IQueryable<Product> list)
        {
            switch (sortBy)
            {
                default:
                    return list;
                case "productName" :
                    return sortAsc ? list.OrderBy(p => p.ProductName) : list.OrderByDescending(p => p.ProductName);
                case "productPrice":
                    return sortAsc ? list.OrderBy(p => p.ProductPrice) : list.OrderByDescending(p => p.ProductPrice);

            }
        }

        private IQueryable<Product> ProductPriceFilter(IQueryable<Product> list)
        {
            IQueryable<Product> final = Enumerable.Empty<Product>().AsQueryable();
            bool any = false;

            if (Price1 != null)
            {
                final = list.Where(p => p.ProductPrice <= 100);
                any = true;
            }
            if (Price2 != null)
            {
                if (!any)
                    final = list.Where(p => p.ProductPrice <= 200 && p.ProductPrice > 100);
                else
                    final = final.Concat(list.Where(p => p.ProductPrice <= 200 && p.ProductPrice > 100));
                any = true;
            }

            if (Price3 != null)
            {
                if (!any)
                    final = list.Where(p => p.ProductPrice <= 300 && p.ProductPrice > 200);
                else
                    final = final.Concat(list.Where(p => p.ProductPrice <= 300 && p.ProductPrice > 200));
                any = true;
            }

            if (Price4 != null)
            {
                if (!any)
                    final = list.Where(p => p.ProductPrice <= 400 && p.ProductPrice > 300);
                else
                    final = final.Concat(list.Where(p => p.ProductPrice <= 400 && p.ProductPrice > 300));
                any = true;
            }

            if (Price5 != null)
            {
                if (!any)
                    final = list.Where(p => p.ProductPrice <= 500 && p.ProductPrice > 400);
                else
                    final = final.Concat(list.Where(p => p.ProductPrice <= 500 && p.ProductPrice > 400));
                any = true;
            }

            if (any)
                return final;
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
