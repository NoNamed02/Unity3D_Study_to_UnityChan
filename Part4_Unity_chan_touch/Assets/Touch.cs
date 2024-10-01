using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Touch : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    public AudioClip [] voice = new AudioClip[2];
    private AudioSource audioSource;
    private Animator animator;
    private int motionIdol = Animator.StringToHash("Base Layer.Idol");
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        animator.SetBool("Touch", false);
        animator.SetBool("TouchHead", false);
        animator.SetBool("Face_Angry", false);
        animator.SetBool("Face_Surprise", false);

        GameObject hitObject;
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log("Hit");
                hitObject = hit.collider.gameObject;

                if (hitObject.gameObject.tag == "Head")
                {
                    animator.SetBool("TouchHead", true);
                    animator.SetBool("Face_Surprise", true);
                    audioSource.clip = voice[0];
                }
                else if (hitObject.gameObject.tag == "Breast") 
                {
                    animator.SetBool("Touch", true);
                    animator.SetBool("Face_Angry", true);
                    audioSource.clip = voice[1];
                }
                audioSource.Play();
            }
        }
    }
}
