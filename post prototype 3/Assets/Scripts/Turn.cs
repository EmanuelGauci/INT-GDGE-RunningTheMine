using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour{
    public float turnSpeed = 90f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
