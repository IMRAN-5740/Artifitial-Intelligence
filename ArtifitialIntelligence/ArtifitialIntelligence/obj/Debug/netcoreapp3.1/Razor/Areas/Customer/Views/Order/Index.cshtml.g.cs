#pragma checksum "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bfe202e8bce0ed9b56ea004db20f8dee4e1d94cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_Order_Index), @"mvc.1.0.view", @"/Areas/Customer/Views/Order/Index.cshtml")]
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
#line 1 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\_ViewImports.cshtml"
using ArtifitialIntelligence;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
using ArtifitialIntelligence.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bfe202e8bce0ed9b56ea004db20f8dee4e1d94cf", @"/Areas/Customer/Views/Order/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"812e3fdbffd9717063f4afaf793ee256a3d5fa4b", @"/Areas/Customer/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Customer_Views_Order_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<X.PagedList.IPagedList<Order>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-info "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-danger "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-id", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ButtonPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("100px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 6 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
  
    // int count = 0;
    var userRole = HttpContextAccessor.HttpContext.Session.GetString("roleName");
   
    var myUserName = HttpContextAccessor.HttpContext.User.Identity.Name;
   
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 15 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";
    int serialNo = 1;

    int numOfSerial = 1;
    


#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .thead
    {
        text-align:center;
        color:red;
    }
</style>

<h1 style=""text-align:center;color:red"">Order List</h1>
<table class=""table table-bordered"">
    <thead>
        <tr>
            <th>Serial No</th>
            <th>
               Order No
            </th>
            <th>
               Customer Name
            </th>
             <th>
               Products Name
            </th>
            <th>
               Phone Number
            </th>
            <th>
               Email
            </th>
            <th>
                Address
            </th>
            <th> Order Date</th>
            <th> Total Amount</th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody>
        
");
#nullable restore
#line 62 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
 foreach (var item in Model) 
{

            

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
             if ((userRole == "Client" && myUserName==item.Email )|| (userRole=="Admin"))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 69 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
                    Write(serialNo++);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 72 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.OrderNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 75 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"text-center\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bfe202e8bce0ed9b56ea004db20f8dee4e1d94cf9723", async() => {
                WriteLiteral("<i class=\"fa-sharp fa-solid fa-eye\"></i> ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 78 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
                                                                              WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bfe202e8bce0ed9b56ea004db20f8dee4e1d94cf12088", async() => {
                WriteLiteral("<i class=\"fa-sharp fa-solid fa-circle-xmark\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 82 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.PhoneNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 85 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 88 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 91 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.OrderDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 94 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.TotalOrderAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                   \r\n\r\n");
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bfe202e8bce0ed9b56ea004db20f8dee4e1d94cf15903", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#nullable restore
#line 101 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = item.Id;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                </tr>\r\n");
#nullable restore
#line 104 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"

                
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 106 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
             
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 108 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
         if (ViewBag.ProductDetails!=null)

      
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr > \r\n                <td></td>\r\n                <td></td>\r\n                <td>\r\n                    <h1 style=\"text-align:center;color:green\">Order Products</h1>\r\n             </td>\r\n             </tr>\r\n");
#nullable restore
#line 119 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
             foreach (var productDetails in ViewBag.ProductDetails)
            {
               

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 123 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
                    Write(numOfSerial++);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 125 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
                   Write(productDetails.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"width:100;height:100;\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bfe202e8bce0ed9b56ea004db20f8dee4e1d94cf19609", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3847, "~/", 3847, 2, true);
#nullable restore
#line 128 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
AddHtmlAttributeValue("", 3849, productDetails.Image, 3849, 21, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 131 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
                   Write(productDetails.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n            </tr>\r\n");
#nullable restore
#line 134 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
                
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td></td>\r\n                <td></td>\r\n                <td>\r\n                    <h4 style=\"color:green\">Total Price : ");
#nullable restore
#line 140 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
                                                     Write(ViewBag.ProductSum);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 143 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
          

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("       \r\n\r\n    \r\n\r\n           \r\n    </tbody>\r\n</table>\r\n\r\n<div class=\"clear\"></div>\r\nPage ");
#nullable restore
#line 155 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
 Write(Model.PageCount<Model.PageNumber?0:Model.PageNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 155 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
                                                       Write(Model.PageCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"div-pagination\">\r\n    ");
#nullable restore
#line 157 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
Write(Html.PagedListPager(Model,page=>Url.Action("Index",new{page=page})));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n");
            WriteLiteral("\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n         <script type=\"text/javascript\">\r\n        $(function () {\r\n            var ok = \'");
#nullable restore
#line 170 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
                 Write(TempData["ok"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"'
            if (ok != '') {
                alertify.success(ok);
            }
        })
    </script>
    
    <script type=""text/javascript"">
        $(document).ready(function () 
        {
            $('#myTable').DataTable({
                dom: 'Bfrtip',
                buttons: [
                    'copy', 'csv', 'excel', 'pdf', 'print'
                ]
            });
        });
        $(function () {
            var add = '");
#nullable restore
#line 188 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
                  Write(TempData["add"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'\r\n            if (add != \'\') {\r\n                alertify.success(add);\r\n\r\n            }\r\n        })\r\n    </script>\r\n\r\n    <script type=\"text/javascript\">\r\n        $(function () {\r\n            var edit = \'");
#nullable restore
#line 198 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
                   Write(TempData["edit"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'\r\n            if (edit != \'\') {\r\n                alertify.success(edit);\r\n            }\r\n        })\r\n    </script>\r\n    <script type=\"text/javascript\">\r\n        $(function () {\r\n            var done = \'");
#nullable restore
#line 206 "E:\Artifitial Intelligence\ArtifitialIntelligence\ArtifitialIntelligence\Areas\Customer\Views\Order\Index.cshtml"
                   Write(TempData["done"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\'\r\n            if (done != \'\') {\r\n                alertify.error(done);\r\n\r\n            }\r\n        })\r\n    </script>\r\n\r\n");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<X.PagedList.IPagedList<Order>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
