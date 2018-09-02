using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextActivator : MonoBehaviour
{

    public Text actionDisplay; //Text That Will Show ToolTip

    int layerMask; //Used To Filter Which Colliders Will Be Hit By Raycast

    // Use this for initialization
    void Start()
    {
        actionDisplay.enabled = false; //Start Out Disabled

        layerMask = LayerMask.GetMask("Destinations"); //Only Objects On The Character Layer Will Be Afected
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit; //Holds Information From Raycast

        //*Notice "hit" is not initialized yet, it will be handled by the "out" keyword below

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//Ray Will Will Start At The Mouse Position And Travel Forward Into The Scene

        if (Physics.Raycast(ray, out hit, 1000.0f, layerMask)) // Starting point, direction, distance, layer to interact with
        {
            ShowInfo(hit.collider.gameObject.name); //Pass Name Of Object To Method
        }
        else
        {
            actionDisplay.enabled = false; //Turn Off Text When Mouse Isn't Over Appropriate Collider
        }
    }


    void ShowInfo(string name)
    {
        actionDisplay.enabled = true; //Turn On Text Object

        actionDisplay.text = name; //Update Text

        gameObject.transform.position = Input.mousePosition; //Move Text To Mouse's Position
    }
}
