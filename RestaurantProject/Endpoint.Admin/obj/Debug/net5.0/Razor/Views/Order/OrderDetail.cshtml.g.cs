#pragma checksum "F:\RestaurantProject\RestaurantProject\EndPoint.Admin\Views\Order\OrderDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8958a2ceabd15baee9c162da90c0636fe7e63aec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_OrderDetail), @"mvc.1.0.view", @"/Views/Order/OrderDetail.cshtml")]
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
#line 1 "F:\RestaurantProject\RestaurantProject\EndPoint.Admin\Views\_ViewImports.cshtml"
using EndPoint.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\RestaurantProject\RestaurantProject\EndPoint.Admin\Views\_ViewImports.cshtml"
using EndPoint.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8958a2ceabd15baee9c162da90c0636fe7e63aec", @"/Views/Order/OrderDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a349a1701b6ff90e90c8fa8b80b0c9ee25fb30c5", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_OrderDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Application.Orders.DTO.GetOrderCustomerDetailForAdminDataModel>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\RestaurantProject\RestaurantProject\EndPoint.Admin\Views\Order\OrderDetail.cshtml"
  
    ViewData["Title"] = "جزئیات سفارش";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""col-lg-12 col-12 layout-spacing"">
    <div class=""statbox widget box box-shadow"">
        <div class=""widget-header"">
            <div class=""row"">
                <div class=""col-xl-12 col-md-12 col-sm-12 col-12"">
                    <h4> جزییات سفارش </h4>
                </div>
            </div>
        </div>
        <div class=""widget-content widget-content-area"">
            <div class=""text-danger""></div>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8958a2ceabd15baee9c162da90c0636fe7e63aec3879", async() => {
                WriteLiteral("نام کاربر");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 18 "F:\RestaurantProject\RestaurantProject\EndPoint.Admin\Views\Order\OrderDetail.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.UserName);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <input id=\"Name\" type=\"text\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 726, "\"", 749, 1);
#nullable restore
#line 19 "F:\RestaurantProject\RestaurantProject\EndPoint.Admin\Views\Order\OrderDetail.cshtml"
WriteAttributeValue("", 734, Model.UserName, 734, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" readonly>\r\n\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8958a2ceabd15baee9c162da90c0636fe7e63aec5831", async() => {
                WriteLiteral("شماره تلفن");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 21 "F:\RestaurantProject\RestaurantProject\EndPoint.Admin\Views\Order\OrderDetail.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.UserName);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <input id=\"Name\" type=\"text\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 883, "\"", 909, 1);
#nullable restore
#line 22 "F:\RestaurantProject\RestaurantProject\EndPoint.Admin\Views\Order\OrderDetail.cshtml"
WriteAttributeValue("", 891, Model.PhoneNumber, 891, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" readonly>\r\n\r\n            <div class=\"form-group mb-4\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8958a2ceabd15baee9c162da90c0636fe7e63aec7838", async() => {
                WriteLiteral("آدرس");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 25 "F:\RestaurantProject\RestaurantProject\EndPoint.Admin\Views\Order\OrderDetail.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.UserName);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <input id=\"Name\" type=\"text\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 1088, "\"", 1110, 1);
#nullable restore
#line 26 "F:\RestaurantProject\RestaurantProject\EndPoint.Admin\Views\Order\OrderDetail.cshtml"
WriteAttributeValue("", 1096, Model.Address, 1096, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly>
            </div>

            <table class=""multi-table table table-hover dataTable"" style=""width: 100%;"" id=""DataTables_Table_0"" role=""grid"" aria-describedby=""DataTables_Table_0_info"">
                <thead>
                    <tr role=""row"">
                        <th class=""sorting"" tabindex=""0"" aria-controls=""DataTables_Table_0"" rowspan=""1"" colspan=""1"" style=""width: 104px;"">نام کالا</th>
                        <th class=""sorting"" tabindex=""0"" aria-controls=""DataTables_Table_0"" rowspan=""1"" colspan=""1"" style=""width: 104px;"">تعداد کالا</th>
                    </tr>
                </thead>
                <tbody>

");
#nullable restore
#line 38 "F:\RestaurantProject\RestaurantProject\EndPoint.Admin\Views\Order\OrderDetail.cshtml"
                     foreach (var item in Model.orderDetailForAdminDataModels)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr role=\"row\">\r\n                        <td class=\"sorting_1\">");
#nullable restore
#line 41 "F:\RestaurantProject\RestaurantProject\EndPoint.Admin\Views\Order\OrderDetail.cshtml"
                                         Write(item.ProductOrderName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"sorting_1\">");
#nullable restore
#line 42 "F:\RestaurantProject\RestaurantProject\EndPoint.Admin\Views\Order\OrderDetail.cshtml"
                                         Write(item.ProductOrderQty);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>                      \r\n                    </tr>\r\n");
#nullable restore
#line 44 "F:\RestaurantProject\RestaurantProject\EndPoint.Admin\Views\Order\OrderDetail.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Application.Orders.DTO.GetOrderCustomerDetailForAdminDataModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
