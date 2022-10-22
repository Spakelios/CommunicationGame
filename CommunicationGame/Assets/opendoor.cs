using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour
{
    public Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Input.GetKey(KeyCode.F);
            {
                anim.Play("open");
            }
        }
    }
}
