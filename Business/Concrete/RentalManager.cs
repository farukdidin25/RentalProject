using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {

            if (rental.ReturnDate==DateTime.Now)
            {
                return new SuccessResult(Messages.RentalAdded);
            }
            else
            {
                return new ErrorResult(Messages.RentalNotAdded);
            }
            
            _rentalDal.Add(rental);
        }

        public IResult Delete(Rental rental)
        {
            return new SuccessResult(Messages.RentalDeleted);
            _rentalDal.Delete(rental);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IResult Update(Rental rental)
        {
            return new SuccessResult(Messages.RentalUpdated);
            _rentalDal.Update(rental);
        }
    }
}
