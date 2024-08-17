using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public abstract class TControllerBase : ControllerBase
    {
        public static List<string> CompileModelStateError(ModelStateDictionary modelState)
        {
            var errorMessage = new List<string>();
            if (!modelState.IsValid)
            {
                var errors = modelState.Values.SelectMany(v => v.Errors);
                foreach (var item in errors)
                {
                    errorMessage.Add(item.ErrorMessage);
                }
            }
            return errorMessage;
        }

        public static string CompileModelStateErrorAsString(ModelStateDictionary modelState, string delimiter = "|")
        {
            var errorMessage = new List<string>();
            if (!modelState.IsValid)
            {
                var errors = modelState.Values.SelectMany(v => v.Errors);
                foreach (var item in errors)
                {
                    errorMessage.Add(item.ErrorMessage);
                }
            }
            return string.Join(delimiter, errorMessage);
        }
    }
}