using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{

    public GameObject heart;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = heart.GetComponent<Animator>();
    }

    public void OnToggle() {
        Debug.Log(GetComponent<Toggle>().isOn);
        bool toggleVal = GetComponent<Toggle>().isOn;
        anim.SetBool("doFillHeart", toggleVal);
    }

}
