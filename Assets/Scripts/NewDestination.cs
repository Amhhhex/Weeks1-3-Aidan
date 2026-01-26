using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class NewDestination : MonoBehaviour
{
    public Camera gameCamera;

    public AnimationCurve aniCurve;



    public Vector2 teleportPosition;

    Vector2 defaultPosition;

    float distance;

    public float delay;


    public float waitTime = 8f;

    public float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        defaultPosition = transform.position;

        //transform.position = new Vector2(0f, 0f);

        //defaultPosition = transform.position;

        teleportPosition = gameCamera.ScreenToWorldPoint(new Vector2(Random.Range(0f, Screen.width), Random.Range((float)(Screen.height /2), 0f)));


    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePosition = gameCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());


        distance = Vector2.Distance(mousePosition, transform.position);

        if (distance < 0.5f)
        {

            //timer = aniCurve.keys[2].value;


            teleportPosition = gameCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            timer = 1f;

            //timer = 0f;
        }


        timer += Time.deltaTime * delay;

        

        if (timer > waitTime)
        {


            //transform.position = teleportPosition;

            teleportPosition = gameCamera.ScreenToWorldPoint(new Vector2(Random.Range(0f, Screen.width), Random.Range((float)(Screen.height / 2), 0f)));

            //transform.position = defaultPosition;

            timer = 0f;


        }


        

    
       transform.position = Vector2.Lerp(defaultPosition, teleportPosition, aniCurve.Evaluate(timer));

    
        

        


    }
}
