using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{

    Vector3 pos;
    bool pickedUp;
    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        pickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                pickedUp = true;
                obj = hit.collider.gameObject;
                Debug.Log(hit.collider.gameObject.name); 
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            pickedUp = false;
        }

        if (pickedUp)
        {
            DragObject(obj);
        }  
    }

    void DragObject(GameObject dragged) {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector3(mousePos.x, mousePos.y, 0);
        dragged.transform.position = pos;
    }
}
