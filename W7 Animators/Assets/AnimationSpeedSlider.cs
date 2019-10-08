using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationSpeedSlider : MonoBehaviour
{

    public Slider s;
    Animator anim;

    float s_value;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        s_value = s.value;
        anim.speed = s_value;
    }

    public void myAnimationEventFunction() {
        Debug.Log("I'm dizzy!");
    }
}
