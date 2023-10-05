using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueInteractable : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(Transform interactorTransform)
    {
        Debug.Log("Looking At The " + gameObject.name);
    }
    public string GetInteractText()
    {
        return "Look At The " + gameObject.name;
    }
    public Transform GetTransform()
    {
        return transform;
    }
}
