#pragma checksum "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Leave\Pending.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b642ba1eda38a4fc245d4b849322280d660611e8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Leave_Pending), @"mvc.1.0.view", @"/Views/Leave/Pending.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b642ba1eda38a4fc245d4b849322280d660611e8", @"/Views/Leave/Pending.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80d281d67ca52e1c6e6ee6e74c87d547d9ff1d7b", @"/Views/_ViewImports.cshtml")]
    public class Views_Leave_Pending : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ONE_Casa_Project.Models.Leaves>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 6 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Leave\Pending.cshtml"
  
    ViewData["Title"] = "Planned";

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Leave\Pending.cshtml"
Write(Html.Partial("LeavePartial"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h4 style="" margin-left: 1vw; padding-top: 4vh; padding-bottom: 4vh;"">Pending/Approved Leaves</h4>

<table class=""table"" style="" background-color: white;width: 95vw;margin: auto"">
    <thead class=""table-dark"">
        <tr>
            <th>
                Name - Employee ID
            </th>
            <th>
                Leave Type / Avail
            </th>
            <th>
                Start Date
            </th>
            <th>
                End Date
            </th>
            <th>
                Duration
            </th>
            <th>
                Status
            </th>
            <th>
                Action
            </th>

        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 40 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Leave\Pending.cshtml"
         foreach (var item in Model)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Leave\Pending.cshtml"
             if (item.Status == "Pending" || item.Status == "Approved")
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 46 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Leave\Pending.cshtml"
                   Write(Html.DisplayFor(modelItem => item.EmpName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 49 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Leave\Pending.cshtml"
                   Write(item.LeaveType);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 49 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Leave\Pending.cshtml"
                                     Write(item.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <p>");
#nullable restore
#line 52 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Leave\Pending.cshtml"
                       Write(item.FromDate.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("-");
#nullable restore
#line 52 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Leave\Pending.cshtml"
                                             Write( item.FromDate.Month <= 10 ? "0"+ item.FromDate.Month :""+ item.FromDate.Month );

#line default
#line hidden
#nullable disable
            WriteLiteral("-");
#nullable restore
#line 52 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Leave\Pending.cshtml"
                                                                                                                                Write( item.FromDate.Day <= 10 ? "0"+ item.FromDate.Day :""+ item.FromDate.Day );

#line default
#line hidden
#nullable disable
            WriteLiteral(" <p />\r\n                    </td>\r\n                    <td>\r\n                        <p>");
#nullable restore
#line 55 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Leave\Pending.cshtml"
                       Write(item.ToDate.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("-");
#nullable restore
#line 55 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Leave\Pending.cshtml"
                                           Write( item.ToDate.Month <= 10 ? "0"+ item.ToDate.Month :""+ item.ToDate.Month );

#line default
#line hidden
#nullable disable
            WriteLiteral("-");
#nullable restore
#line 55 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Leave\Pending.cshtml"
                                                                                                                        Write( item.ToDate.Day <= 10 ? "0"+ item.ToDate.Day :""+ item.ToDate.Day );

#line default
#line hidden
#nullable disable
            WriteLiteral(" <p />\r\n\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 59 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Leave\Pending.cshtml"
                         if (item.LeaveType == "Half Day")
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p style=\"margin:0\">0.5</p>\r\n");
#nullable restore
#line 62 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Leave\Pending.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p style=\"margin:0\">");
#nullable restore
#line 65 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Leave\Pending.cshtml"
                                            Write(item.ToDate.Subtract(item.FromDate).Days + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 66 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Leave\Pending.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 69 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Leave\Pending.cshtml"
                   Write(item.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 2332, "\"", 2366, 2);
            WriteAttributeValue("", 2339, "/Leave/PendingEdit/", 2339, 19, true);
#nullable restore
#line 72 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Leave\Pending.cshtml"
WriteAttributeValue("", 2358, item.Id, 2358, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary edithide\" style=\"margin:0;color:white\">Edit</a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 75 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Leave\Pending.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\ashutosh.bisht\source\repos\One_Casa_Project\ONE_Casa_Project\Views\Leave\Pending.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ONE_Casa_Project.Models.Leaves>> Html { get; private set; }
    }
}
#pragma warning restore 1591
