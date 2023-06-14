using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteMoveScript : MonoBehaviour
{
    public float noteSpeed;
    void Start()
    {
        Destroy(gameObject, 3);
    }

    void Update()
    {
        //fps60
        transform.Translate(0, noteSpeed * -1 * Time.deltaTime * 60, 0);
    }
}
