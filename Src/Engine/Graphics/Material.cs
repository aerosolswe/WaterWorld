using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterWorld.Engine {
    class Material {
        private Texture diffuse;

        public Material(Texture diffuse) {
            this.diffuse = diffuse;
        }

        public Texture Diffuse {
            get { return diffuse; }
            set { diffuse = value; }
        }
    }
}
