using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot_light : MonoBehaviour
{
    public static GameObject SpotlightGameObject;
    public static GameObject DirectionallightGameObject;
    public static GameObject PointlightGameObject; //ambient???


        // Add the light component
    public static Light SpotlightComp;
    public static Light DirectionallightComp;
    public static Light PointlightComp;

    // Start is called before the first frame update
    void Start()
    {
        // Make a game object
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

    }

    // Update is called once per frame

    //Falta por a mexer a direcional, secalhar cm w,d,a,s...
    void Update()
    {
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
    }
}
