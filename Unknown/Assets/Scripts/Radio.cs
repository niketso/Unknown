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
    
    private void OnTriggerEnter(Collider other)
    {
        plyr = GameObject.FindGameObjectWithTag("Player");
       
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
