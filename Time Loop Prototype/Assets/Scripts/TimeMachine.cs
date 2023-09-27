using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMachine : MonoBehaviour, IInteractable
{
    public void Interact(Transform interactorTransform)
    {

    }
    public string GetInteractText()
    {
        return ("Interact with the " + gameObject.name);
    }
    public Transform GetTransform()
    {
        return transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
