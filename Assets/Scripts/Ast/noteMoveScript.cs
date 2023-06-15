using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteMoveScript : MonoBehaviour
{
    public float noteSpeed;
    public int myLane;
    int timing;
    public float hitArea;
    public float justArea;
    public float slowArea;
    public float missrea;
    string myButton;
    void Start()
    {
        Destroy(gameObject, 3f);

        switch (myLane)
        {
            case 1:
                myButton = "b";
                break;
            case 2:
                myButton = "n";
                break;
            case 3:
                myButton = "m";
                break;
            default:
                myButton = "q";
                break;
        }
    }

    void Update()
    {
        if (transform.position.y < hitArea)
        {
            if (Input.GetKeyDown(myButton))
            {
                // 0 first  1 just  2 slow  3 miss
                // y= -2      -3      -4     -5
                timing = 0;
                if (transform.position.y < justArea) timing = 1;
                if (transform.position.y < slowArea) timing = 2;
                Debug.Log(timing);
                Destroy(gameObject);
            }
        }
        //fps60
        transform.Translate(0, noteSpeed * -1 * Time.deltaTime * 60, 0);
        if(transform.position.y < missrea){
            timing=3;
        }
    }
}
