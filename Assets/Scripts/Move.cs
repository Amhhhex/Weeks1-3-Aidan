
using UnityEngine;

public class Move : MonoBehaviour
{

    public Vector2 circlePosition;
    public float speedX = 0.01f;
    public float speedY = 0.05f;

    public Vector3 screenPosition;

    public Camera gameCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        circlePosition = transform.position;

        circlePosition.x += speedX;
        circlePosition.y += speedY;

        transform.position = circlePosition;

        screenPosition = gameCamera.WorldToScreenPoint(transform.position);

        if (screenPosition.x >= Screen.width)
        {
            speedX *= -1f;
        }

        if (screenPosition.x <= 0)
        {

            speedX *= -1f;
        }

        if (screenPosition.y >= Screen.height)
        {
            speedY *= -1f;
        }

        if (screenPosition.y <= 0)
        {
            speedY *= -1f;
        }

    }
}
