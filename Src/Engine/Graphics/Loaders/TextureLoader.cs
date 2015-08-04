using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace WaterWorld.Engine {
    class TextureLoader {
        public static Texture LoadTexture(string filename) {
            if(!File.Exists(filename)) {
                Console.WriteLine("Error: Cant find image with name: " + filename);
            }

            Bitmap textureBitmap = new Bitmap(filename);
            BitmapData TextureData =
                    textureBitmap.LockBits(
                    new System.Drawing.Rectangle(0, 0, textureBitmap.Width, textureBitmap.Height),
                    System.Drawing.Imaging.ImageLockMode.ReadOnly,
                    System.Drawing.Imaging.PixelFormat.Format24bppRgb
                );

            Texture texture = new Texture();
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, textureBitmap.Width, textureBitmap.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, TextureData.Scan0);
            texture.InitGL();

            return texture;
        }

    }
}
