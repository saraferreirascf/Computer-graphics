using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBJ_Reader
{
    public struct Vertex
    {
        public float    x;
        public float    y;
        public float    z;
        public int      index;
    }

    public struct VTexture
    {
        public float    u;
        public float    v;
        public int      index;
    }

    public struct VNormal
    {
        public float    x;
        public float    y;
        public float    z;
        public int      index;
    }

    public struct Faces
    {
        // TODO: this will need to be redefined
        public int   v;
        public int  vt;
        public int  vn;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Vertex vert;
            VTexture vt;
            VNormal vn;
            Faces face;
            int vertexCount = 0, vTextureCount = 0, vNormalCount = 0; // might not be needed
            String[] lines = System.IO.File.ReadAllLines(@"C:\Users\Nikkya\Downloads\cg_sphere.obj");
            String[] splittedLine, splittedLineFaces;
            var vertices = new List<Vertex>();
            var textures = new List<VTexture>();
            var normals = new List<VNormal>();

            foreach(String line in lines)
            {
                splittedLine = line.Split(' ');
                if (splittedLine[0].Equals("v") && splittedLine.Length == 4)
                {
                    vertexCount++;
                    vert.x = float.Parse(splittedLine[1].Replace(".",","));
                    vert.y = float.Parse(splittedLine[2].Replace(".", ","));
                    vert.z = float.Parse(splittedLine[3].Replace(".", ","));
                    vert.index = vertexCount;
                    vertices.Add(vert);
                    //Console.WriteLine("Added vertex index {0}: x {1} - y {2} - z{3}",vert.index, vert.x, vert.y, vert.z);
                }
                if (splittedLine[0].Equals("vt"))
                {
                    vTextureCount++;
                    vt.u = float.Parse(splittedLine[1].Replace(".", ","));
                    vt.v = float.Parse(splittedLine[2].Replace(".", ","));
                    vt.index = vTextureCount;
                    textures.Add(vt);
                    //Console.WriteLine("Added texture index {0}: u {1} - v {2}", vt.index, vt.u, vt.v);
                }
                if (splittedLine[0].Equals("vn"))
                {
                    vNormalCount++;
                    vn.x = float.Parse(splittedLine[1].Replace(".", ","));
                    vn.y = float.Parse(splittedLine[2].Replace(".", ","));
                    vn.z = float.Parse(splittedLine[3].Replace(".", ","));
                    vn.index = vNormalCount;
                    normals.Add(vn);
                    //Console.WriteLine("Added normal index {0}: x {1} - y {2} - z{3}", vn.index, vn.x, vn.y, vn.z);
                }
                if (splittedLine[0].Equals("f"))
                {
                    // TODO: figure this out
                }
            }
            Console.ReadLine();
        }

    }
}
