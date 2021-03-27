using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var carDetailDto in carManager.GetCarDetails().Data)
            {
                Console.WriteLine
                    (carDetailDto.ColorName+" "+carDetailDto.BrandName+" "+carDetailDto.Description+
                    " "+carDetailDto.ModelYear+" Model"+" Günlük "+carDetailDto.DailyPrice+" TL");
            }
            if (carManager.GetCarDetails().Success==true)
            {
                Console.WriteLine();
                Console.WriteLine(carManager.GetCarDetails().Message);
            }
            
        }
    }
}
