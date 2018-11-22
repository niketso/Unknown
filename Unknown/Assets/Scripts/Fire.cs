using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    [SerializeField] AudioSource impact;
    [SerializeField] AudioClip impactClip;

    IEnumerator playSound()
    {
        Debug.Log("culo");
        impact.PlayOneShot(impactClip);
        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Fuera del if");
        if (other.gameObject.tag == "FireExt")
        {
            Debug.Log("Dentro del if");
            StartCoroutine(playSound());
            Destroy(other.gameObject);
        }
    }
}
