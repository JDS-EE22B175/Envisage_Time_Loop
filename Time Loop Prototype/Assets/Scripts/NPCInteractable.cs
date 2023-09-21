using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    Animator animator;
    int interactHash;
    private void Start()
    {
        animator = GetComponent<Animator>();
        interactHash = Animator.StringToHash("isInteracted");
    }
    public void Interact(Transform interactorTransform)
    {
        Debug.Log("This is a Test Interaction with " + gameObject.name);
        animator.SetBool(interactHash, true);
        StartCoroutine(talkWait());
    }

    IEnumerator talkWait()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool(interactHash, false);
    }

    public string GetInteractText()
    {
        return "Talk with " + gameObject.name;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
