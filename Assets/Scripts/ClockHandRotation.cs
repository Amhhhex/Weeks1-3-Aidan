using UnityEngine;

public class ClockHandRotation : MonoBehaviour

{
    public float rotationSpeed;

    Vector3 rotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotation = transform.eulerAngles;


    }

    // Update is called once per frame
    void Update()
    {



        rotation.z += rotationSpeed * Time.deltaTime;

        transform.RotateAround(new Vector3(0f, 0f, 0f), transform.forward, rotation.z);


    }
}
