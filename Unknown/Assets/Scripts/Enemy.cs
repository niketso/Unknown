using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    
    [SerializeField] GameObject radio;
    [SerializeField] AudioSource impact;
    [SerializeField] AudioClip impactClip;
    [SerializeField] Animator die;
    
    
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }    
    
    public void DistractZombie()
    {
        agent.destination = radio.transform.position;
    }

    IEnumerator playSound()
    {
        impact.PlayOneShot(impactClip);
        die.Play("fallingback");
        yield return new WaitForSeconds(1f);
        
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Axe")
        {
            StartCoroutine(playSound());
            Destroy(other.gameObject);
        }
    }
}
