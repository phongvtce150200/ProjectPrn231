#pragma checksum "G:\PRN231\GITHUB\ProjectPrn231\WebClient\Views\Appointment\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b27cee071b5d0d04b90e2ae385e9b20a521a72c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Appointment_Index), @"mvc.1.0.view", @"/Views/Appointment/Index.cshtml")]
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
#line 1 "G:\PRN231\GITHUB\ProjectPrn231\WebClient\Views\_ViewImports.cshtml"
using WebClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\PRN231\GITHUB\ProjectPrn231\WebClient\Views\_ViewImports.cshtml"
using WebClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b27cee071b5d0d04b90e2ae385e9b20a521a72c", @"/Views/Appointment/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74eabcf7e030352eff2473b217adffa5ad5752fa", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Appointment_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "G:\PRN231\GITHUB\ProjectPrn231\WebClient\Views\Appointment\Index.cshtml"
  
    Layout = "~/Views/Shared/_LayoutDoctor.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div id=""calendar"">

</div>
<script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.1/jquery.min.js""></script>
<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.0.1/fullcalendar.min.css"">
<script src=""https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.16.0/moment.min.js""></script>
<script src=""https://cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.0.1/fullcalendar.min.js""></script>
<script>
    $(document).ready(function(){
        
            $('#calendar').fullCalendar('destroy');
            $('#calendar').fullCalendar({
                header:{
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,basicWeek,basicDay,agenda'
                },
                firstDay: 1, //The day that each week begins (Monday=1)
                slotMinutes: 60,
            events: '/Appointment/GetEvents'
            });

    })
</script>");
        }
        #pragma warning restore 1998
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
