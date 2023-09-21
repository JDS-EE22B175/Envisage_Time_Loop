using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    int velocityHash;
    float animationVelocity = 0f;
    public float acceleration = 0.1f;
    public float deceleration = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        velocityHash = Animator.StringToHash("Velocity");
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool sprintPressed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        if(forwardPressed && animationVelocity < 1f)
        {
            animationVelocity += Time.deltaTime * acceleration;
        }

        if (!forwardPressed && animationVelocity >= 0f)
        {
            animationVelocity -= Time.deltaTime * deceleration;
        }

        if (animationVelocity < 0f) animationVelocity = 0f;

        animator.SetFloat(velocityHash, animationVelocity);
    }
}
