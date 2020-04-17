using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid : MonoBehaviour
{

    Mesh mesh;
    Vector3[] vertices;
    int[] pyramid;
    // Start is called before the first frame update
    void Start()
    {

        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        mesh = new Mesh();
        mesh.Clear();
        GetComponent<MeshFilter>().sharedMesh = mesh;
        makePyramid(mesh);
        paint(mesh);
    }

    void makePyramid(Mesh mesh)
    {
        //points - triangle 1
        Vector3 p0 = new Vector3(0, 0, 0);
        Vector3 p1 = new Vector3(2, 0, 0);
        Vector3 p2 = new Vector3(0, 0, 2);
        Vector3 p3 = new Vector3(2, 0, 2);
        Vector3 p4 = new Vector3(1, 2, 1);

        //points - triangle 2
        Vector3 p5 = new Vector3(0, 0, 0);
        Vector3 p6 = new Vector3(-2, 0, 0);
        Vector3 p7 = new Vector3(0, 0, -2);
        Vector3 p8 = new Vector3(-2, 0, -2);
        Vector3 p9 = new Vector3(-1, -2, -1);

        vertices = new Vector3[]{p0, p1, p2, p3, p4, p5, p6, p7, p8, p9};
        mesh.vertices = vertices;

        mesh.triangles = new int[]
        {
            0,2,1,
            2,3,1,
            0,4,1,
            0,4,2,
            1,4,3,
            2,4,3,
            //triangle 2
            5,7,6,
            7,8,5,
            5,9,6,
            5,9,7,
            6,9,8,
            7,9,8

        };
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.Optimize();

    }

    void paint(Mesh mesh)
    {
        Color[] colors = new Color[vertices.Length];
        Color cor1 = new Color32(255, 0, 0, 255);  // red color
        Color cor2 = new Color32(0, 255, 0, 255);  // green color
        Color cor3 = new Color32(0, 0, 255, 255);  // blue color
        for (int i = 0; i < vertices.Length; i++){
            if(i%3==0)
                colors[i]=cor1;
            else if(i%3==1)
                colors[i]=cor2;
            else if(i%3==2)
                colors[i]=cor3;
            
        }   
        mesh.colors = colors;

    }
    // Update is called once per frame
    void Update()
    {
        

    }
}