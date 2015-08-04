using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenTK;
using Assimp;

namespace WaterWorld.Engine {
    class ModelLoader {
        public static Mesh LoadModel(string filename) {
            Mesh mesh = new Mesh();

            AssimpImporter importer = new AssimpImporter();

            if(!importer.IsImportFormatSupported(Path.GetExtension(filename))) {
                throw new ArgumentException("Model format " + Path.GetExtension(filename) + " is not supported!  Cannot load {1}", "filename");
            }

            var min = new Vector3(float.MaxValue);
            var max = new Vector3(float.MinValue);

            Scene model = importer.ImportFile(filename, PostProcessPreset.TargetRealTimeFast);

            for(int j = 0; j < model.MeshCount; j++) {
                Assimp.Mesh m = model.Meshes[j];

                Vector3[] positions = new Vector3[m.VertexCount];
                Vector2[] textureCoords = new Vector2[m.VertexCount];
                Vector3[] normals = new Vector3[m.VertexCount];
                Vector3[] tangents = new Vector3[m.VertexCount];

                for(var i = 0; i < m.VertexCount; i++) {
                    Vector3 pos = m.HasVertices ? Util.ToVector3(m.Vertices[i]) : new Vector3();
                    Vector3 t = m.HasTextureCoords(0) ? Util.ToVector3(m.GetTextureCoords(0)[i]) : new Vector3();
                    Vector3 normal = m.HasNormals ? Util.ToVector3(m.Normals[i]) : new Vector3();
                    Vector3 tangent = m.HasTangentBasis ? Util.ToVector3(m.Tangents[i]) : new Vector3();

                    min = Vector3.Min(min, pos);
                    max = Vector3.Max(max, pos);

                    positions[i] = pos;
                    textureCoords[i] = new Vector2(t.X, -t.Y);
                    normals[i] = normal;
                    tangents[i] = tangent;
                }

                int[] indices = m.GetIntIndices();

                mesh.AddVertices(positions, textureCoords, normals, indices);
            }

            mesh.Complete();

            return mesh;
        }
    }
}
