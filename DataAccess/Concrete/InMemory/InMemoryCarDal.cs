using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car(){ BrandId=1, Id=1, ColorId=001, DailyPrice=270, Description="Sarı rengin gün ışığı tonlaması", ModelYear=2007},
                new Car(){ BrandId=2, Id=2, ColorId=002, DailyPrice=280, Description="Sadece gün batımında görebileceğiniz tatlı turuncu", ModelYear=2017},
                new Car(){ BrandId=3, Id=3, ColorId=003, DailyPrice=275, Description="Akdenizin mükemmel sularında görebileceğiniz deniz mavisi", ModelYear=2016},
                new Car(){ BrandId=4, Id=4, ColorId=004, DailyPrice=265, Description="Uçsuz bucaksız Karadeniz yaylalarına tonunda yeşil", ModelYear=2009},
                new Car(){ BrandId=5, Id=5, ColorId=005, DailyPrice=260, Description="Ne siyah kadar koyu ne beyaz kadar açık, mükemmel bir gri tonlama", ModelYear=2008},
                new Car(){ BrandId=6, Id=6, ColorId=006, DailyPrice=270, Description="Karanlıkta yok olacak mat siyah tonlama", ModelYear=2007},
                new Car(){ BrandId=7, Id=7, ColorId=007, DailyPrice=250, Description="Tüm renkleri benzersiz yansıtan tertemiz beyaz tonlama", ModelYear=2007}
            };
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.Id==car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
