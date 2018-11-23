using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    
    [SerializeField] AudioSource impact;
    [SerializeField] AudioClip impactClip;
    [SerializeField] GameObject escapeHospital;    

    public IEnumerator playSound()
    {
        Debug.Log("PLAY SOUND func");
        impact.PlayOneShot(impactClip);
        
        escapeHospital.SetActive(true);
        yield return new WaitForSeconds(1f);

        Destroy(this.gameObject);
    }    
}
