using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRobot : MonoBehaviour
{
    public GameObject character;
    public Vector3 velocity;
    public int playerSpeed;
    private float forwardsComponent;
    private float horizontalComponent;


    // Update is called once per frame
    void Update()
    {
        /* Obsolete Movement Controls:
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(playerSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, -(playerSpeed));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(-(playerSpeed), 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, playerSpeed);
        }
        */

        //Move Robot in Strict Planes:
        forwardsComponent = -(Input.GetAxis("Vertical")) * playerSpeed;
        horizontalComponent = -(Input.GetAxis("Horizontal")) * playerSpeed;
        forwardsComponent *= Time.deltaTime;
        horizontalComponent *= Time.deltaTime;
        transform.Translate(horizontalComponent, 0, forwardsComponent);

        //Rotating Character on Axis:
        if (Input.GetKey(KeyCode.Q))
        {
            transform.RotateAround(character.transform.position, Vector3.down, 50 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.RotateAround(character.transform.position, Vector3.up, 50 * Time.deltaTime);
        }
    }
}
