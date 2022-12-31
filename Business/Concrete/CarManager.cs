using Business.Abstract;
using Business.BusinesAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car add,admin")] 
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {

            ValidationTool.Validate(new CarValidator(), car);
            

            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded); 
        }

        [TransactionScopeAspect]
        

        public IResult Delete(Car car)
        {
            return new SuccessResult(Messages.CarDeleted);
            _carDal.Delete(car);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 9)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            };
       
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
            
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsDto()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtos());
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.ColorId == id));
        }

        public IResult TransactionTest(Car car)
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            return new SuccessResult(Messages.CarUpdated);
            _carDal.Update(car);
        }
        




    }
}

