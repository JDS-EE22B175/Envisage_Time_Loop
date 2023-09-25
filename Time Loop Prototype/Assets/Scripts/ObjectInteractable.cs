using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class ObjectInteractable : MonoBehaviour, IInteractable
{
    public void Interact(Transform interactorTransform)
    {
        Destroy(gameObject);
        Debug.Log(interactorTransform.name + " Picked Up the " + gameObject.name);
    }
    public string GetInteractText()
    {
        return ("Pick Up the " + gameObject.name);
    }
    public Transform GetTransform()
    {
        return transform;
    }
}
