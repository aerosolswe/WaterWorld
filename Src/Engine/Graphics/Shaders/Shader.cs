using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace WaterWorld.Engine {
    class Shader {
        private Dictionary<string, int> uniforms = new Dictionary<string, int>();

        private int program;

        public Shader() {
            program = GL.CreateProgram();

            if(program == 0) {
                Console.WriteLine("Error while creating shader program; Exiting");
                Environment.Exit(1);
            }

            //string vs = System.IO.File.ReadAllText(vsPath);
            //string fs = System.IO.File.ReadAllText(fsPath);


        }

        public void Bind() {
            GL.UseProgram(program);
        }

        public void AddUniform(string name) {
            int uniformLocation = GL.GetUniformLocation(program, name);

            if(uniformLocation == -1) {
                Console.WriteLine("Error: Could not find uniform: " + name);
                Environment.Exit(1);
            }

            uniforms.Add(name, uniformLocation);
        }

        public void Uniformi(string name, int value) {
            GL.Uniform1(uniforms[name], 1, ref value);
        }

        public void Uniformf(string name, float value) {
            GL.Uniform1(uniforms[name], 1, ref value);
        }

        public void Uniform(string name, Vector2 value) {
            GL.Uniform2(uniforms[name], ref value);
        }

        public void Uniform(string name, Vector3 value) {
            GL.Uniform3(uniforms[name], ref value);
        }

        public void Uniform(string name, Matrix4 value) {
            GL.UniformMatrix4(uniforms[name], false, ref value);
        }

        public void CompileShader() {
            GL.LinkProgram(program);

            GL.ValidateProgram(program);
        }

        public void AddProgram(string text, ShaderType type) {
            int shader = GL.CreateShader(type);

            if(shader == 0) {
                Console.WriteLine("Error while creating shader; Exiting");
                Environment.Exit(1);
            }

            GL.ShaderSource(shader, text);
            GL.CompileShader(shader);

            int status;
            string info;
            GL.GetShaderInfoLog(shader, out info);
            GL.GetShader(shader, ShaderParameter.CompileStatus, out status);

            if(status != 1) {
                Console.WriteLine("Failed to Compile Fragment Shader Source." +
                        Environment.NewLine + info + Environment.NewLine + "Status Code: " + status.ToString());

                GL.DeleteShader(shader);
                GL.DeleteProgram(program);
                program = 0;
            }

            GL.AttachShader(program, shader);
        }

        public void AddVertexShader(string text) {
            AddProgram(text, ShaderType.VertexShader);
        }

        public void AddFragmentShader(string text) {
            AddProgram(text, ShaderType.FragmentShader);
        }

        public void AddGeometryShader(string text) {
            AddProgram(text, ShaderType.GeometryShader);
        }
    }
}
