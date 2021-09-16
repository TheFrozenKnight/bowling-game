using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAndRotate : MonoBehaviour
{
    private float rotY;
    public float moveSpeed = 10f;
    Rigidbody rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(moveSpeed * Vector3.left * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed * Vector3.right * Time.deltaTime, Space.World);
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5.75f, 5.75f), transform.position.y, transform.position.z);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotY -=1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotY +=1;
        }
        rotY = Mathf.Clamp(rotY, -30, 30);
        transform.rotation = Quaternion.Euler(0, rotY, 0);
    }
}
