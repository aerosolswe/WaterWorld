using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace WaterWorld.Engine {
    class GraphicsEngine {
        private BasicShader basicShader;
        private Camera mainCamera;


        public void Init() {
            mainCamera = new Camera(Matrix4.CreatePerspectiveFieldOfView((float)MathHelper.DegreesToRadians(90), (float)CoreEngine.Width / (float)CoreEngine.Height, 0.3f, 1000f));
            basicShader = new BasicShader();
        }

        public void Render(GameObject gameObject) {
            GraphicsUtil.ClearScreen();
            GL.Viewport(CoreEngine.window.ClientRectangle);
            gameObject.Render(basicShader);
        }

        public Camera MainCamera {
            get { return mainCamera; }
            set { mainCamera = value; }
        }
    }
}
