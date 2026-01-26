using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class NewDestination : MonoBehaviour
{

    //Declaring public variables for the animation curve as well as the game camera
    public Camera gameCamera;
    public AnimationCurve aniCurve;


    //Declaring variables related to the position of objects within the scene
    public Vector2 teleportPosition;
    Vector2 defaultPosition;
    float distance;

    //Declaring variables related to time
    public float delay;
    public float waitTime;
    public float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Sets the default position to the objects placment within the scene
        defaultPosition = transform.position;

        //Generates a random position on the bottom half of the screen
        //Stores the position within the teleportPosition variable
        teleportPosition = gameCamera.ScreenToWorldPoint(new Vector2(Random.Range(0f, Screen.width), Random.Range((float)(Screen.height /2), 0f)));


    }

    // Update is called once per frame
    void Update()
    {

        //Store the converted value from screenToWorldPoint of the mouses' current position
        //Then calculate the distance between the mouse position and this objects current transform.position
        Vector2 mousePosition = gameCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        distance = Vector2.Distance(mousePosition, transform.position);

        //If that distance is less than 0.5f (i.e the mouse is over the object). Then the teleport position of the object becomes the mouses current position
        //Then the timer is set to 1f, this gives the illusion of the mouse having caught the object
        if (distance < 0.5f)
        {

            teleportPosition = gameCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            timer = 1f;

            
        }


        //Increment the timer by Time.delta time, modified by a delay
        //This delay value is public and different for every object, determining how fast that object move's through it's animation curve
        timer += Time.deltaTime * delay;

        

        //If the timer becomes greater than the waitTime value
        //Then a new teleport position is generated and stored in the teleportPosition variable
        //Then the timer is set to 0f, to restart the timer and have it move to its new position
        if (timer > waitTime)
        {

            teleportPosition = gameCamera.ScreenToWorldPoint(new Vector2(Random.Range(0f, Screen.width), Random.Range((float)(Screen.height / 2), 0f)));

            timer = 0f;

        }

    
       //Here the object uses the vector2.Lerp function to lerp the object from its default position to the teleport position
       //This lerp is modified by an animationCurve on the object
       transform.position = Vector2.Lerp(defaultPosition, teleportPosition, aniCurve.Evaluate(timer));

    
        

        


    }
}
