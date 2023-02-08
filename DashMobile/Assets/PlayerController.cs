using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    private bool onGround = true;
    private int lane = 0;
    private int moving = 0;
    private float dashing = 0;
    private bool dashed = false;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= 5;
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //Fall
        if (!SpeedManager.gameOver)
        {
            if (Inputs.inputFall)
            {
                Inputs.inputFall = false;
                if (!onGround)
                {
                    playerRb.velocity = new Vector3(0, -30, 0);
                    dashing = 0;
                    playerRb.useGravity = true;
                    SpeedManager.boost = 1;
                }
            }


            //Jump
            if (Inputs.inputJump)
            {
                Inputs.inputJump = false;
                if (onGround)
                {
                    playerRb.velocity = new Vector3(0, 20, 0);
                    onGround = false;
                    dashing = 0;
                    playerRb.useGravity = true;
                }
                if (!onGround && dashing > 0)
                {
                    playerRb.velocity = new Vector3(0, 11, 0);
                    dashing = 0;
                    playerRb.useGravity = true;
                    SpeedManager.boost = 1.5f;
                }
            }

            //Left
            if (Inputs.inputHorizontal == 1)
            {
                Inputs.inputHorizontal = 0;
                if (lane > -1 && moving == 0 && dashing <= 0)
                {
                    lane--;
                    moving = -1;
                }
            }

            //Right
            if (Inputs.inputHorizontal == 2)
            {
                Inputs.inputHorizontal = 0;
                if (lane < 1 && moving == 0 && dashing <= 0)
                {
                    lane++;
                    moving = 1;
                }
            }

            //Dash
            if (Inputs.inputDash)
            {
                Inputs.inputDash = false;
                if (moving == 0 && dashing <= 0 && !dashed)
                {
                    playerRb.useGravity = false;
                    playerRb.velocity = new Vector3(0, 0, 0);
                    dashing = 0.4f;
                    dashed = true;
                    SpeedManager.boost = 2;

                }
            }


            //Move
            if (moving != 0)
            {
                if (Mathf.Abs(lane * 4 - transform.position.x) > 0.15)
                {
                    transform.Translate(new Vector3(Time.deltaTime * moving * 30, 0, 0));
                }
                else
                {
                    moving = 0;
                    transform.SetPositionAndRotation(new Vector3(lane * 4, transform.position.y, transform.position.z), transform.rotation);
                }
            }

            //Dash
            if (dashing > 0)
            {
                dashing -= Time.deltaTime;
                if (dashing <= 0)
                {
                    playerRb.useGravity = true;
                    SpeedManager.boost = 1;
                }
            }

            if (transform.position.x > 4)
                transform.SetPositionAndRotation(new Vector3(4, transform.position.y, transform.position.z), transform.rotation);
            if (transform.position.x < -4)
                transform.SetPositionAndRotation(new Vector3(-4, transform.position.y, transform.position.z), transform.rotation);
            if (onGround)
                dashed = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            SpeedManager.boost = 1;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SpeedManager.gameOver = true;
            SpeedManager.speed = 0;
        }
    }
}
