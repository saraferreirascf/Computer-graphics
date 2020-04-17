using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public static GameObject SpotlightGameObject;
    public static GameObject DirectionallightGameObject;


        // Add the light component
    public static Light SpotlightComp;
    public static Light DirectionallightComp;

    // Start is called before the first frame update
    void Start()
    {
        
        SpotlightGameObject= new GameObject("Spot Light");
        SpotlightComp= SpotlightGameObject.AddComponent<Light>();
        // Set color and position
        SpotlightComp.color = Color.yellow;
        SpotlightComp.type = LightType.Spot;

        // Set the position (or any transform property)
        SpotlightGameObject.transform.position = new Vector3(0, 5, 0);

        DirectionallightGameObject= new GameObject("Directional Light");
        DirectionallightComp= DirectionallightGameObject.AddComponent<Light>();
        DirectionallightComp.type = LightType.Directional;
        DirectionallightComp.color = Color.blue;

        //ambient light
        RenderSettings.ambientLight = Color.yellow;

    }

    // Update is called once per frame

    void Update()
    {
        //Move spotlight
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 position = SpotlightGameObject.transform.position;
            position.x--;
            SpotlightGameObject.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 position = SpotlightGameObject.transform.position;
            position.y++;
            SpotlightGameObject.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 position = SpotlightGameObject.transform.position;
            position.y--;
            SpotlightGameObject.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 position = SpotlightGameObject.transform.position;
            position.x++;
            SpotlightGameObject.transform.position = position;
        }

        //Move directional light
         if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 position = DirectionallightGameObject.transform.position;
            position.x--;
            DirectionallightGameObject.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector3 position = DirectionallightGameObject.transform.position;
            position.y++;
            DirectionallightGameObject.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 position = DirectionallightGameObject.transform.position;
            position.y--;
            DirectionallightGameObject.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 position = DirectionallightGameObject.transform.position;
            position.x++;
            DirectionallightGameObject.transform.position = position;
        }
    }
}
