using UnityEngine;
using UnityEngine.InputSystem;

public class MouseCheck : MonoBehaviour
{

    
    //Declaring a public Camera variable
    public Camera gameCamera;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

        //This scripts sole purpose is to have an object follow the mouse

        //Here we store the mouses current position, converted from ScreenToWorldPoint
        Vector2 mousePosition = gameCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());


        //Then we make the transform.position object equal the mousePosition
        transform.position = mousePosition;

        


        
    }
}
