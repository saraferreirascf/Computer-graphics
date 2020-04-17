using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBJ_Reader
{
    public struct Vertex
    {
        public float x;
        public float y;
        public float z;
        public int index;
    }

    public struct VTexture
    {
        public float u;
        public float v;
        public int index;
    }

    public struct VNormal
    {
        public float x;
        public float y;
        public float z;
        public int index;
    }

    public struct Point
    {
        public Vertex v;
        public VTexture vt;
        public VNormal vn;
    }

    public struct Faces
    {
        public Point p1;
        public Point p2;
        public Point p3;
        public Point p4;
        public int index;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Vertex vert;
            VTexture vt;
            VNormal vn;
            Faces face;
            Point p1;
            Point p2;
            Point p3;
            Point p4;

            int vertexCount = 0, vTextureCount = 0, vNormalCount = 0, FacesCount = 0;// might not be needed
            String[] lines = System.IO.File.ReadAllLines(@"/Users/saraferreira/Documents/Faculdade/Semestre2/CG/test_cube.obj");
            String[] splittedLine, splittedLineFaces;
            var vertices = new List<Vertex>();
            var textures = new List<VTexture>();
            var normals = new List<VNormal>();
            var faces = new List<Faces>();

            foreach (String line in lines)
            {
                splittedLine = line.Split(' ');

                if (splittedLine[0].Equals("v") && splittedLine.Length == 4)
                {
                    vertexCount++;
                    vert.x = float.Parse(splittedLine[1].Replace(".", ","));
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

                    FacesCount++;
                    Console.WriteLine(line);
                    Console.WriteLine(splittedLine.Length);


                    String[] points = splittedLine[1].Split('/');

                    p1.v = vertices[int.Parse(points[0]) - 1];
                    p1.vt = textures[int.Parse(points[1]) - 1];
                    p1.vn = normals[int.Parse(points[2]) - 1];

                    points = splittedLine[2].Split('/');
                    p2.v = vertices[int.Parse(points[0]) - 1];
                    p2.vt = textures[int.Parse(points[1]) - 1];
                    p2.vn = normals[int.Parse(points[2]) - 1];

                    points = splittedLine[3].Split('/');
                    p3.v = vertices[int.Parse(points[0]) - 1];
                    p3.vt = textures[int.Parse(points[1]) - 1];
                    p3.vn = normals[int.Parse(points[2]) - 1];

                    if (splittedLine.Length == 5)
                    {
                        Console.WriteLine("Tenho 4");
                        points = splittedLine[4].Split('/');
                        p4.v = vertices[int.Parse(points[0]) - 1];
                        p4.vt = textures[int.Parse(points[1]) - 1];
                        p4.vn = normals[int.Parse(points[2]) - 1];

                    }

                    else //so tem 3 ou 4 pontos
                    {
                        var verticesNull = new Vertex();
                        var texturesNull = new VTexture();
                        var normalsNull = new VNormal();
                        verticesNull.x = 0.0f;
                        verticesNull.z = 0.0f;
                        verticesNull.z = 0.0f;
                        verticesNull.index = 0;
                        /******/
                        texturesNull.u = 0.0f;
                        texturesNull.v = 0.0f;
                        texturesNull.index = 0;
                        /******/
                        normalsNull.x = 0.0f;
                        normalsNull.z = 0.0f;
                        normalsNull.z = 0.0f;
                        normalsNull.index = 0;
                        p4.v = verticesNull;
                        p4.vt = texturesNull;
                        p4.vn = normalsNull;
                    }

                    face.p1 = p1;
                    face.p2 = p2;
                    face.p3 = p3;
                    face.p4 = p4;
                    face.index = FacesCount;

                    faces.Add(face);
                    Console.WriteLine("Added face index {0}", face.index);



                }
            }
            Console.WriteLine("Acabei de inserir tudo");

            Console.ReadLine();
        }

    }
}