using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAni : MonoBehaviour
{
    public int ani = 0;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        if(ani == 1) animator.Play("DAMAGED01");
        else if(ani == 2) animator.Play("JUMP01");
    }
}
