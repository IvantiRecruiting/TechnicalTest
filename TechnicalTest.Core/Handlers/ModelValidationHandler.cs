using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest.Core.Interfaces;
using TechnicalTest.Core.Models;
using TechnicalTest.Core.Validation;

namespace TechnicalTest.Core.Handlers
{
    public class ModelValidationHandler : IValidationHandler
    {
        private IModel _model;

        public ModelValidationHandler(IModel model) {
            _model = model;
        }

        public List<IModelValidator> validators = new () {
            new IsModelNull()
        };


        public void Validate()
        {
            foreach (var validator in validators)
            {
                validator.Validate(_model);
            }
        }
    }
}
