using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triangle : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;

    int[] triangles;
    

    void Start () {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        mesh = new Mesh();
        mesh.Clear();
        GetComponent<MeshFilter>().mesh = mesh;    
        SplitMesh(mesh);
        SetColors(mesh);
    }

    void SplitMesh(Mesh mesh){
        vertices= new[]{
            new Vector3(0,0,0),
            new Vector3(0,3,0),
            new Vector3(3,0,0),
            new Vector3(-1,0,0),
            new Vector3(0,-3,0),
            new Vector3(-3,0,0)
        };

        triangles=new[]{0,1,2,3,4,5};

        mesh.vertices = vertices;
        mesh.triangles = triangles;
     
    }   
    void SetColors(Mesh mesh){
        // create new colors array where the colors will be created.
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