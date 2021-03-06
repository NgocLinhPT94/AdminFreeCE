using System;
using System.Web.Mvc;

namespace Automanager.Core.Binders
{
    public class StringArrayBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (string.IsNullOrWhiteSpace(result.AttemptedValue)) return null;

            var words = result.AttemptedValue.Trim().Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words.Length; i++)
                words[i] = words[i].Trim();

            return words;
        }
    }
}
