using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Obj_Reader : MonoBehaviour
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

    public struct Face
    {
        public Point p1;
        public Point p2;
        public Point p3;
        public int index;
    }

    public class ObjStruct
    {
        public List<Vertex>     vertexList;
        public List<VTexture>   textureList;
        public List<VNormal>    normaList;
        public List<Face>       faceList;

        public ObjStruct(List<Vertex> verList, List<VTexture> texList, List<VNormal> norList, List<Face> facList)
        {
            this.vertexList = verList;
            this.textureList = texList;
            this.normaList = norList;
            this.faceList = facList;
        }
    }

    
    public ObjStruct ReadObject(string FilePath)
    {
        Vertex vert;
        VTexture vt;
        VNormal vn;
        Face face;
        Point p1;
        Point p2;
        Point p3;

        int vertexCount = 0, vTextureCount = 0, vNormalCount = 0, FacesCount = 0;// might not be needed
        string[] lines = System.IO.File.ReadAllLines(FilePath);
        string[] splittedLine;
        var vertices = new List<Vertex>();
        var textures = new List<VTexture>();
        var normals = new List<VNormal>();
        var faces = new List<Face>();

        foreach (string line in lines)
        {
            splittedLine = line.Split(' ');

            if (splittedLine[0].Equals("v") && splittedLine.Length == 4)
            {
                vertexCount++;
                vert.x = float.Parse(splittedLine[1]);
                vert.y = float.Parse(splittedLine[2]);
                vert.z = float.Parse(splittedLine[3]);
                vert.index = vertexCount;
                vertices.Add(vert);
    
                //Console.WriteLine("Added vertex index {0}: x {1} - y {2} - z{3}",vert.index, vert.x, vert.y, vert.z);
            }
            if (splittedLine[0].Equals("vt"))
            {
                vTextureCount++;
                vt.u = float.Parse(splittedLine[1]);
                vt.v = float.Parse(splittedLine[2]);
                vt.index = vTextureCount;
                textures.Add(vt);
                //Console.WriteLine("Added texture index {0}: u {1} - v {2}", vt.index, vt.u, vt.v);
            }
            if (splittedLine[0].Equals("vn"))
            {
                vNormalCount++;
                vn.x = float.Parse(splittedLine[1]);
                vn.y = float.Parse(splittedLine[2]);
                vn.z = float.Parse(splittedLine[3]);
                vn.index = vNormalCount;
                normals.Add(vn);
                //Console.WriteLine("Added normal index {0}: x {1} - y {2} - z{3}", vn.index, vn.x, vn.y, vn.z);
            }
            if (splittedLine[0].Equals("f"))
            {

                FacesCount++;
                // Console.WriteLine(line);
                // Console.WriteLine(splittedLine.Length);


                string[] points = splittedLine[1].Split('/');

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

                face.p1 = p1;
                face.p2 = p2;
                face.p3 = p3;
                face.index = FacesCount;

                faces.Add(face);
                //Console.WriteLine("Added face index {0}", face.index);



            }
        }
        return new ObjStruct(vertices,textures,normals,faces);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
