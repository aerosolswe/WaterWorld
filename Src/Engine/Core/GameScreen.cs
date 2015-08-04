using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterWorld.Engine {
    class GameScreen {
        private GameObject root;

        public virtual void Awake() {
        }

        public virtual void Input() {
            Root.Input();
        }

        public virtual void FixedUpdate() {
            Root.FixedUpdate();
        }

        public virtual void Update() {
            Root.Update();
        }

        public virtual void Render(GraphicsEngine graphicsEngine) {
            graphicsEngine.Render(Root);
        }

        public virtual void Resize() {
            Root.Resize();
        }

        public virtual void Dispose() {
            Root.Dispose();
        }

        public GameObject Root {
            get {
                if(root == null) {
                    root = new GameObject();
                }

                return root;
            }
        }
    }
}
