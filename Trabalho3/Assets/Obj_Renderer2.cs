using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Obj_Renderer2 : MonoBehaviour
{

    // Call the Obj_Reader script
    public Obj_Reader reader;
    public Mesh mesh1;
    public Obj_Reader.ObjStruct myObj;
    public Vector3[] vertices;
    public Vector2[] textures;
    public Vector3[] normals;
    public string filepath = "./object.obj";

    public Material material;

    public Shader shader1;
    public Renderer rend;

    public Mesh InitializeMesh()
    {
        reader = new Obj_Reader();
        myObj = reader.ReadObject(filepath);

        // build the indexes to be used for the new vectors
        vertices = new Vector3[myObj.vertexList.Count];
        Obj_Reader.Vertex vHelper;
        for (var i = 0; i < myObj.vertexList.Count; i++)
        {
            vHelper = myObj.vertexList[i];
            vertices[i] = new Vector3(vHelper.x, vHelper.y, vHelper.z);
        }
        Obj_Reader.VTexture vtHelper;
        textures = new Vector2[myObj.textureList.Count];
        for (var i = 0; i < myObj.textureList.Count; i++)
        {
            vtHelper = myObj.textureList[i];
            textures[i] = new Vector2(vtHelper.u, vtHelper.v);
        }
        Obj_Reader.VNormal vnHelper;
        normals = new Vector3[myObj.normaList.Count];
        for (var i = 0; i < myObj.normaList.Count; i++)
        {
            vnHelper = myObj.normaList[i];
            normals[i] = new Vector3(vnHelper.x, vnHelper.y, vnHelper.z);
        }

        int[] triangles = new int[6 * myObj.faceList.Count];

        List<Vector3> faceData = new List<Vector3>();
        var f2 = 0;
        var f = 0;
        // lidar com os triangulos
        foreach(var face in myObj.faceList)
        {
            List<int> intArray = new List<int>();
            Vector3 block1 = new Vector3(face.p1.v.index, face.p1.vt.index, face.p1.vn.index);
            faceData.Add(block1);
            intArray.Add(f2);
            f2++;
            Vector3 block2 = new Vector3(face.p2.v.index, face.p2.vt.index, face.p2.vn.index);
            faceData.Add(block2);
            intArray.Add(f2);
            f2++;
            Vector3 block3 = new Vector3(face.p3.v.index, face.p3.vt.index, face.p3.vn.index);
            faceData.Add(block3);
            intArray.Add(f2);
            f2++;

            triangles[f] = intArray[0];
            f++;
            triangles[f] = intArray[1];
            f++;
            triangles[f] = intArray[2];
            f++;
        }


        var new_vertices = new Vector3[faceData.Count];
        var new_textures = new Vector2[faceData.Count];
        var new_normals = new Vector3[faceData.Count];
        var k = 0;
        Debug.Log(faceData.Count);
        foreach (Vector3 vec in faceData)
        {
            Debug.Log(String.Format("{0} {1} {2}",vec.x,vec.y,vec.z));
            Debug.Log((int)vec.z);
            new_vertices[k] = vertices[(int)vec.x-1];
            new_textures[k] = textures[(int)vec.y-1];
            new_normals[k]  = normals[(int)vec.z-1];
            k++;
        }


        Mesh mesh = new Mesh();
        mesh.vertices = new_vertices;
        mesh.uv = new_textures;
        mesh.normals = new_normals;
        mesh.triangles = triangles;

        return mesh;
    }


    // Start is called before the first frame update
    void Start()
    {
        Mesh myMesh = InitializeMesh();
        MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();
        MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        filter.mesh = myMesh;
        rend = GetComponent<MeshRenderer> ();
        shader1 = Shader.Find("Unlit/Phong");
        rend.material.shader = shader1;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Postprocess the image
 void OnRenderImage (RenderTexture source, RenderTexture destination)
 {
 //material.SetFloat("_bwBlend", intensity);
 Graphics.Blit (source, destination, material);
 }
}
