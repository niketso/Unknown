using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Radio : MonoBehaviour {
    public UnityEvent zombiedistract;
    GameObject plyr;
    private void Awake()
    {

        if(zombiedistract == null)
        {
            zombiedistract = new UnityEvent();
        }
            
    }
    private void OnCollisionEnter(Collision collision)
    {
        plyr= GameObject.FindGameObjectWithTag("Player");

        Debug.Log("llego");
    }

    private void Update()
    {
        if (plyr)
        {
            RadioUsed();
        }
    }
    private void RadioUsed()
    {
        zombiedistract.Invoke();
    }
}
