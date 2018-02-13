using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DinkToPdf.Contracts;
using System.IO;
using PDFCoreTest.Services;
using PDFCoreTest.ViewModels;

namespace DinkToPdf.TestWebServer.Controllers
{
    [Route("api/[controller]")]
    public class ConvertController : Controller
    {
        private IConverter _converter;

        private ITemplateService _templateService;

        public ConvertController(IConverter converter, ITemplateService templateService)
        {
            _converter = converter;

            _templateService = templateService;
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var doc = new HtmlToPdfDocument()
        //    {
        //        GlobalSettings = {
        //            PaperSize = PaperKind.A3,
        //            Orientation = Orientation.Landscape,
        //        },

        //        Objects = {
        //            new ObjectSettings()
        //            {
        //                Page = "http://google.com/",
        //            },
        //             new ObjectSettings()
        //            {
        //                Page = "https://github.com/",
        //            }
        //        }
        //    };

        //    byte[] pdf = _converter.Convert(doc);

        //    return new FileContentResult(pdf, "application/pdf");
        //}

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var vm = new TestViewModel
            {
                Title = "Test Title",
                Content = "Test Content"
            };

            string documentContent = await _templateService.RenderTemplateAsync("Templates/TestTemplate", vm);

            var output = _converter.Convert(new HtmlToPdfDocument()
            {
                Objects =
                    {
                        new ObjectSettings()
                        {
                            HtmlContent = documentContent
                        }
                }
            });

            return new FileContentResult(output, "application/pdf");
        }
    }
}