using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetTrigger("doDoorOpen");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetTrigger("doDoorOpen");
    }



}
