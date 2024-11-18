using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.UI.TagHelpers
{
    [HtmlTargetElement("bootstrap-alert")]
    public class AlertTagHelper :TagHelper
    {
        public string Type { get; set; } = "info";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", $"alert-{Type}");
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
