#pragma checksum "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Employee\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20a26d6c0dfd8ad6c9c94578a322151f47b0431e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee_Dashboard), @"mvc.1.0.view", @"/Views/Employee/Dashboard.cshtml")]
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
#line 1 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\_ViewImports.cshtml"
using ONE_Casa_Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\_ViewImports.cshtml"
using ONE_Casa_Project.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20a26d6c0dfd8ad6c9c94578a322151f47b0431e", @"/Views/Employee/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80d281d67ca52e1c6e6ee6e74c87d547d9ff1d7b", @"/Views/_ViewImports.cshtml")]
    public class Views_Employee_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Name", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("font-size:8px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""maincontainerd"">
    <div class=""containerd "">
        <div class=""containerd-in d-inline-flex"">
            <div class=""leavedetail"" style=""margin-top: -21px;"">
                <h2>Leaves Detail</h2>
            </div>

            <div id=""month"">
                <select class=""firstbox"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20a26d6c0dfd8ad6c9c94578a322151f47b0431e4160", async() => {
                WriteLiteral("Select Month");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20a26d6c0dfd8ad6c9c94578a322151f47b0431e5455", async() => {
                WriteLiteral("Jan");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20a26d6c0dfd8ad6c9c94578a322151f47b0431e6430", async() => {
                WriteLiteral("Feb");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </select>\r\n            </div>\r\n            <div id=\"year\">\r\n                <select class=\"Secondbox\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20a26d6c0dfd8ad6c9c94578a322151f47b0431e7537", async() => {
                WriteLiteral("Select Year");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20a26d6c0dfd8ad6c9c94578a322151f47b0431e8831", async() => {
                WriteLiteral("2021");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20a26d6c0dfd8ad6c9c94578a322151f47b0431e9807", async() => {
                WriteLiteral("2020");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </select>
            </div>

        </div>

    </div>
    <div class=""container2d d-flex"" style=""margin-top:35px; "">
        <div class=""c2i1"" id=""c2item1"">
            <div class=""oc2c"" id=""oc2c1""></div>
            <div class=""c2c1"" id=""c2c1id1""> ");
#nullable restore
#line 53 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Employee\Dashboard.cshtml"
                                       Write(ViewBag.taken);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n            <div class=\"c2r1\">Taken</div>\r\n        </div>\r\n        <div class=\"c2i1\" id=\"c2item2\">\r\n            <div class=\"oc2c\" id=\"oc2c2\"></div>\r\n            <div class=\"c2c1\" id=\"c2c1id2\">");
#nullable restore
#line 59 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Employee\Dashboard.cshtml"
                                      Write(ViewBag.Approved);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            <div class=\"c2r1\">Approved</div>\r\n        </div>\r\n        <div class=\"c2i1\" id=\"c2item3\">\r\n            <div class=\"oc2c\" id=\"oc2c3\"></div>\r\n            <div class=\"c2c1\" id=\"c2c1id3\">");
#nullable restore
#line 64 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Employee\Dashboard.cshtml"
                                      Write(ViewBag.pending);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            <div class=\"c2r1\">Pending</div>\r\n        </div>\r\n        <div class=\"c2i1\" id=\"c2item4\">\r\n            <div class=\"oc2c\" id=\"oc2c4\"></div>\r\n            <div class=\"c2c1\" id=\"c2c1id4\">");
#nullable restore
#line 69 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Employee\Dashboard.cshtml"
                                      Write(ViewBag.Canceled);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            <div class=\"c2r1\">Cancelled</div>\r\n        </div>\r\n        <div class=\"c2i1\" id=\"c2item5\">\r\n            <div class=\"oc2c\" id=\"oc2c5\"></div>\r\n            <div class=\"c2c1\" id=\"c2c1id5\">");
#nullable restore
#line 74 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Employee\Dashboard.cshtml"
                                      Write(ViewBag.Reject);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
            <div class=""c2r1"">Rejected</div>
        </div>

    </div>




    <div class=""metercontain"" style=""     background-color: #fff;
        margin-left: 26px;
        margin-right: 26px;
        margin-top: 49px;
        border: 10px;
        height: 257px;
        border: 1px;
        box-shadow: 2px 4px 6px 0 gray,2px 6px 20px 2px gray;
        margin-bottom: 31px;"">
        <div class=""meterrow1"" style=""padding: 13px; display: flex; "">
            <div class=""timesheet"" style="" font-size: 21px; "">Timesheet</div>
            <select name=""project"" class=""formcontrol custom-select"" style=""margin-left: 80%;width: 204px;height: 33px;"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20a26d6c0dfd8ad6c9c94578a322151f47b0431e14072", async() => {
                WriteLiteral("Select Name");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </select>
        </div>
        <div class=""graph"" style=""display: flex; justify-content: space-evenly;     margin-top: 12px; padding: 16px;"">
            <div class=""picture""> <img src=""https://qaonecasav2.onebcg.com/assets/images/gauge-img.png"" /> </div>
            <div class=""picture""> <img src=""https://qaonecasav2.onebcg.com/assets/images/gauge-img.png"" /> </div>
            <div class=""picture""> <img src=""https://qaonecasav2.onebcg.com/assets/images/gauge-img.png"" /> </div>



        </div>
    </div>


</div>









");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
