using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallCounter : MonoBehaviour
{
    private int numberOfBalls;
    public TextMeshPro text;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Balls")
        numberOfBalls++;
        Destroy(other.gameObject,2f);
        Debug.Log("Ball Entered total balls=" + numberOfBalls);
        text.text="Ball Entered total balls=" + numberOfBalls;
    }

}
