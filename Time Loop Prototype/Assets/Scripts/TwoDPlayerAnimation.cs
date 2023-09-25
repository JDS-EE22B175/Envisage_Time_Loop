using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
    public float movementSpeed = 0.01f;
    public float forwardMovementBoost = 1.5f;
    CharacterController controller;

    // Increasing Performance using Hashes
    int velXHash;
    int velZHash;
    int kickingHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        velXHash = Animator.StringToHash("VelocityX");
        velZHash = Animator.StringToHash("VelocityZ");
        kickingHash = Animator.StringToHash("isKicking");
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

    public void KickDone(string kickAnimationDone)
    {
        if (kickAnimationDone == "done")
        {
            animator.SetBool(kickingHash, false);
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
        bool isKicking = Input.GetKeyDown(KeyCode.Space);

        float currentMaxVel = sprintPressed ? maxRunVel : maxWalkVel;

        ChangeVelocity(forwardPressed, leftPressed, rightPressed, sprintPressed, currentMaxVel, backwardPressed);
        LockResetVelocity(forwardPressed, leftPressed, rightPressed, sprintPressed, currentMaxVel, backwardPressed);

        if (isKicking)
        {
            animator.SetBool(kickingHash, true);
            Debug.Log("Kicked");
        }

        

        if (!isKicking)
        {
            animator.SetFloat(velXHash, velX);
            animator.SetFloat(velZHash, velZ);
            if (!sprintPressed)
                controller.Move((transform.forward * velZ * forwardMovementBoost + transform.right * velX) * movementSpeed);
            else if (sprintPressed)
                controller.Move((transform.forward * velZ + transform.right * velX) * movementSpeed);
        }
    }
}
