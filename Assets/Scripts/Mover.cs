using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class Mover : MonoBehaviour
{

    public Camera gameCamera;

    public float speed = 0.05f;
    public float xMax = 10f;
    public float xMin = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moverPosition = gameCamera.WorldToScreenPoint(transform.position);


        print(Screen.width);


        if (moverPosition.x > Screen.width) {

            speed *= -1;
        
        }

        if(moverPosition.x < Screen.width - Screen.width) {

            speed *= -1; 
        }

        Vector3 moverXPos = transform.position;
        moverXPos.x = moverXPos.x + speed;
        transform.position = moverXPos;


    }
}
