using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunSonu : MonoBehaviour
{
    public AudioClip audioClip;
    public GameObject aktifEt;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<KarakterYurutucu>().enabled = false;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            aktifEt.SetActive(true);
            if (audioClip)
                AudioSource.PlayClipAtPoint(audioClip, transform.position);
        }
    }
}
