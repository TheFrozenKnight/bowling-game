using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins : MonoBehaviour
{
    private Vector3 initalPinPosition;
    private Quaternion initalPinRotaion;
    private bool scored = false;
    // Start is called before the first frame update
    void Start()
    {
        initalPinPosition = this.gameObject.transform.position;
        initalPinRotaion = this.gameObject.transform.rotation;
    }

    IEnumerator pinfall()
    {
        yield return new WaitForSeconds(3);
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        this.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ground")||other.CompareTag("out"))
        {
            if(scored == false)
            {
                FindObjectOfType<Manager>().score++;
                FindObjectOfType<Manager>().pinsLeft--;
                scored = true;
                StartCoroutine(pinfall());
            }
        }
    }
    /*
    public void ResetPins()
    {
        scored = false;
        Debug.Log("sakjdhsajdhasd");
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
        this.gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        this.gameObject.transform.position = initalPinPosition;
        this.gameObject.transform.rotation = Quaternion.Euler(initalPinRotaion.x, initalPinRotaion.y, initalPinRotaion.z);

    }*/
}
