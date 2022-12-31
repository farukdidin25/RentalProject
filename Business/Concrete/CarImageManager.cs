using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResult = Core.Utilities.Results.IResult;  

namespace Business.Concrete   
{ 
    public class CarImageManager : ICarImageService  
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }
        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImagesLimited(carImage.CarId));
            if (!result.Success)
            {
                return result;
            }
            var imageResult = _fileHelper.Upload(formFile);
            carImage.ImagePath = imageResult.Message;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }
        public IResult Delete(CarImage carImage)
        {
            var deleteCarImage = _carImageDal.Get(c => c.CarId == carImage.CarId);
            _fileHelper.Delete(deleteCarImage.ImagePath);
            _carImageDal.Delete(deleteCarImage);
            return new SuccessResult();
        }
        public IDataResult<List<CarImage>> GetAll()
        {
            List<CarImage> carImagesList = _carImageDal.GetAll();
            if (!carImagesList.Any())
            {
                carImagesList = new List<CarImage>();
                carImagesList.Add(new CarImage { ImagePath = _fileHelper.DefaultImage() });
                return new SuccessDataResult<List<CarImage>>(carImagesList);
            }
            return new SuccessDataResult<List<CarImage>>(carImagesList);
        }
        public IDataResult<List<CarImage>> GetImagesbyCarId(int carId)
        {
            List<CarImage> carImageGetById = _carImageDal.GetAll(c => c.CarId == carId);
            if (!carImageGetById.Any())
            {
                carImageGetById = new List<CarImage>();
                carImageGetById.Add(new CarImage { ImagePath = _fileHelper.DefaultImage() });
                return new SuccessDataResult<List<CarImage>>(carImageGetById);
            }
            return new SuccessDataResult<List<CarImage>>(carImageGetById);
        }
        public IResult Update(CarImage carImage, IFormFile formFile)
        {
            var imageByCarId = _carImageDal.Get(c => c.CarId == carImage.CarId);
            imageByCarId.ImagePath = _fileHelper.Update(formFile, imageByCarId.ImagePath).Message;
            imageByCarId.Date = DateTime.Now;
            _carImageDal.Update(imageByCarId);
            return new SuccessResult();
        }
        public IResult CheckIfCarImagesLimited(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count >= 5)
            {
                return new ErrorResult("Resim ekleme limiti aşıldı.");
            }
            return new SuccessResult();
        }
        public IDataResult<CarImage> GetImagesById(int Id)
        {
            var result = _carImageDal.Get(c => c.Id == Id);
            if (result == null)
            {
                return new ErrorDataResult<CarImage>(new CarImage() { Id = Id, ImagePath = _fileHelper.DefaultImage() });
            }
            return new SuccessDataResult<CarImage>(result);
        }
    }
}
