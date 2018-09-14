using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
   // [SerializeField] GameObject zombie;

    public void DistractZombie()
    {
        Destroy(this.gameObject);
    }
}
