using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).MinimumLength(3);
            RuleFor(c=>c.CarName).NotEmpty();
            //RuleFor(c => c.CarName).Must(StartWithA); that's just exp. we can build extra message like this
        }

        /*private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }*/
    }
}
