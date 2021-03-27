using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentalContext context = new RentalContext())
            {
                var result = from c in context.cars
                             join b in context.brands
                             on c.BrandId equals b.BrandId
                             join co in context.colors
                             on c.ColorId equals co.ColorId

                             select new CarDetailDto 
                             { 
                                 BrandName=b.BrandName,ColorName=co.ColorName,DailyPrice=c.DailyPrice,
                                 Description=c.Description,ModelYear=c.ModelYear
                             };

                return result.ToList();
            }
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            using (RentalContext context = new RentalContext())
            {
                return context.Set<Car>().Where(c => c.BrandId == brandId).ToList();
            }
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            using (RentalContext context = new RentalContext())
            {
                return context.Set<Car>().Where(c => c.ColorId == colorId).ToList();
            }
        }
    }
}
