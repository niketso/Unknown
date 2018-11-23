using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    //[SerializeField] GameObject radio;
    [SerializeField] AudioSource impact;
    [SerializeField] AudioClip impactClip;
    [SerializeField] GameObject escapeHospital;
    // [SerializeField] Animator die;


    // private NavMeshAgent agent;

    /*private void Awake()
    {
    agent = GetComponent<NavMeshAgent>();
    }*/

    /* public void DistractZombie()
     {
         agent.destination = radio.transform.position;
     }*/

    IEnumerator playSound()
    {
        impact.PlayOneShot(impactClip);
        // die.Play("fallingback");
        escapeHospital.SetActive(true);
        yield return new WaitForSeconds(1f);

        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FireExt")
        {
            StartCoroutine(playSound());
            Destroy(other.gameObject);
        }
    }
}
