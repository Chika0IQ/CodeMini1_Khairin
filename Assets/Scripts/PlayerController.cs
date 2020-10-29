using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int plane = 0;

    float speed = 8.0f;
    float Alimit = 10.0f;
    float Blimit = 5.0f;

    float xlimit;
    float zlimit;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (plane == 0)
        {
            xlimit = Alimit;
            zlimit = Alimit;

            if (transform.position.z > zlimit)
            {
                if (transform.position.x > -xlimit / 2 && transform.position.x < xlimit / 2)
                {
                    transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, zlimit);
                }
            }
            else if (transform.position.z < -zlimit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -zlimit);
            }
            else
            {
                transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
            }
            if (transform.position.x > xlimit)
            {
                transform.position = new Vector3(xlimit, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < -xlimit)
            {
                transform.position = new Vector3(-xlimit, transform.position.y, transform.position.z);
            }
            else
            {
                transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
            }
        }
        else
        {
            zlimit = Alimit + 2 * Blimit;
            xlimit = Blimit;

            if (transform.position.z < Alimit)
            {
                if (transform.position.x > -Alimit / 2 && transform.position.x < Alimit / 2)
                {
                    transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, Alimit);
                }
            }
            else if (transform.position.z > zlimit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zlimit);
            }
            else
            {
                transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
            }

            if (transform.position.x > xlimit)
            {
                transform.position = new Vector3(xlimit, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < -xlimit)
            {
                transform.position = new Vector3(-xlimit, transform.position.y, transform.position.z);
            }
            else
            {
                transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlaneA"))
        {
            Debug.Log("In Plane A");
            plane = 0;
        }
        if (collision.gameObject.CompareTag("PlaneB"))
        {
            Debug.Log("In Plane B");
            plane = 1;
        }
    }
}