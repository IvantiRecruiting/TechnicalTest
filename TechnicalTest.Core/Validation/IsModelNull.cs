using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest.Core.Constants;
using TechnicalTest.Core.Interfaces;

namespace TechnicalTest.Core.Validation
{
    public class IsModelNull : IModelValidator
    {
        public void Validate(IModel model)
        {
            if (model == null)
            {
                throw new Exception(ErrorMessages.NoResult);
            }
        }
    }
}
