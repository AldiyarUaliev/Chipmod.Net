using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Chipmod.Web.Components.Forms
{
    public class SwInputBaseString : InputBase<string>, ISwInputParams
    {
        [Parameter] public string Id { get; set; }
        [Parameter] public string Label { get; set; }
        [Parameter] public bool? FormControl { get; set; }
        [Parameter] public bool? ShowValidationMessage { get; set; }
        [Parameter] public string DivClass { get; set; }
        [Parameter] public string LabelClass { get; set; }
        [Parameter] public new string CssClass { get; set; }
        [Parameter] public string ValidationClass { get; set; }
        [Parameter] public Expression<Func<string>> ValidationFor { get; set; }

        [CascadingParameter] public ISwInputParams CascadingParams { get; set; }

        protected bool SummaryFormControl => FormControl ?? CascadingParams?.FormControl ?? false;
        protected bool SummaryShowValidationMessage => ShowValidationMessage ?? CascadingParams.ShowValidationMessage ?? false;

        protected string SummaryDivClass =>
            $"{(SummaryFormControl ? "form-control-wrapper" : string.Empty)} {DivClass ?? CascadingParams?.DivClass}";

        protected string SummaryLabelClass =>
            $"{(SummaryFormControl ? "form-control-label" : string.Empty)} {LabelClass ?? CascadingParams?.LabelClass}";

        protected string SummaryCssClass =>
            $"{(SummaryFormControl ? "form-control" : string.Empty)} " +
            $"{CssClass ?? (string.IsNullOrWhiteSpace(base.CssClass) ? null : base.CssClass) ?? CascadingParams?.CssClass}";

        protected string SummaryValidationClass =>
            $"{(SummaryFormControl ? "form-control-validation" : string.Empty)} {ValidationClass ?? CascadingParams?.ValidationClass}";

        protected override bool TryParseValueFromString(string value, out string result,
            out string validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }

    }
}
