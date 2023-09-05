using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 100f;
    public ParticleSystem deadAffect;
    public bool isDead = false;
    private GameManager gameManager;

    private enum CurrentDirection { Left, Right };
    private CurrentDirection cr;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cr = CurrentDirection.Left;
        gameManager= GameObject.FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (!isDead)
        {
            RayCastDetector();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Stop();
                ChangeDirection();
            }
            else return;
        }
    }

    private void ChangeDirection()
    {
        if (cr == CurrentDirection.Left)
            cr = CurrentDirection.Right;
        else if (cr == CurrentDirection.Right)
            cr = CurrentDirection.Left;
    }

    private void Move()
    {
        if (cr == CurrentDirection.Right)
            rb.AddForce(Vector3.forward * speed * Time.deltaTime, ForceMode.VelocityChange);
        else if (cr == CurrentDirection.Left)
            rb.AddForce(Vector3.right * speed * Time.deltaTime, ForceMode.VelocityChange);
    }
    private void Stop()
    {
        rb.velocity = Vector3.zero;
    }

    private void RayCastDetector()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit))
            Move();
        else
        {
            Stop();
            isDead = true;
            gameObject.SetActive(false);
            Debug.Log("false'dan sonrasi");
            gameManager.LoseLevel();
            Instantiate(deadAffect, transform.position, Quaternion.identity);
            Debug.Log("affect sonrasi");

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndTrigger"))
        {
            gameManager.WinLevel();
            Stop();
            gameObject.SetActive(false);
        }
    }
}
