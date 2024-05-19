using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterYurutucu : MonoBehaviour
{
    public AudioClip startClip;
    public Transform cameraTransform;
    public Rigidbody rb;
    public Animator animator;
    public float hiz = 5;
    public float kameraHizi = 10;

    public void PlayStartClip()
    {
        AudioSource.PlayClipAtPoint(startClip, transform.position);
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 hareket = transform.forward * z + transform.right * x;
        hareket = hareket.normalized * hiz;
        hareket.y = rb.velocity.y;

        rb.velocity = hareket;

        if (x != 0 || z != 0)
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }

        float kamera = Input.GetAxis("Mouse X");

        transform.eulerAngles += new Vector3(0, kamera, 0) * kameraHizi * Time.deltaTime;

        float kameraDikey = Input.GetAxis("Mouse Y");

        cameraTransform.eulerAngles += new Vector3(-kameraDikey, 0 , 0) * kameraHizi * Time.deltaTime;
    }
}
