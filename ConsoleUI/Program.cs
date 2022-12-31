// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;  
using Entity.Concrete;

//CarDetailDtos();

// yes 

CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
customerManager.Add(new Customer { CompanyName = "Mercedes", UserId = 2 });
customerManager.Add(new Customer { CompanyName = "BMW", UserId = 10 });
customerManager.Add(new Customer { CompanyName = "Seat", UserId = 6 });
customerManager.Add(new Customer { CompanyName = "Hyundai", UserId = 3 });
customerManager.Add(new Customer { CompanyName = "Fiat", UserId=4 });
customerManager.Add(new Customer { CompanyName = "Honda", UserId = 7 });
customerManager.Add(new Customer { CompanyName = "Toyota", UserId = 1 });




static void CarDetailDtos()
{
    CarManager carManager = new CarManager(new EfCarDal());

    var result = carManager.GetCarDetailsDto();
    if (result.Success==true)
    {
        foreach (var car in result.Data)
        {
            Console.WriteLine(car.CarName);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }
}

