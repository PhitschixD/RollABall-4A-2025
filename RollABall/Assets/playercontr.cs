using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;

public class playercontr : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public Vector3 ForceVector;

    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI gewonnentext;
    

    private float movementX;
    private float movementY;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gewonnentext.gameObject.SetActive(false);
    }

    private void OnMove(InputValue movementvalue)
    {
        Vector2 movementvector = movementvalue.Get<Vector2>();
        movementX = movementvector.x;
        movementY = movementvector.y;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space!");
            rb.AddForce(ForceVector, ForceMode.Impulse);
        }

        Vector3 movement = new Vector3(movementX,0.0f, movementY );
        rb.AddForce(movement* speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag("pickUp"))
        {
            other.gameObject.SetActive(false);
            score++;
            scoretext.text =  ("Score: " +  score);
        }

        if(score == 14) 
        {
            gewonnentext.gameObject.SetActive(true);
            gewonnentext.text = ("sie haben gewonnen.");
        }
        
    }
}
