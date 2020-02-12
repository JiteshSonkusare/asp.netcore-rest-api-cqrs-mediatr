using System.Collections.Generic;
using System.Text.RegularExpressions;
using FluentValidation.Validators;

namespace Texts.API.Application.Infrastructure.Validation
{
    public class TextValidator : PropertyValidator
    {
        public TextValidator()
            : base("{PropertyName} only allow A-Z, a-z, 0-9, dot(.) and underscore(_)!")
        { }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var keyStr = context.PropertyValue as string;

            Regex r = new Regex("^[a-zA-Z0-9_.]*$");

            if (string.IsNullOrEmpty(keyStr) || !r.IsMatch(keyStr))
            {
                context.MessageFormatter.AppendArgument("Key", keyStr);
                return false;
            }

            return true;
        }
    }
}
