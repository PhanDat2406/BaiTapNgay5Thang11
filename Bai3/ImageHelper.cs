using System.Drawing.Drawing2D;

namespace Bai3;

public static class ImageHelper
{
    public static void EnsureSampleImages(string directory)
    {
        try
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string phoneImg = Path.Combine(directory, "phone_screen_crack.png");
            if (!File.Exists(phoneImg))
            {
                using var bmp = new Bitmap(300, 200);
                using (var g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.FromArgb(40, 44, 52));
                    using var brush = new SolidBrush(Color.FromArgb(97, 175, 239));
                    using var font = new Font("Segoe UI", 12, FontStyle.Bold);
                    using var subFont = new Font("Segoe UI", 9, FontStyle.Regular);
                    
                    g.DrawString("Smartphone vỡ màn hình", font, Brushes.White, new PointF(30, 40));
                    g.DrawString("Đơn hàng: SC001 - iPhone 13", subFont, Brushes.LightGray, new PointF(30, 80));

                    using var pen = new Pen(Color.OrangeRed, 3);
                    g.DrawLine(pen, 50, 120, 150, 170);
                    g.DrawLine(pen, 150, 170, 220, 130);
                    g.DrawLine(pen, 150, 170, 180, 190);
                }
                bmp.Save(phoneImg);
            }

            string laptopImg = Path.Combine(directory, "laptop_battery.png");
            if (!File.Exists(laptopImg))
            {
                using var bmp = new Bitmap(300, 200);
                using (var g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.FromArgb(33, 37, 43));
                    using var font = new Font("Segoe UI", 12, FontStyle.Bold);
                    using var subFont = new Font("Segoe UI", 9, FontStyle.Regular);

                    g.DrawString("Laptop Dell - Lỗi nguồn/Pin", font, Brushes.LightGreen, new PointF(30, 40));
                    g.DrawString("Đơn hàng: SC002 - Dell XPS 15", subFont, Brushes.LightGray, new PointF(30, 80));

                    using var pen = new Pen(Color.Yellow, 2);
                    g.DrawRectangle(pen, 50, 120, 120, 50);
                    g.DrawLine(pen, 170, 135, 180, 135);
                    g.DrawLine(pen, 180, 135, 180, 155);
                    g.DrawLine(pen, 180, 155, 170, 155);
                }
                bmp.Save(laptopImg);
            }
        }
        catch
        {
            // Ignore if drawing fails on environment
        }
    }
}
