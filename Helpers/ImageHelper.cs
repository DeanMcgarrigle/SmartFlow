using System;
using System.Drawing;
using System.IO;
using Nancy;

namespace SmartFlow.Helpers
{
    public class ImageHelper
    {
        public static Size GetChartDimensions(string floor, int chartWidth, int chartHeight)
        {
            var imagePath = string.Format(@"/images/{0}.png", floor);
            var path = StaticConfiguration.IsRunningDebug
                ? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePath.Remove(0, 1))
                : Path.Combine(@"C:\SmartFlow\Floor Plans\", string.Format("{0}.png", floor));

            var image = Image.FromFile(path);
            return ResizeFit(new Size(image.Width, image.Height), new Size(chartWidth, chartHeight));
        }

        private static Size ResizeFit(Size originalSize, Size maxSize)
        {
            var widthRatio = (double)maxSize.Width / originalSize.Width;
            var heightRatio = (double)maxSize.Height / originalSize.Height;
            var maxAspectRatio = Math.Max(widthRatio, heightRatio);
            return maxAspectRatio > 1 ? originalSize : new Size((int)(originalSize.Width * maxAspectRatio), (int)(originalSize.Height * maxAspectRatio));
        }
    }
}