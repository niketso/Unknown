using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Extinguisher : MonoBehaviour {

    public UnityEvent hitZombie;
    GameObject enmy;
    private void Awake()
    {

        if (hitZombie == null)
        {
            hitZombie = new UnityEvent();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        enmy = GameObject.FindGameObjectWithTag("Enemy");

    }
    private void Update()
    {
        if (enmy)
        {
            ExtinguisherUsed();
        }
    }
    private void ExtinguisherUsed()
    {
        hitZombie.Invoke();
    }
}
