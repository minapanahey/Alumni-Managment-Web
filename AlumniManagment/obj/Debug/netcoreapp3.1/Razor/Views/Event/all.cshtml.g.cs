#pragma checksum "C:\Users\Zubair Khakwani\source\repos\AlumniManagment\AlumniManagment\Views\Event\all.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ce7e2fa8144deffb1bd52d2bc3bcb4d18558f9b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Event_all), @"mvc.1.0.view", @"/Views/Event/all.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Zubair Khakwani\source\repos\AlumniManagment\AlumniManagment\Views\_ViewImports.cshtml"
using AlumniManagment;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Zubair Khakwani\source\repos\AlumniManagment\AlumniManagment\Views\_ViewImports.cshtml"
using AlumniManagment.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Zubair Khakwani\source\repos\AlumniManagment\AlumniManagment\Views\_ViewImports.cshtml"
using AlumniManagment.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Zubair Khakwani\source\repos\AlumniManagment\AlumniManagment\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Zubair Khakwani\source\repos\AlumniManagment\AlumniManagment\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Zubair Khakwani\source\repos\AlumniManagment\AlumniManagment\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Zubair Khakwani\source\repos\AlumniManagment\AlumniManagment\Views\_ViewImports.cshtml"
using AlumniManagment.ViewModels.Admin;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce7e2fa8144deffb1bd52d2bc3bcb4d18558f9b1", @"/Views/Event/all.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14132ccce4c00ca1133fcd11770c2b98d5b0180c", @"/Views/_ViewImports.cshtml")]
    public class Views_Event_all : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AlumniManagment.Dtos.EventDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Zubair Khakwani\source\repos\AlumniManagment\AlumniManagment\Views\Event\all.cshtml"
  
                /**/

                ViewBag.Title = "Upcomming Events";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3 style=\"text-align:center\">Upcomming Events</h3>\r\n\r\n");
#nullable restore
#line 10 "C:\Users\Zubair Khakwani\source\repos\AlumniManagment\AlumniManagment\Views\Event\all.cshtml"
 foreach (var item in Model)
{
    var hrs = (item.calendar.start - DateTime.Now).Hours;
    var days = (item.calendar.start - DateTime.Now).Days;
    var Mins = (item.calendar.start - DateTime.Now).Minutes;
    var Secs = (item.calendar.start - DateTime.Now).Seconds;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""single-upcoming-event"">
        <div class=""row"">
            <div class=""col-lg-5"">
                <div class=""up-event-thumb"">
                    <img src=""assets/img/event/event-img-1.jpg"" class=""img-fluid"" alt=""Upcoming Event"">
                    <h4 class=""up-event-date"">Start ");
#nullable restore
#line 21 "C:\Users\Zubair Khakwani\source\repos\AlumniManagment\AlumniManagment\Views\Event\all.cshtml"
                                               Write(item.calendar.start);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                    <h4 class=\"up-event-date\">End ");
#nullable restore
#line 22 "C:\Users\Zubair Khakwani\source\repos\AlumniManagment\AlumniManagment\Views\Event\all.cshtml"
                                             Write(item.calendar.end);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                    <h4 class=\"up-event-date\">Registration Fee: Rs ");
#nullable restore
#line 23 "C:\Users\Zubair Khakwani\source\repos\AlumniManagment\AlumniManagment\Views\Event\all.cshtml"
                                                              Write(item.registrationFee);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
                </div>
            </div>

            <div class=""col-lg-7"">
                <div class=""display-table"">
                    <div class=""display-table-cell"">
                        <div class=""up-event-text"">
                            <div class=""event-countdown-container"" data-date=""2018/9/10"">
                                <p style=""text-align: center"">Remaining</p>
                                <div class=""event-countdown-counter"">
                                    <div class=""counter-item"">
                                        <span class=""counter-label"">Days</span>
                                        <span class=""single-cont"">");
#nullable restore
#line 36 "C:\Users\Zubair Khakwani\source\repos\AlumniManagment\AlumniManagment\Views\Event\all.cshtml"
                                                             Write(days);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                    </div>

                                    <div class=""counter-item"">
                                        <span class=""counter-label"">Hrs</span>
                                        <span class=""single-cont"">");
#nullable restore
#line 41 "C:\Users\Zubair Khakwani\source\repos\AlumniManagment\AlumniManagment\Views\Event\all.cshtml"
                                                             Write(hrs);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                    </div>

                                    <div class=""counter-item"">
                                        <span class=""counter-label"">Mins</span>
                                        <span class=""single-cont"">");
#nullable restore
#line 46 "C:\Users\Zubair Khakwani\source\repos\AlumniManagment\AlumniManagment\Views\Event\all.cshtml"
                                                             Write(Mins);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                    </div>

                                    <div class=""counter-item"">
                                        <span class=""counter-label"">Secs</span>
                                        <span class=""single-cont"">");
#nullable restore
#line 51 "C:\Users\Zubair Khakwani\source\repos\AlumniManagment\AlumniManagment\Views\Event\all.cshtml"
                                                             Write(Secs);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                    </div>\r\n                                </div>\r\n\r\n                            </div>\r\n                            \r\n                            <h3><a href=\"single-event.html\">");
#nullable restore
#line 57 "C:\Users\Zubair Khakwani\source\repos\AlumniManagment\AlumniManagment\Views\Event\all.cshtml"
                                                       Write(item.title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h3>\r\n                            <p> ");
#nullable restore
#line 58 "C:\Users\Zubair Khakwani\source\repos\AlumniManagment\AlumniManagment\Views\Event\all.cshtml"
                           Write(item.description);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 2800, "\"", 2863, 1);
#nullable restore
#line 59 "C:\Users\Zubair Khakwani\source\repos\AlumniManagment\AlumniManagment\Views\Event\all.cshtml"
WriteAttributeValue("", 2807, Url.Action("register","event",new { eventId = item.id}), 2807, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"register-button\">join with us</a>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 66 "C:\Users\Zubair Khakwani\source\repos\AlumniManagment\AlumniManagment\Views\Event\all.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AlumniManagment.Dtos.EventDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
