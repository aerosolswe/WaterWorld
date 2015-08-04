using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace WaterWorld.Engine {
    class GraphicsUtil {
        public static void ClearScreen() {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        public static void InitGL() {
            GL.ClearColor(Color4.MidnightBlue);

            GL.FrontFace(FrontFaceDirection.Ccw);
            GL.CullFace(CullFaceMode.Back);
            GL.Enable(EnableCap.CullFace);

            GL.Enable(EnableCap.DepthTest);

            GL.Enable(EnableCap.FramebufferSrgb);

            GL.Enable(EnableCap.Texture2D);
        }
    }
}
