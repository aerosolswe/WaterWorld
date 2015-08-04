using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace WaterWorld.Engine {
    class Mesh {
        private int vao;

        private int vbo;
        private int tcbo;
        private int nbo;
        private int ibo;
        private int size = 0;

        private Vector3[] positions = new Vector3[0];
        private Vector2[] texCoords = new Vector2[0];
        private Vector3[] normals = new Vector3[0];
        private int[] indices = new int[0];

        public Mesh() {
            vbo = GL.GenBuffer();
            tcbo = GL.GenBuffer();
            nbo = GL.GenBuffer();
            ibo = GL.GenBuffer();
            vao = GL.GenVertexArray();
        }

        public void AddVertices(Vector3[] positions, Vector2[] texCoords, Vector3[] normals, int[] indices) {
            size = +indices.Length;

            Vector3[] newArray = new Vector3[this.positions.Length + positions.Length];
            Array.Copy(this.positions, newArray, 0);
            Array.Copy(positions, 0, newArray, this.positions.Length, positions.Length);
            this.positions = newArray;

            Vector2[] newArray0 = new Vector2[this.texCoords.Length + texCoords.Length];
            Array.Copy(this.texCoords, newArray0, 0);
            Array.Copy(texCoords, 0, newArray0, this.texCoords.Length, texCoords.Length);
            this.texCoords = newArray0;

            Vector3[] newArray1 = new Vector3[this.normals.Length + normals.Length];
            Array.Copy(this.normals, newArray1, 0);
            Array.Copy(normals, 0, newArray1, this.normals.Length, normals.Length);
            this.normals = newArray1;

            int[] newArray2 = new int[this.indices.Length + indices.Length];
            Array.Copy(this.indices, newArray2, 0);
            Array.Copy(indices, 0, newArray2, this.indices.Length, indices.Length);
            this.indices = newArray2;

        }

        public void Complete() {
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, new IntPtr(positions.Length * Vector3.SizeInBytes), positions, BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ArrayBuffer, tcbo);
            GL.BufferData<Vector2>(BufferTarget.ArrayBuffer, new IntPtr(texCoords.Length * Vector2.SizeInBytes), texCoords, BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ArrayBuffer, nbo);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, new IntPtr(normals.Length * Vector3.SizeInBytes), normals, BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ibo);
            GL.BufferData(BufferTarget.ElementArrayBuffer, new IntPtr(sizeof(uint) * indices.Length), indices, BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

            GL.BindVertexArray(vao);

            GL.EnableVertexAttribArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, true, Vector3.SizeInBytes, 0);

            GL.EnableVertexAttribArray(1);
            GL.BindBuffer(BufferTarget.ArrayBuffer, tcbo);
            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, true, Vector2.SizeInBytes, 0);

            GL.EnableVertexAttribArray(2);
            GL.BindBuffer(BufferTarget.ArrayBuffer, nbo);
            GL.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, true, Vector3.SizeInBytes, 0);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ibo);

            GL.BindVertexArray(0);
        }

        public void Draw() {
            GL.BindVertexArray(vao);
            GL.DrawElements(PrimitiveType.Triangles, size, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }
    }
}
