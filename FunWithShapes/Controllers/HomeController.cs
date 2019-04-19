using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FunWithShapes.Models;
using System.IO;
using System.Drawing;

namespace FunWithShapes.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Circle()
        {
            Circle circle = new Circle(Color.Purple);
            var bitmap = circle.Draw();
            var bitmapBytes = BitmapToBytes(bitmap);

            bitmap.Dispose();
            return File(bitmapBytes, "image/jpeg");
        }

        public ActionResult Triangle()
        {
            Triangle triangle = new Triangle(Color.Red);
            var bitmap = triangle.Draw();
            var bitmapBytes = BitmapToBytes(bitmap);

            bitmap.Dispose();
            return File(bitmapBytes, "image/jpeg");
        }

        public ActionResult Square()
        {
            Square square = new Square(Color.Green);
            var bitmap = square.Draw();
            var bitmapBytes = BitmapToBytes(bitmap);

            bitmap.Dispose();
            return File(bitmapBytes, "image/jpeg");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private static byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
