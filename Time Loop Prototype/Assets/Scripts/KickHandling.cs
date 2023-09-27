using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickHandling : MonoBehaviour
{
    public float kickBack = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Kicked");
        GameObject target = collision.gameObject;
        if(target.CompareTag("Enemy"))
        {
            target.transform.position += Vector3.Lerp(Vector3.zero, target.transform.forward * -1 * kickBack, 0.005f);
        }
    }
}
