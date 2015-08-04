using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace WaterWorld.Engine {
    class Camera : GameComponent {
        private Matrix4 projection;

        public Camera(Matrix4 projection) {
            this.projection = projection;
        }

        public Matrix4 Projection {
            get { return projection; }
            set { projection = value; }
        }

        public Matrix4 VP {
            get {
                Matrix4 result = new Matrix4();
                Matrix4 v = Transform.Model;
                Matrix4 p = projection;

                Matrix4.Mult(ref v, ref p, out result);

                return result;
            }
        }

        public override void AddToEngine() {
            base.AddToEngine();
            CoreEngine.graphicsEngine.MainCamera = this;
        }
    }
}
