using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour {
	Timer popUpTimer = new Timer(2.0f);
	public bool activatePopUp = false;

	private void Awake()
	{
		this.GetComponent<Image>().enabled = false;
		this.GetComponentInChildren<Text>().enabled = false;
	}

	
	private void Update() {
		  if (activatePopUp)
        {
            
            ShowPopUpText();
        }
        else
        {
            activatePopUp = false;
			this.GetComponent<Image>().enabled = false;
		this.GetComponentInChildren<Text>().enabled = false;
        }
	}
	public void ShowPopUpText()
	{		  
		   popUpTimer.Start();

		   if(popUpTimer.Update(Time.deltaTime))
        {
            this.GetComponent<Image>().enabled = false;
		this.GetComponentInChildren<Text>().enabled = false;
			popUpTimer.Reset();
			activatePopUp = false;
			Debug.Log("deactivated");
            
        }
        else if(popUpTimer.IsRunning)
        { 
		    this.GetComponent<Image>().enabled = true;
		this.GetComponentInChildren<Text>().enabled = true;
			Debug.Log("activated");           
        }
	}



	 
}