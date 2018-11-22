using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Radio : MonoBehaviour {
    public UnityEvent zombiedistract;
    [SerializeField]
    private AudioSource sound;
    private int i = 0;
    [SerializeField]
    private AudioClip radioSound;
    [SerializeField]
    private GameObject escape;
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
        if (i == 0)
        {
            sound.PlayOneShot(radioSound, 0.1f);
            i++;
        }
        zombiedistract.Invoke();
        escape.SetActive(true);
    }
}
