using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launch : MonoBehaviour
{
    public float launceFource = 1000f;
    public bool shot = false;
    private Vector3 initalBallPosition;
    private Quaternion initalBallRotaion;
    Rigidbody rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        initalBallPosition = this.gameObject.transform.position;
        initalBallRotaion = this.gameObject.transform.rotation;
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space) && shot == false && FindObjectOfType<Manager>().shotsLeft >= 0)
        {
            this.rigidbody.AddForce(launceFource * transform.forward);
            transform.GetChild(0).gameObject.SetActive(false);
            gameObject.GetComponent<moveAndRotate>().enabled = false;
            shot = true;
            FindObjectOfType<Manager>().shotsLeft--;
            StartCoroutine(ball());
        }
    }
    IEnumerator ball()
    {
        yield return new WaitForSeconds(6);
        if (FindObjectOfType<Manager>().shotsLeft == 0 || FindObjectOfType<Manager>().score == 10 )
        {
            FindObjectOfType<Manager>().ResetGame();
        }
        else
            ResetBall();
    }
    public void ResetBall()
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        this.gameObject.transform.position = initalBallPosition;
        this.gameObject.transform.rotation = Quaternion.Euler(initalBallRotaion.x, initalBallRotaion.y, initalBallRotaion.z);

        transform.GetChild(0).gameObject.SetActive(true);
        gameObject.GetComponent<moveAndRotate>().enabled = true;
        shot = false;
    }
}
