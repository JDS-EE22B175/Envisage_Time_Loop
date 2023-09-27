using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMachine : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject TimeMachineUI;
    public void Interact(Transform interactorTransform)
    {
        TimeMachineUI.SetActive(true);
        interactorTransform.gameObject.GetComponent<TwoDPlayerAnimation>().canMove = false;
        interactorTransform.gameObject.GetComponentInChildren<MouseLook>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
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
