using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Camera gameCamera;


    public Vector2 teleportPosition;



    public float waitTime = 3f;

    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        teleportPosition = gameCamera.ScreenToWorldPoint(new Vector2(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height)));
        
        
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if(timer > waitTime)
        {
            

            transform.position = teleportPosition;

            teleportPosition = gameCamera.ScreenToWorldPoint(new Vector2(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height)));

            timer = 0f;


        }

        
    }
}
