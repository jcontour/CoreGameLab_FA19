using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeAndPlaceTiles : MonoBehaviour
{
    public GameObject tile_prefab;
    Vector3 mouseWorldPos;
    Vector3 mouseScreenPos;

    bool dragging;
    GameObject currTile;
    bool XorO;

    LayerMask gridLayer;
    LayerMask matchingLayer;

    // Start is called before the first frame update
    void Start()
    {
        gridLayer = LayerMask.GetMask("gridLayer");
        matchingLayer = LayerMask.GetMask("matchingLayer");
    }

    // Update is called once per frame
    void Update()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseScreenPos = new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0);

        if (dragging) {
            currTile.transform.position = mouseScreenPos;

            if (Input.GetMouseButtonDown(0)) {
                RaycastHit2D hit = Physics2D.Raycast(mouseScreenPos, Vector2.zero, 100f, gridLayer);
                if (hit.collider.gameObject.tag == "gridSpot") {
                    currTile.transform.position = hit.collider.gameObject.transform.position;
                    dragging = false;
                    hit.collider.gameObject.SetActive(false);

                    checkForMatches(mouseScreenPos, XorO);
                    XorO = !XorO;
                }
            }
        }
    }

    void checkForMatches(Vector3 pos, bool _XorO) {
        RaycastHit2D[] hits = Physics2D.RaycastAll(pos, Vector2.zero, 100f, matchingLayer);
        if (hits.Length > 0) {
            for (int i = 0; i < hits.Length; i++) {
                hits[i].collider.gameObject.GetComponent<CheckForMatches>().CheckMatches(_XorO);
            }
        }
    }

    public void ButtonClick() {
        if (!dragging)
        {
            currTile = Instantiate(tile_prefab, mouseScreenPos, Quaternion.identity);
            currTile.GetComponent<TileManager>().SetTile(XorO);
            dragging = true;
            
        }
    }

}
