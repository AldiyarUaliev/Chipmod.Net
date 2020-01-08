using System;
using System.Linq.Expressions;

namespace Chronos.Web.Components.Forms
{
    public interface IXInputParams
    {
        string Id { get; set; }
        string Label { get; set; }
        bool? FormControl { get; set; }
        bool? ShowValidationMessage { get; set; }
        string DivClass { get; set; }
        string LabelClass { get; set; }
        string CssClass { get; set; }
        string ValidationClass { get; set; }
        Expression<Func<string>> ValidationFor { get; set; }
    }
}
