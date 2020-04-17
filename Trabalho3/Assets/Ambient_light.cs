using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambient_light : MonoBehaviour
{
    public TextMesh LightTrackingStatus;
    // Start is called before the first frame update
    void Start()
    {
       
         // Make the ambient lighting red
       // RenderSettings.ambientSkyColor = new Color32(255, 0, 0, 0);
        // RenderSettings.ambientLight = new Color32(255, 0, 0, 0);
        RenderSettings.ambientLight = Color.black;
    }

    // Update is called once per frame
    // Se nao puser nada no update nao vou conseguir ver nada.
    void Update()
    {
         LightTrackingStatus.text = "";
 
       
    }
}
