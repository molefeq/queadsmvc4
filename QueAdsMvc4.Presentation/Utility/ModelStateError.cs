using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace QueAdsMvc4.Presentation.Utility
{
    public class ModelStateError
    {
        public string FieldName { get; set; }
        public string Message { get; set; }

        public static List<ModelStateError> ToModelStateErrorResult(ModelStateDictionary modelStateDictionary)
        {
            List<ModelStateError> errors = new List<ModelStateError>();
            foreach (var modelState in modelStateDictionary)
            {
                if (modelState.Value.Errors.Count() > 0)
                {
                    errors.Add(new ModelStateError { Message = modelState.Value.Errors[0].ErrorMessage, FieldName = modelState.Key });
                }
            }

            return errors;
        }
    }
}
