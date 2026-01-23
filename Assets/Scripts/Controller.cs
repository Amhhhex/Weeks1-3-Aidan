using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{

    public Vector2 movement = new Vector2(0f, 0f);

    public float rotationSpeed;
    public float moveSpeed;

    public SpriteRenderer spriteRenderer;

    public Color startingColour = Color.red;

    public List<SpriteRenderer> controllableRenderers;

    public List<Transform> controlledTransforms;

    public Camera gameCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        spriteRenderer.color = startingColour;
        bool isInsideSprite = spriteRenderer.bounds.Contains(transform.position);

        controlledTransforms.Add(transform);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentMousePosition = Mouse.current.position.ReadValue();

        Vector3 worldMousePosition = gameCamera.ScreenToWorldPoint(currentMousePosition);

        worldMousePosition.z = 0;

        bool isHovered;

        bool isLeftMousePressed = Mouse.current.leftButton.wasPressedThisFrame;
        if (isLeftMousePressed)
        {
            for (int i = 0; i < controllableRenderers.Count; i++)
            {

                isHovered = controllableRenderers[i].bounds.Contains(worldMousePosition);

                 

                if (isHovered)
                {
                    controlledTransforms.Add(controllableRenderers[i].transform);
                }
            }
        }

        for (int i = 0; i < controlledTransforms.Count; i++)
        {

            Transform currentTransform = controlledTransforms[i];

            bool upArrowIsHeld = Keyboard.current.upArrowKey.isPressed;

            if (upArrowIsHeld)
            {

                currentTransform.position += transform.up * moveSpeed * Time.deltaTime;
            }

            bool downArrowIsHeld = Keyboard.current.downArrowKey.isPressed;

            if (downArrowIsHeld)
            {
                currentTransform.position -= transform.up * moveSpeed * Time.deltaTime;
            }

            bool leftArrowIsHeld = Keyboard.current.leftArrowKey.isPressed;

            if (leftArrowIsHeld)
            {

                currentTransform.eulerAngles += transform.forward * rotationSpeed * Time.deltaTime;

            }

            bool rightArrowIsHeld = Keyboard.current.rightArrowKey.isPressed;



            if (rightArrowIsHeld)
            {
                currentTransform.eulerAngles -= transform.forward * rotationSpeed * Time.deltaTime;
            }

        }
        /*

        bool leftIsHeld = Mouse.current.leftButton.isPressed;
        if (leftIsHeld)
        {
            Debug.Log("Left mouse is held");
        }

        bool leftIsPressed = Mouse.current.leftButton.wasPressedThisFrame;
        if (leftIsPressed)
        {
            Debug.Log("Left mouse is pressed.");
        }

        bool leftIsReleased = Mouse.current.leftButton.wasReleasedThisFrame;
        if (leftIsReleased)
        {
            Debug.Log("Left mouse is released.");
        }

        */

        // bool upArrowIsHeld = Keyboard.current.upArrowKey.isPressed;

        //if(upArrowIsHeld)
        // {

        //     transform.position += transform.up * moveSpeed * Time.deltaTime;
        // }

        //bool downArrowIsHeld = Keyboard.current.downArrowKey.isPressed;

        // if(downArrowIsHeld)
        // {
        //     transform.position -= transform.up * moveSpeed * Time.deltaTime;
        // }

        //bool leftArrowIsHeld = Keyboard.current.leftArrowKey.isPressed;

        // if(leftArrowIsHeld)
        // {

        //     transform.eulerAngles += transform.forward * rotationSpeed * Time.deltaTime;

        // }

        // bool rightArrowIsHeld = Keyboard.current.rightArrowKey.isPressed;



        // if(rightArrowIsHeld)
        // {
        //     transform.eulerAngles -= transform.forward * rotationSpeed * Time.deltaTime;
        // }



    }
}
