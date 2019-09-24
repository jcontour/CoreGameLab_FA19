using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnButtonScript : MonoBehaviour
{
    bool dogOrCat = true;
    Image pic;
    public Sprite dog;
    public Sprite cat;

    private void Start()
    {
        pic = GetComponent<Image>();
    }

    public void ClickMe() {
        dogOrCat = !dogOrCat;

        if (dogOrCat)
        {
            pic.sprite = dog;
        }
        else {
            pic.sprite = cat;
        }
    }
}
