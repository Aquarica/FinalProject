using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
    {
    public float speed;
    private Rigidbody rb;

    //public GameController gameControllerM;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //speed = gameControllerM.moveSpeed;
        rb.velocity = transform.forward * speed;
    }


    
}
