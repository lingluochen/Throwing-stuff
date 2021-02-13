using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwAway : MonoBehaviour
{
    public bool picked = false;
    public GameObject thisBall;
    public GameObject cam;
    public Camera realCam;
    public bool inHand = false;
    public GameObject handBall;
    public int throwCounter = 0;
    public bool throwing = false;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        realCam = cam.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (throwing)
        {
            throwCounter += 1;
        }
        if (throwCounter > 5)
        {
            throwing = false;
            throwCounter = 0;
        }

        if (!picked && thisBall != null && !inHand)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                picked = true;
                thisBall.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width*5 / 6, Screen.height / 5, Camera.main.nearClipPlane+1));
                thisBall.transform.parent = cam.transform;
                thisBall.transform.forward = cam.transform.forward;
                Rigidbody rb = thisBall.GetComponent<Rigidbody>();
                rb.isKinematic = true;
                picked ballP = thisBall.GetComponent<picked>();
                ballP.approached = false;
                inHand = true;
                handBall = thisBall;
            }
        }
        if (picked && inHand && handBall != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                picked = false;
                Rigidbody rb = thisBall.GetComponent<Rigidbody>();
                rb.isKinematic = false;
                handBall.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane + 1));
                handBall.transform.parent = null;
                rb.AddForce(transform.forward * 15, ForceMode.Impulse);
                handBall = null;
                inHand = false;
                throwing = true;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pickup" && !picked && !inHand && !throwing)
        {
            picked p = other.gameObject.GetComponent<picked>();
            p.approached = true;
            thisBall = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "pickup" && !inHand)
        {
            picked p = other.gameObject.GetComponent<picked>();
            p.approached = false;
            thisBall = null;
        }
    }

}
