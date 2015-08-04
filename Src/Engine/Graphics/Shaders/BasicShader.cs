using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterWorld.Engine {
    class BasicShader : Shader {

        public BasicShader() {
            AddVertexShader(System.IO.File.ReadAllText("Content/Shaders/basic.vs"));
            AddFragmentShader(System.IO.File.ReadAllText("Content/Shaders/basic.fs"));

            CompileShader();

            AddUniform("MVP");
            AddUniform("diffuse");
        }
    }
}
