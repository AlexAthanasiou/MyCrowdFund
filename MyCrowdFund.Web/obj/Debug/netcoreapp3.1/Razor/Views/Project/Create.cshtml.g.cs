#pragma checksum "C:\Users\alex_\Desktop\MyCrowdFund\MyCrowdFund\MyCrowdFund.Web\Views\Project\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a29db46a9f8204f8092a0b3c5e20d57adddd725c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Project_Create), @"mvc.1.0.view", @"/Views/Project/Create.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\alex_\Desktop\MyCrowdFund\MyCrowdFund\MyCrowdFund.Web\Views\_ViewImports.cshtml"
using MyCrowdFund.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\alex_\Desktop\MyCrowdFund\MyCrowdFund\MyCrowdFund.Web\Views\_ViewImports.cshtml"
using MyCrowdFund.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a29db46a9f8204f8092a0b3c5e20d57adddd725c", @"/Views/Project/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b515ee086b6052e67d5c2a8834c302af3a71d33", @"/Views/_ViewImports.cshtml")]
    public class Views_Project_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MyCrowdFund.Web.Models.ProjectViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("js-project  col-md-4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a29db46a9f8204f8092a0b3c5e20d57adddd725c3959", async() => {
                WriteLiteral("\r\n\r\n        <div class=\"form-group\">\r\n            <label");
                BeginWriteAttribute("for", " for=\"", 202, "\"", 241, 1);
#nullable restore
#line 6 "C:\Users\alex_\Desktop\MyCrowdFund\MyCrowdFund\MyCrowdFund.Web\Views\Project\Create.cshtml"
WriteAttributeValue("", 208, Html.IdFor(p => p.Options.Title), 208, 33, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("> </label>\r\n            <br>\r\n            ");
#nullable restore
#line 8 "C:\Users\alex_\Desktop\MyCrowdFund\MyCrowdFund\MyCrowdFund.Web\Views\Project\Create.cshtml"
       Write(Html.TextBoxFor( p => p.Options.Title, new {
                @class = "form control js-title",
           placeholder = "Enter  Title"
            } ));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group \">\r\n            <label");
                BeginWriteAttribute("for", " for=\"", 509, "\"", 554, 1);
#nullable restore
#line 14 "C:\Users\alex_\Desktop\MyCrowdFund\MyCrowdFund\MyCrowdFund.Web\Views\Project\Create.cshtml"
WriteAttributeValue("", 515, Html.IdFor(p => p.Options.Description), 515, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Description</label>\r\n            <br>\r\n            ");
#nullable restore
#line 16 "C:\Users\alex_\Desktop\MyCrowdFund\MyCrowdFund\MyCrowdFund.Web\Views\Project\Create.cshtml"
       Write(Html.TextBoxFor( p => p.Options.Description, new {
                @class = "form control js-description ",
           placeholder = "Enter  Description "
            } ));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"form-group \">\r\n            <label");
                BeginWriteAttribute("for", " for=\"", 854, "\"", 892, 1);
#nullable restore
#line 23 "C:\Users\alex_\Desktop\MyCrowdFund\MyCrowdFund\MyCrowdFund.Web\Views\Project\Create.cshtml"
WriteAttributeValue("", 860, Html.IdFor(p => p.Options.Cost), 860, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Cost</label>\r\n            <br>\r\n            ");
#nullable restore
#line 25 "C:\Users\alex_\Desktop\MyCrowdFund\MyCrowdFund\MyCrowdFund.Web\Views\Project\Create.cshtml"
       Write(Html.TextBoxFor( p => p.Options.Cost, new {
               @class = "form control js-cost",
          placeholder = "Enter Cost "
          } ));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"form-group \">\r\n            <label");
                BeginWriteAttribute("for", " for=\"", 1158, "\"", 1197, 1);
#nullable restore
#line 32 "C:\Users\alex_\Desktop\MyCrowdFund\MyCrowdFund\MyCrowdFund.Web\Views\Project\Create.cshtml"
WriteAttributeValue("", 1164, Html.IdFor(p => p.Options.Photo), 1164, 33, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Photo </label>\r\n            <br>\r\n            ");
#nullable restore
#line 34 "C:\Users\alex_\Desktop\MyCrowdFund\MyCrowdFund\MyCrowdFund.Web\Views\Project\Create.cshtml"
       Write(Html.TextBoxFor( p => p.Options.Photo, new {
                @class = "form control js-photo",
           placeholder = "Enter Photp "
            } ));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n\r\n            <label");
                BeginWriteAttribute("for", " for=\"", 1473, "\"", 1515, 1);
#nullable restore
#line 42 "C:\Users\alex_\Desktop\MyCrowdFund\MyCrowdFund\MyCrowdFund.Web\Views\Project\Create.cshtml"
WriteAttributeValue("", 1479, Html.IdFor(p => p.Options.Category), 1479, 36, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("> Product Category </label>\r\n            <br>\r\n            ");
#nullable restore
#line 44 "C:\Users\alex_\Desktop\MyCrowdFund\MyCrowdFund\MyCrowdFund.Web\Views\Project\Create.cshtml"
       Write(Html.DropDownListFor( p => p.Options.Category,
            Html.GetEnumSelectList( typeof( MyCrowdFund.ProjectCategory ) ),
            "Select Category", new { @class = "form-control js-category" } ));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n        </div>\r\n\r\n      \r\n\r\n            <div class=\"form-group col-md-4\">\r\n                <label");
                BeginWriteAttribute("for", " for=\"", 1879, "\"", 1924, 1);
#nullable restore
#line 53 "C:\Users\alex_\Desktop\MyCrowdFund\MyCrowdFund\MyCrowdFund.Web\Views\Project\Create.cshtml"
WriteAttributeValue("", 1885, Html.IdFor(p => p.RewardOptions.Title), 1885, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Cost</label>\r\n                ");
#nullable restore
#line 54 "C:\Users\alex_\Desktop\MyCrowdFund\MyCrowdFund\MyCrowdFund.Web\Views\Project\Create.cshtml"
           Write(Html.TextBoxFor( p => p.Options.Title, new {
                   @class = "form control js-reward-title",
              placeholder = "Enter Cost "
              } ));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"form-group col-md-4 \">\r\n                <label");
                BeginWriteAttribute("for", " for=\"", 2218, "\"", 2269, 1);
#nullable restore
#line 61 "C:\Users\alex_\Desktop\MyCrowdFund\MyCrowdFund\MyCrowdFund.Web\Views\Project\Create.cshtml"
WriteAttributeValue("", 2224, Html.IdFor(p => p.RewardOptions.Description), 2224, 45, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Description </label>\r\n                ");
#nullable restore
#line 62 "C:\Users\alex_\Desktop\MyCrowdFund\MyCrowdFund\MyCrowdFund.Web\Views\Project\Create.cshtml"
           Write(Html.TextBoxFor( p => p.RewardOptions.Description, new {
                    @class = "form control js-reward-description",
               placeholder = "Enter Desc "
                } ));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"form-group col-md-4 \">\r\n                <label");
                BeginWriteAttribute("for", " for=\"", 2593, "\"", 2638, 1);
#nullable restore
#line 69 "C:\Users\alex_\Desktop\MyCrowdFund\MyCrowdFund\MyCrowdFund.Web\Views\Project\Create.cshtml"
WriteAttributeValue("", 2599, Html.IdFor(p => p.RewardOptions.Price), 2599, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Price </label>\r\n                ");
#nullable restore
#line 70 "C:\Users\alex_\Desktop\MyCrowdFund\MyCrowdFund\MyCrowdFund.Web\Views\Project\Create.cshtml"
           Write(Html.TextBoxFor( p => p.RewardOptions.Price, new {
                    @class = "form control js-reward-price",
               placeholder = "Enter price "
                } ));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n            <button type=\"button\" class=\" btn btn-primary js-reward-submit\"> add rew</button>\r\n\r\n\r\n\r\n\r\n\r\n        <button type=\"submit\" class=\"btn btn-primary js-project-submit\">Submit</button>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 3 "C:\Users\alex_\Desktop\MyCrowdFund\MyCrowdFund\MyCrowdFund.Web\Views\Project\Create.cshtml"
AddHtmlAttributeValue("", 111, Url.Action(" Create", "Project"), 111, 33, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<div class=\"alert alert-danger js-create-project-alert\" role=\"alert\"\r\n     style=\"display: none\">\r\n</div>\r\n\r\n<div class=\"alert alert-success js-create-project-success\" role=\"alert\"\r\n     style=\"display: none\">\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MyCrowdFund.Web.Models.ProjectViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591