using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Radio : MonoBehaviour {
    public UnityEvent zombiedistract;
    [SerializeField]
    private AudioSource sound;
    [SerializeField]
    private AudioClip radioSound;
    bool plyr;

    private void Awake()
    {
        if(zombiedistract == null)
        {
            zombiedistract = new UnityEvent();
        }            
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Batteries")
        {
            plyr = true;
            Destroy(other.gameObject);
        }
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
        sound.PlayOneShot(radioSound);
        zombiedistract.Invoke();
    }
}
