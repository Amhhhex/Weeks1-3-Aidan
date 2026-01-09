using UnityEngine;

public class Mover : MonoBehaviour
{

    public float speed = 0.01f;
    public float xMax = 10f;
    public float xMin = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        speed *= 0.001f;


        
        if (transform.position.x > xMax) {

            speed = 0.01f;
            speed *= -1;
        
        }

        if(transform.position.x < xMin) {

            speed = -0.01f;
            speed *= -1; 
        }

        Vector3 moverXPos = transform.position;
        moverXPos.x = moverXPos.x + speed;
        transform.position = moverXPos;


    }
}
