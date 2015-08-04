using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace WaterWorld.Engine {
    class Texture {
        private static TextureUnit ActiveSampler = TextureUnit.Texture0;
        private static int ActiveID = 0;

        private int id;

        public Texture() {
            id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);
        }

        public void InitGL() {
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        }

        public void Bind(TextureUnit sampler) {
            if(ActiveSampler != sampler) {
                GL.ActiveTexture(sampler);
                ActiveSampler = sampler;
            }

            if(ActiveID != id) {
                GL.BindTexture(TextureTarget.Texture2D, id);
                ActiveID = id;
            }
        }

        public int ID {
            get { return id; }
        }
    }
}
