using Core.Utilities.Results;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile formFile, CarImage carImage);
        IResult Update(CarImage carImage, IFormFile formFile);
        IResult Delete(CarImage carImage);
        IDataResult<List<CarImage>> GetImagesbyCarId(int carId);
        IDataResult<CarImage> GetImagesById(int Id);
        IDataResult<List<CarImage>> GetAll();
    }
}
