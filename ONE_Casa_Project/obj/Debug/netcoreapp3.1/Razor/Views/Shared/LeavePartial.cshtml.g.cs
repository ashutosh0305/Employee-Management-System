#pragma checksum "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Shared\LeavePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d511bf70aa836320847e121febc06b4b8a3bc5ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_LeavePartial), @"mvc.1.0.view", @"/Views/Shared/LeavePartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d511bf70aa836320847e121febc06b4b8a3bc5ea", @"/Views/Shared/LeavePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80d281d67ca52e1c6e6ee6e74c87d547d9ff1d7b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_LeavePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""row"" style=""justify-content: space-around; background-color: #0277bd;"">
    <a href=""/leave"" style=""color:white;margin: 4px;"">View Leaves</a>
    <a href=""/leave/ApplyLeave"" style=""color:white;margin: 4px;"">Apply Leaves</a>
    <a href=""/leave/Pending"" style=""color:white;margin: 4px;"">Pending/Approved Leaves</a>
    <a href=""/leave/Taken"" style=""color:white;margin: 4px;"">Taken/Rejected/Cancelled Leaves</a>
    <a href=""/leave/PublicHoliday"" style=""color:white;margin: 4px;"">Public Holiday</a>
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
