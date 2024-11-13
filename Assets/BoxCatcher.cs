using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCatcher : MonoBehaviour
{
    private int numberOfballs;
    public GameObject winState;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Balls")
        {
            numberOfballs++;
            Debug.Log("Found A Ball");
            Debug.Log("Number Of Balls = " + numberOfballs);

            if (numberOfballs > 3)
            {


                winState.SetActive(true);

            }


        }
    }

}
