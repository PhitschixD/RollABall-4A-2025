using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class playercontr : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue movementvalue)
    {
        Vector2 movementvector = movementvalue.Get<Vector2>();
        movementX = movementvector.x;
        movementY = movementvector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX,0.0f, movementY );
        rb.AddForce(movement* speed);
    }
}
