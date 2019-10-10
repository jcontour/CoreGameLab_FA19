using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForMatches : MonoBehaviour
{
    int x_count;
    int o_count;

    public void CheckMatches(bool XorO) {
        if (XorO)
        {
            x_count++;
            if (x_count == 3) {
                Debug.Log("X is the winner!!");
            }
        }
        else {
            o_count++;
            if(o_count == 3) {
                Debug.Log("O is the winner!!");
            }
        }
    }

}
