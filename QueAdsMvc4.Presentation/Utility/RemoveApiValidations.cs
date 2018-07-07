using System.Linq;
using System.Web.Http.ModelBinding;

namespace QueAdsMvc4.Presentation.Utility
{
    public static class RemoveApiValidations
    {
        public static void RemoveValidation(this ModelStateDictionary modelState, params string[] removeKeys)
        {
            modelState.Where(x => removeKeys.Any(i => x.Key.StartsWith(i)))
                      .ToList().ForEach(k => modelState.Remove(k));
        }
    }
}
