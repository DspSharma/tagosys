#pragma checksum "E:\dotnet\tagosyswebsite\TagosysWeb\TagosysWeb\Pages\Contact.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93dcba2084ad70fce053c3f58ebd28968e46a4d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Web.Pages.Pages_Contact), @"mvc.1.0.razor-page", @"/Pages/Contact.cshtml")]
namespace Web.Pages
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
#line 1 "E:\dotnet\tagosyswebsite\TagosysWeb\TagosysWeb\Pages\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93dcba2084ad70fce053c3f58ebd28968e46a4d5", @"/Pages/Contact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd1deb18c44cd7d6db8c10fa2a764d1f024bcd9a", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Contact : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"    

             <section class=""breadcrumbs"">
               <div class=""container"">
                   <ol>
                       <li><a>Home</a></li>
                       <li>Contact</li>
                   </ol>
                   
               </div>
             </section>
    ");
#nullable restore
#line 16 "E:\dotnet\tagosyswebsite\TagosysWeb\TagosysWeb\Pages\Contact.cshtml"
Write(Html.Partial("Shared/PartialView/_Contact"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n           \r\n    \r\n    ");
#nullable restore
#line 19 "E:\dotnet\tagosyswebsite\TagosysWeb\TagosysWeb\Pages\Contact.cshtml"
Write(Html.Partial("Shared/PartialView/_Clientslideronpage"));

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Web.Pages.ContactModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Web.Pages.ContactModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Web.Pages.ContactModel>)PageContext?.ViewData;
        public Web.Pages.ContactModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
