using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);    // void --> IResult
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();       //list<> and car --> IDataResult
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsDto();
        IResult TransactionTest(Car car);
    }
}
