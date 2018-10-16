using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{
    public int vidas = 3;
    public GameObject origin;
    float cooldownDamage = 0;
    public bool hasKey;
    public GameObject ropa;
    public int puzzleNumber = 1;

    
    private NavMeshAgent agent;
    private Animator anim;
   // private Rigidbody rb;
    

    private Vector3 destinationPosition;
    int layerMask1;
    int layerMask2;
    int layerMask3;

    public bool moving = false;
    

    public bool hasRopa = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        layerMask1 = LayerMask.GetMask("Destinations");
        layerMask2 = LayerMask.GetMask("Object", "Hint");
        layerMask3 = LayerMask.GetMask("Consumable");
    }

    void Start()
    {
        origin.transform.position = transform.position;               
    }

    void Update()
    {       

        //Debug.Log(agent.isStopped);
        //Debug.Log("destino" + agent.destination);
        //Debug.Log("remaininDistance" + agent.remainingDistance);

        cooldownDamage += Time.deltaTime;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100, layerMask1))
            {
                if (moving == false )
                {
                    agent.stoppingDistance = 0;
                    agent.destination = hit.point;
                    anim.SetTrigger("Walk");
                    
                    moving = true;
                   
                    
                }
                 
            }
            else if (Physics.Raycast(ray, out hit, 100, layerMask2))
            {
                agent.stoppingDistance = 1;
                agent.destination = hit.point;
                anim.SetTrigger("Walk");
                

            }
            else if (Physics.Raycast(ray, out hit, 100, layerMask3))
            {
                agent.stoppingDistance = 1;
                agent.destination = hit.point;
                anim.SetTrigger("Walk");
                
            }
            
        }

        if (agent.remainingDistance >= agent.stoppingDistance)
            agent.isStopped = false;
        else
        {
            agent.isStopped = true;
        }
       
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

    public int GetVidas()
    {
        return vidas;
    }

    void Die()
    {
        SceneManager.LoadScene("GameOver");
    }
    
    public bool GetKey()
    {
        return hasKey;
    }

    public void PickKey()
    {
        hasKey = true;
    }

    public void setPuzzleNumber()
    {
        puzzleNumber++;
    }

    public int getPuzzleNumber()
    {
        return puzzleNumber;
    }

    public bool IsMoving()
    {
        return moving;
    }
    public void Arrived()
    {
        moving = false;
        anim.SetTrigger("Idle");
    }
    
}