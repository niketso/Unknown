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
    //public bool IsInteractable = false;
    private NavMeshAgent agent;
    private Animator anim;    
    private Vector3 destinationPosition;

    int layerMask1;
    int layerMask2;
    int layerMask3;
    int layerMask4;
    int layerMask5;
    int layerMask6;
    //int layerMask6;
    int layerMask7;

    public bool moving = false;

    public Image popUpText;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        layerMask1 = LayerMask.GetMask("Destinations");
        layerMask2 = LayerMask.GetMask("Object", "Hint");
        layerMask3 = LayerMask.GetMask("UI");
        layerMask4 = LayerMask.GetMask("Ground");
        layerMask5 = ((1 << 10) | (1 << 15));
        layerMask6 = (1 << 11);
        layerMask7 = (1 << 17);


    }

    void Start()
    {
        origin.transform.position = transform.position;               
    }
//
    void Update()
    {
        //Debug.Log("MOVING: " + moving);
        //Debug.Log("REMAINING DISTANCE = " + agent.remainingDistance);
        
        cooldownDamage += Time.deltaTime;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (agent.remainingDistance < 0.1)
            Arrived();
        else
            moving = true;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100, layerMask5)&&
                moving == false)
            {
                Debug.Log("LAYER DEL HIT 1 = " + hit.transform.gameObject.layer);
                if (hit.transform.tag == ("Door") && hit.transform.gameObject.GetComponent<DoorBehaviour>().isUnlocked == false)
                {
                    Debug.Log("PUERTA CERRADA");
                    moving = false;
                    anim.SetBool("Moving", false);
                    anim.SetTrigger("Idle");
                }
                else if (hit.transform.tag == ("Arrow"))
                {
                    anim.SetBool("Moving", true);
                    anim.SetTrigger("Walk");
                    agent.destination = hit.transform.GetComponent<Arrow>().arrowDestination.transform.position;
                    agent.stoppingDistance = 0;
                }
                else
                {
                    anim.SetBool("Moving", true);
                    anim.SetTrigger("Walk");
                    agent.destination = hit.transform.position;
                    agent.stoppingDistance = 0;
                }
            }

            if (Physics.Raycast(ray, out hit, 100, layerMask5) && moving == false)
            {
                Debug.Log("LAYER DEL HIT 2 = " + hit.transform.gameObject.layer);
                anim.SetBool("Moving", true);
                anim.SetTrigger("Walk");
                agent.destination = hit.transform.position;
                agent.stoppingDistance = 0;
            }
            if (!Physics.Raycast(ray, out hit, 100, layerMask7) &&
                !Physics.Raycast(ray, out hit, 100, layerMask5) &&
                Physics.Raycast(ray, out hit, 100, layerMask6)
                && moving == false)
            {
                Debug.Log("LAYER DEL HIT 3 = " + hit.transform.gameObject.layer);
                popUpText.GetComponent<PopUp>().activatePopUp = true;
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
        //Debug.Log("ARRIVEDfunc");
        moving = false;
        anim.SetBool("Moving", false);
        anim.SetTrigger("Idle");
    }
    
}