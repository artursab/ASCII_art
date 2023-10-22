using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASCII_art
{
    class Program
    {
        private const double WIDTH_OFSET = 1.5;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
           var openFileDialog = new OpenFileDialog
            {
                Filter = "Images | *.bmp; *.png; *.jpg; *.JPEG"
            };

            Console.WriteLine("Press enter to start...\n");

            while (true)
            {
                Console.ReadLine();

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    continue;

                Console.Clear();

                var bitmap = new Bitmap(openFileDialog.FileName);
                bitmap = ResizeBitmap(bitmap);

                
                
            }
        }

        private static Bitmap ResizeBitmap(Bitmap bitmap)
        {
            var maxWidth = 350;
            var newHeight = bitmap.Height / WIDTH_OFSET * maxWidth / bitmap.Width;

            if (bitmap.Width > maxWidth || bitmap.Height > newHeight)
                bitmap = new Bitmap(bitmap, new Size(maxWidth, (int) newHeight));
            return bitmap;
        }

    }
}
