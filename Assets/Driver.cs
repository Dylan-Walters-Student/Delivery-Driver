using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 250f;
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float speedDamp = 0.5f;
    [SerializeField] private float speedBoost = 1.5f;
    private bool damp = false;
    private float holdSpeed;

    private void Start()
    {
        holdSpeed = moveSpeed;
    }
    void Update()
    {
        
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!damp)
        {
            Debug.Log("Bonk.");
            moveSpeed *= speedDamp;
            damp = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Speed" && !damp)
        {
            Debug.Log("I am speed");
            moveSpeed *= speedBoost;
            Destroy(other.gameObject, 0.2f);
            damp = true;
        }

        if (other.tag == "Slow" && !damp)
        {
            Debug.Log("Ope ive been iced. Darn ice cream man.");
            moveSpeed *= speedDamp;
            Destroy(other.gameObject, 0.2f);
            damp = true;
        }

        if (other.tag == "Customer")
        {
            moveSpeed = holdSpeed;
            damp = false;
        }
    }
}
