#pragma checksum "E:\dotnet\tagosyswebsite\TagosysWeb\TagosysWeb\Pages\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f178991731a6067ae81605be9dd89d8bdbeeefd7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Web.Pages.Shared.Pages_Shared__Layout), @"mvc.1.0.view", @"/Pages/Shared/_Layout.cshtml")]
namespace Web.Pages.Shared
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f178991731a6067ae81605be9dd89d8bdbeeefd7", @"/Pages/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd1deb18c44cd7d6db8c10fa2a764d1f024bcd9a", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/style.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline search-i my-2 my-lg-0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/site.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f178991731a6067ae81605be9dd89d8bdbeeefd76556", async() => {
                WriteLiteral("\r\n    <title>TAGOSYS-Software Company Jaipur India (Website in under construction)</title>\r\n");
                WriteLiteral(@"    <meta charset=""utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />

    <meta property=""og:title"" content=""Site Title"" />
    <meta property=""og:type"" content=""website"" />
    <meta property=""og:url"" content=""https://tagosys.com/"" />
    <meta property=""og:image"" content=""https://tagosys.com/assets/site-images/logo.png"" />


    
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f178991731a6067ae81605be9dd89d8bdbeeefd77349", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css\">\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f178991731a6067ae81605be9dd89d8bdbeeefd78652", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f178991731a6067ae81605be9dd89d8bdbeeefd79830", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <style>\r\n        .section-title{\r\n            padding-top:75px!important;\r\n        }\r\n    </style>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f178991731a6067ae81605be9dd89d8bdbeeefd711830", async() => {
                WriteLiteral("\r\n \r\n    <header");
                BeginWriteAttribute("class", " class=\"", 994, "\"", 1002, 0);
                EndWriteAttribute();
                WriteLiteral(@">
       
        <div class=""men-nev"">
            <div id=""underdev"" class=""row"" style=""display:none;padding:0px!Important;margin:0px!important; background-color:lightgray;height:50px;width:100%;opacity:0.7"">
                <div class=""col-sm-11"" style=""text-align:center;color:red"">This site in under development mode. Some text and images that are not our proprietary. If anyone has issues with content of site please report to: tagosys@gmail.com. We will remove them.</div>
                <div class=""col-sm-1"" style=""padding:0px!Important;margin:0px!important;background-color:lightgray;""> <span style=""float:right"" onclick=""document.getElementById('underdev').style.display='none';"">Close(X)</span></div>
            </div>
            <div class=""container-fluid"">
                <nav class=""navbar navbar-expand-lg navbar-inverse menu"">
                    <a class=""navbar-brand"" href=""/index""><img src=""/assets/site-images/logo.png"" class=""logo-image""></a>
                    <button type=""button"" d");
                WriteLiteral(@"ata-toggle=""collapse"" data-target=""#navbarSupportedContent20""
                            aria-controls=""navbarSupportedContent20"" aria-expanded=""false"" aria-label=""Toggle navigation""
                            class=""navbar-toggler first-button collapsed"">
                        <i class=""fa fa-bars"" aria-hidden=""true""></i>
                    </button>
                    <div id=""navbarSupportedContent20"" class=""main-navigation collapse navbar-collapse mynav"">
                        <ul class=""main-navigation2 navbar-nav mr-auto nev-li-color menu-area-main"">
                            <li><a class=""nav-link "" href=""index"">Home </a></li>
                            <li><a href=""#about-section""
                                    class=""nav-link "" href=""index"">About </a></li>
                            <li><a href=""#Services "" class=""nav-link "">
                                    Services </a>
                            </li>
                            <li><a class=""nav-link "" href=""port");
                WriteLiteral(@"folio"" >Portfolio </a>
                            </li>
                            <li><a class=""nav-link "" href=""blog"">Blog </a></li>
                            <li><a class=""nav-link "" href=""Mobile-app"">Mobile App </a></li>
                            <li><a class=""nav-link "" href=""Team"">Team </a></li>
                            <li><a class=""nav-link "" href=""contact"">Contact </a></li>
                        </ul>
                        <ul class=""navbar-nav nev-li-color menu-area-main add-mobile-class Training-but"">
                             <button class=""training-button"" > <a href=""https://tagoskills.com/""> Training </a></button> 
                            <a>
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f178991731a6067ae81605be9dd89d8bdbeeefd715202", async() => {
                    WriteLiteral("<input type=\"search\" placeholder=\"Search\" aria-label=\"Search\" class=\"form-control\">");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            </a>\r\n                        </ul>\r\n                    </div>\r\n                </nav>\r\n            </div>\r\n        </div>\r\n    </header>\r\n\r\n\r\n\r\n    <main role=\"main\" >\r\n        ");
#nullable restore
#line 75 "E:\dotnet\tagosyswebsite\TagosysWeb\TagosysWeb\Pages\Shared\_Layout.cshtml"
   Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"


    </main>





    <section class=""container-fluid pt-2 pb-2"">
        <div class=""row"">
            <div class=""col-12 col-xl-12 col-lg-12"">
                
            </div>
        </div>
    </section>


    <footer class=""footer-bg"">
        <div class=""Windows container-fluid"">
            <div class=""row"">
              
                <div class=""col-xl-4 col-lg-4 col-md-3 col-sm-6 col-12"">
                    <div class=""c-heading-4 x-hidden-focus pb-2""><b> Our</b>
                        Works </div>
                    <ul class=""footer-ul footer-ul-img"">
                        <li><img src=""assets/site-images/footer-images/g1.jpg""></li>
                        <li><img src=""assets/site-images/footer-images/g2.jpg""></li>
                        <li><img src=""assets/site-images/footer-images/g3.jpg""></li>
                        <li><img src=""assets/site-images/footer-images/g4.jpg""></li>
                        <li><img src=""assets/site-images/footer-images/g5");
                WriteLiteral(@".jpg""></li>
                        <li><img src=""assets/site-images/footer-images/g6.jpg""></li>
                        <li><img src=""assets/site-images/footer-images/g7.jpg""></li>
                        <li><img src=""assets/site-images/footer-images/g8.jpg""></li>
                    </ul>
                </div>
                <div class=""col-xl-2 col-lg-2 col-md-3 col-6"">
                    <div class=""c-heading-4 x-hidden-focus pb-2"">
                        <b>
                            Latest
                        </b>Info
                    </div>
                    <ul class=""footer-ul"">
                        <li><a href=""index""> Home </a></li>
                        <li><a href=""blog""> Blog </a></li>
                        <li><a href=""Mobile-app""> Mobile app </a></li>
                        <li><a href=""Portfolio""> Portfolio </a></li>
                        <li><a href=""Contact""> Contact </a></li>
                         <li><a href=""refundpolicy"">Refund Policy</a></");
                WriteLiteral(@"li>
                         <li><a href=""terms"">Terms and Conditions</a></li>
                         <li><a href=""privacy"">Privacy Policy</a></li>
                    </ul>
                </div>
                <div class=""col-xl-3 col-lg-3 col-md-3 col-6"">
                    <div class=""c-heading-4 x-hidden-focus pb-2"">
                        <b>
                            Contact
                        </b>Information
                    </div>
                    <ul class=""footer-ul"">
                        <li> Phone Number </li>
                        <span> <i aria-hidden=""true"" class=""fa fa-phone""></i>  <a  href=""tel:+918387922385"">+91-8387-922-385</a></span>
                        <li> Email Address</li>
                        <span> <i aria-hidden=""true"" class=""fa fa-envelope""></i> <a href=""mailto:tagosys@gmail.com""> : tagosys@gmail.com </a></span>
                        <li> Location</li>
                        <span> <i aria-hidden=""true"" class=""fa fa-map-marker""></i");
                WriteLiteral(@"> <a href=""http://maps.google.com""> Jaipur, INDIA. </a></span>
                    </ul>
                </div>
                  <div class=""col-xl-3 col-lg-3 col-md-3 col-sm-6 col-12"">
                    <div class=""footer-ul-logo-img"">
                        <div class=""c-heading-4 x-hidden-focus pb-2""><a");
                BeginWriteAttribute("href", " href=\"", 7526, "\"", 7533, 0);
                EndWriteAttribute();
                WriteLiteral(@"><img
                                    src=""assets/site-images/footer-images/logo-bottom.png"" style=""width: 50%;""></a>
                        </div>
                        <ul class=""footer-ul"">
                            <li> TAGOSYS is a global offshore service provider<br> with a great team strength.</li>
                            <li>
                            <div class=""bottom-icon1"" > Follow tagosys 
                              <a href=""http://www.facebook.com""><img src=""assets/site-images/footer-images/facebook.svg"" class=""bottom-icon""></a>
                              <a  href=""http://www.twitter.com""><img src=""assets/site-images/footer-images/twitter.svg"" class=""bottom-icon""></a>
                              <a href=""http://www.youtube.com""><img src=""assets/site-images/footer-images/youtube.svg"" class=""bottom-icon""></a>
                             </div>
                             </li>
                        </ul>
                    </div>
                </div>
  ");
                WriteLiteral(@"              <div class=""col-6"">
                    <p class=""c-uhff-lang-selector""><i aria-hidden=""true"" class=""fa fa-renren""></i> Mail (India)</p>
                </div>
                <div class=""col-6"">
                    <h6 style=""text-align: right;"">
                        <ul class=""bottom-last"">
                            <li>© 2018 TAGOSYS. All rights reserved | Website is under construction | Design by <b> TAGOSYS</b></li>
                        </ul>
                        <div><a");
                BeginWriteAttribute("href", " href=\"", 9071, "\"", 9078, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"scrolltop right-position right-30 scroll-static\"><i\r\n                                    class=\"fa fa-angle-up\"></i></a></div>\r\n                    </h6>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </footer>\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f178991731a6067ae81605be9dd89d8bdbeeefd722884", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f178991731a6067ae81605be9dd89d8bdbeeefd723984", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f178991731a6067ae81605be9dd89d8bdbeeefd725084", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
#nullable restore
#line 178 "E:\dotnet\tagosyswebsite\TagosysWeb\TagosysWeb\Pages\Shared\_Layout.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n    ");
#nullable restore
#line 180 "E:\dotnet\tagosyswebsite\TagosysWeb\TagosysWeb\Pages\Shared\_Layout.cshtml"
Write(await RenderSectionAsync("Scripts", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(document).ready(function () {
            $('.scrolltop').click(function () {
                $('html, body').animate({ scrollTop: 0 }, 'slow');
                return false;
            });
            $('.nav-link').on('click', function () {
                $('.navbar-collapse').collapse('hide');
            });
        });

        $(window).scroll(function () {
            if ($(this).scrollTop() > 10) {
                $('header').addClass('fixed');
            } else {

                $('header').removeClass();
            }

        });
        $(""header [href^='#']"").click(function () {
            id = $(this).attr(""href"")
            $('html, body').animate({
                scrollTop: $(id).offset().top - 80
            }, 2000);
        });

        $(window).scroll(function () {
            if ($(this).scrollTop() > 10) {

                $('header').addClass('fixed');
            } else {
                $('header')");
                WriteLiteral(@".removeClass('fixed');
            }
        });

              $(document).ready(function () {
        
          $('.first-button').on('click', function () {
          
            $('.animated-icon1').toggleClass('open');
          });
          $('.second-button').on('click', function () {
          
            $('.animated-icon2').toggleClass('open');
          });
          $('.third-button').on('click', function () {
          
            $('.animated-icon3').toggleClass('open');
          });
          });
      </script>
      <script>
          $(document).ready(function () {
$('.first-button').on('click', function () {
  $('.animated-icon1').toggleClass('open');
});
$('.second-button').on('click', function () {

  $('.animated-icon2').toggleClass('open');
});
$('.third-button').on('click', function () {

  $('.animated-icon3').toggleClass('open');
});
}); </script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>\r\n");
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
