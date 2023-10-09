using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] FixedJoystick fixedJoystick;
    [SerializeField] float speed;
    Rigidbody rigidbodyPlayer;

    private void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        JoystickMovement();
    }
    void JoystickMovement()
    {
        if (fixedJoystick.Horizontal != 0 || fixedJoystick.Vertical != 0)
        {
            rigidbodyPlayer.velocity = new Vector3(fixedJoystick.Horizontal, rigidbodyPlayer.velocity.y, fixedJoystick.Vertical).normalized * Time.deltaTime * speed;
            Quaternion lookRot = Quaternion.LookRotation(rigidbodyPlayer.velocity);
            lookRot.x = 0;
            lookRot.z = 0;
            transform.rotation = lookRot;
        }
    }
}
