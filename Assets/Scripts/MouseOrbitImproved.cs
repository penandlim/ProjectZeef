using UnityEngine;
using System.Collections;

public class MouseOrbitImproved : MonoBehaviour
{
    //Variables
    public float normalSpeed = 10.0f;
    public float speed = 10.0F;
    private float maxSpeed = 50.0f;
    public int xMovement = 0;
    public int yMovement = 0;
    private Vector3 moveDirection = Vector3.zero;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        // is the controller on the ground?
        //Feed moveDirection with input.
        if (Input.GetKey(KeyCode.D))
        {
            xMovement = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            xMovement = -1;
        }
        else
        {
            xMovement = 0;
        }
        if (Input.GetKey(KeyCode.W))
        {
            yMovement = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            yMovement = -1;
        }
        else
        {
            yMovement = 0;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = maxSpeed;
        }
        else
        {
            speed = normalSpeed;
        }
        moveDirection = new Vector3(xMovement, 0, yMovement);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = moveDirection * speed * Time.smoothDeltaTime;
        moveDirection.y = 0;
        //Making the character move
        controller.Move(moveDirection);
        transform.Rotate(

                -Input.GetAxis("Mouse Y") * 200.0f * Time.smoothDeltaTime,
                Input.GetAxis("Mouse X") * 200.0f * Time.smoothDeltaTime,
                0
        );
        transform.rotation = Quaternion.Euler(
            transform.rotation.eulerAngles.x,
            transform.rotation.eulerAngles.y,
            0);
    }
}