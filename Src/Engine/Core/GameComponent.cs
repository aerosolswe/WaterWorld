using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterWorld.Engine {
    class GameComponent {
        private GameObject parent;

        public virtual void Input() { }
        public virtual void FixedUpdate() { }
        public virtual void Update() { }
        public virtual void Render(Shader shader) { }
        public virtual void Resize() { }
        public virtual void Dispose() { }
        public virtual void AddToEngine() { }

        public GameObject Parent {
            get { return  parent; }
            set { parent = value; }
        }

        public Transform Transform {
            get { return Parent.Transform; }
        }
    }
}
