using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject looper;
    [SerializeField] GameObject timeMachineUIHandler;
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
        Debug.Log("Going To The " + gameObject.name.ToString().Split()[0]);
        SceneManager.LoadScene("Auditorium");
        DontDestroyOnLoad(looper);
        DontDestroyOnLoad(timeMachineUIHandler);
    }
    public string GetInteractText()
    {
        return "Go To The " + gameObject.name.ToString().Split()[0];
    }
    public Transform GetTransform()
    {
        return transform;
    }
}
