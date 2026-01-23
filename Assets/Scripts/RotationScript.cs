using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public float rotationSpeed = 1f;

    public float zMin;
    public float zMax;

    public Camera gameCamera;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Rotating in a direction and chaning directions at certain angles

        //transform.rotation uses a type called quanterions that can be initially confusing
        //For now we are using eulerAngles, to easily modify the roations of objects
        //This results in wierd quirks, for instance within the inspector, the Z axis will only go from 180 to -180
        //but when debug logging the eulerAngles, the values go from 0 to 360
        //also key to note, that when increasing 360, it will loop around to 0, so to have it turn around when it's 360 make sure to do >= or <=

        //Vector3 rotation = transform.eulerAngles;


        //if(rotation.z < zMin)
        //{
        //    rotationSpeed *= -1f;
        //}

        //if (rotation.z > zMax)
        //{
        //    rotationSpeed *= -1f;
        //}


        //rotation.z += rotationSpeed * Time.deltaTime;

        //transform.eulerAngles = rotation;


        Vector3 currentMousePosition = Mouse.current.position.ReadValue();

        Vector3 worldMousePosition = gameCamera.ScreenToWorldPoint(currentMousePosition);

        worldMousePosition.z = 0;

        //Setting the direction we;re looking in to get the direction we do end - start

        transform.up = worldMousePosition - transform.position;

        transform.position += transform.up * 1f * Time.deltaTime;
        
    }
}
