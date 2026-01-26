using UnityEngine;
using UnityEngine.InputSystem;

public class MouseCheck : MonoBehaviour
{

    public bool objectCaught;

    public Camera gameCamera;

    public float distance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePosition = gameCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());


        transform.position = mousePosition;

        


        
    }
}
