using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace WaterWorld.Engine {
    class MeshRenderer : GameComponent {
        private Mesh mesh;
        private Material material;

        public MeshRenderer(Mesh mesh, Material material) {
            this.mesh = mesh;
            this.material = material;
        }

        public override void Render(Shader shader) {
            base.Render(shader);

            shader.Bind();
            material.Diffuse.Bind(TextureUnit.Texture0);
            shader.Uniformi("diffuse", 0);
            shader.Uniform("MVP", Matrix4.Mult(Transform.Model, CoreEngine.graphicsEngine.MainCamera.VP));
            mesh.Draw();
        }
    }
}
