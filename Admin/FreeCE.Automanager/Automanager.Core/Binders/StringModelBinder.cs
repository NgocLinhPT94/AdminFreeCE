using System.Web.Mvc;

namespace Automanager.Core.Binders
{
    public class StringModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (value == null)
                return base.BindModel(controllerContext, bindingContext);

            if (string.IsNullOrWhiteSpace(value.AttemptedValue))
                return base.BindModel(controllerContext, bindingContext);

            if (string.IsNullOrWhiteSpace(value.AttemptedValue))
                return string.Empty;

            bindingContext.ModelState.AddModelError(
                bindingContext.ModelName, string.Format("\"{0}\" invalid string)", value.AttemptedValue));

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}
