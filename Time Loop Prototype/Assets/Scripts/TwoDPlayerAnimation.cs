using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDPlayerAnimation : MonoBehaviour
{
    Animator animator;
    float velX = 0f;
    float velZ = 0f;
    public float acceleration = 2f;
    public float deceleration = 4f;
    public float maxWalkVel = 0.5f;
    public float maxRunVel = 2f;

    // Increasing Performance using Hashes
    int velXHash;
    int velZHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        velXHash = Animator.StringToHash("VelocityX");
        velZHash = Animator.StringToHash("VelocityZ");
    }

    void ChangeVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool sprintPressed, float currentMaxVel, bool backwardPressed)
    {
        if (forwardPressed && velZ < currentMaxVel)
        {
            velZ += Time.deltaTime * acceleration;
        }

        if (leftPressed && velX > -currentMaxVel)
        {
            velX -= Time.deltaTime * acceleration;
        }

        if (rightPressed && velX < currentMaxVel)
        {
            velX += Time.deltaTime * acceleration;
        }

        if (!forwardPressed && velZ > 0f)
        {
            velZ -= Time.deltaTime * deceleration;
        }

        if (!backwardPressed && velZ < 0f)
        {
            velZ += Time.deltaTime * deceleration;
        }

        if (backwardPressed && velZ > -maxWalkVel)
        {
            velZ -= Time.deltaTime * acceleration;
        }

        if (!rightPressed && velX > 0f)
        {
            velX -= Time.deltaTime * deceleration;
        }
        if (!leftPressed && velX < 0f)
        {
            velX += Time.deltaTime * deceleration;
        }
    }

    void LockResetVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool sprintPressed, float currentMaxVel, bool backwardPressed)
    {

        if (!forwardPressed && !backwardPressed && (velZ > -0.05f && velZ < 0.05f))
        {
            velZ = 0f;
        }

        if (!rightPressed && !leftPressed && velX != 0f && (velX > -0.05f && velX < 0.05f))
        {
            velX = 0f;
        }

        if (backwardPressed && velZ < -maxWalkVel)
        {
            velZ = -maxWalkVel;
        }

        if (forwardPressed && sprintPressed && velZ > currentMaxVel)
        {
            velZ = currentMaxVel;
        }
        else if (forwardPressed && velZ > currentMaxVel)
        {
            velZ -= Time.deltaTime * deceleration;

            if (forwardPressed && velZ > currentMaxVel && velZ < (currentMaxVel + 0.05f))
            {
                velZ = currentMaxVel;
            }
        }
        else if (forwardPressed && velZ < currentMaxVel && velZ > (currentMaxVel - 0.05f))
        {
            velZ = currentMaxVel;
        }

        // Right Sprint
        if (rightPressed && sprintPressed && velX > currentMaxVel)
        {
            velX = currentMaxVel;
        }
        else if (rightPressed && velX > currentMaxVel)
        {
            velX -= Time.deltaTime * deceleration;

            if (rightPressed && velX > currentMaxVel && velX < (currentMaxVel + 0.05f))
            {
                velX = currentMaxVel;
            }
        }
        else if (rightPressed && velX < currentMaxVel && velX > (currentMaxVel - 0.05f))
        {
            velX = currentMaxVel;
        }

        // Left Sprint
        if (leftPressed && sprintPressed && velX < -currentMaxVel)
        {
            velX = -currentMaxVel;
        }
        else if (leftPressed && velX < -currentMaxVel)
        {
            velX += Time.deltaTime * deceleration;

            if (leftPressed && velX < -currentMaxVel && velX > (-currentMaxVel - 0.05f))
            {
                velX = -currentMaxVel;
            }
        }
        else if (leftPressed && velX > -currentMaxVel && velX < (-currentMaxVel + 0.05f))
        {
            velX = -currentMaxVel;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool sprintPressed = Input.GetKey(KeyCode.LeftShift);
        bool backwardPressed = Input.GetKey(KeyCode.S);

        float currentMaxVel = sprintPressed ? maxRunVel : maxWalkVel;

        ChangeVelocity(forwardPressed, leftPressed, rightPressed, sprintPressed, currentMaxVel, backwardPressed);
        LockResetVelocity(forwardPressed, leftPressed, rightPressed, sprintPressed, currentMaxVel, backwardPressed);

        animator.SetFloat(velXHash, velX);
        animator.SetFloat(velZHash, velZ);
    }
}
