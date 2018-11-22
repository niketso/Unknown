using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MovePlayer : MonoBehaviour
{
    public int vidas = 3;
    public GameObject origin;
    float cooldownDamage = 0;   
    public int puzzleNumber = 1;
    private WaypointDetector wDetector;
    public bool IsInteractable = false;
    private NavMeshAgent agent;
    private Animator anim;    
    private Vector3 destinationPosition;

    int layerMask1;
    int layerMask2;
    int layerMask3;
    int layerMask4;

    public bool moving = false;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        layerMask1 = LayerMask.GetMask("Destinations");
        layerMask2 = LayerMask.GetMask("Object", "Hint");
        layerMask3 = LayerMask.GetMask("Consumable");
        layerMask4 = LayerMask.GetMask("Ground");
    }

    void Start()
    {
        origin.transform.position = transform.position;               
    }
//
    void Update()
    {
        Debug.Log("MOVING: " + moving);
        cooldownDamage += Time.deltaTime;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (agent.remainingDistance == 0)
            Arrived();
        else
            moving = true;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100, layerMask1) && moving == false)
            {
                agent.destination = hit.transform.position;
                anim.SetTrigger("Walk");                
                agent.stoppingDistance = 0;                
            }

            if (Physics.Raycast(ray, out hit, 100, layerMask2) && moving == false)
            {
                agent.destination = hit.transform.position;
                anim.SetTrigger("Walk");              
                agent.stoppingDistance = 1;
            }
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

    public void setPuzzleNumber()
    {
        puzzleNumber++;
    }

    public int getPuzzleNumber()
    {
        return puzzleNumber;
    }

    public void Arrived()
    {
        moving = false;        
        anim.SetTrigger("Idle");
    }
    
}