using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    public int vidas = 3;
    public GameObject origin;
    float cooldownDamage = 0;

    //private Animator animator;
    private NavMeshAgent agent;
    private Rigidbody rb;
    //public bool isRunning;
    //Camera cam;

    private Vector3 destinationPosition;
    int layerMask;
    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        origin.transform.position = transform.position;
        //animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        layerMask = LayerMask.GetMask("Destinations","Hint","Consumable","Object");
        
    }

    void Update()
    {
        cooldownDamage += Time.deltaTime;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100, layerMask) )
            {
                agent.destination = hit.point; 
            }

            /*if (Physics.Raycast(ray, out hit, 100, layerMaskButton))
            {
                hit.collider.GetComponent<NotesController>().HideNoteImage();
                Debug.Log("CloseClicked");
            }*/

            /*if (hit.collider.CompareTag("Button"))
            {
                hit.collider.GetComponent<NotesController>().HideNoteImage();
                Debug.Log("CloseClicked");
            */
        }

       
       
        /*if (agent.remainingDistance <= agent.stoppingDistance)
        {
            isRunning = false;
        }
        else
        {
            isRunning = true;
        }

        animator.SetBool("Running", isRunning);*/
    }

    public void TakeDamage()
    {
        agent.destination = origin.transform.position;        
        
        if (cooldownDamage >= 0)
        {
            vidas -= 1;
            cooldownDamage = -3;
        }

        if(vidas<=0)
        {
            Die();
        }
        
         
    }

    public void SetOrigin(Transform pos)
    {
        origin.transform.position = pos.position;
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
