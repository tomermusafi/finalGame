using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 0.15f;
    float rx = 0f, ry;
    private float angularSpeed = 15f;
    public GameObject playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float dx, dz;

        rx -= Input.GetAxis("Mouse Y") * angularSpeed; // vertical rotation
        playerCamera.transform.localEulerAngles = new Vector3(rx, 0, 0);
        ry = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * angularSpeed; // horizontal rotation
        transform.localEulerAngles = new Vector3(0, ry, 0); // sets new orientation of player

        //keyboard
        dx = Input.GetAxis("Horizontal") * speed; // Horizontal means 'A' or 'D'
        dz = Input.GetAxis("Vertical") * speed; // Vertical means 'W' or 'S'
        Vector3 motion = new Vector3(dx, -1, dz);

        motion = transform.TransformDirection(motion);// in Global coordinates
        controller.Move(motion);
    }
}
