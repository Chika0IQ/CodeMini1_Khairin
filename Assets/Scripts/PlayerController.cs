using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int planeindicator = 0;

    float speed = 20.0f;
    float boundary = 10.0f;
    float Alimit = 10.0f;
    float Blimit = 5.0f;
    int onplane = 0;
        
    float gravityModifier = 2.5f;

    float xlimit = 0f;
    float zlimit = 0f;

    Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        float vertialInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * vertialInput * speed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);


        if (onplane == 0)
        {
            if (transform.position.x > -xlimit / 2 && transform.position.x < xlimit / 2)
            {
                transform.Translate(Vector3.forward * vertialInput * speed * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, xlimit);
            }
            else if (transform.position.z < -zlimit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.z, -zlimit);
            }
            else
            {
                transform.Translate(Vector3.forward * vertialInput * speed * Time.deltaTime);
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
                    transform.Translate(Vector3.forward * vertialInput * speed * Time.deltaTime);
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
                transform.Translate(Vector3.forward * vertialInput * speed * Time.deltaTime);
            }
            if (transform.position.x > xlimit)
            {

            }
        }
        























            
        //Front
        if (transform.position.z < -boundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -boundary);
        }
        /*else if (transform.position.z > boundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, boundary);
        }*/

        

        
        

        //Left / Right Boundary
        
        if (transform.position.x < -boundary)
        {
            transform.position = new Vector3(-boundary, transform.position.y, transform.position.z);
        }

        else  if (transform.position.x > boundary)
        {
            transform.position = new Vector3(boundary, transform.position.y, transform.position.z);

        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("PlaneA"))
            {
                Destroy(playerRb    );
            }
        }
    }
}
