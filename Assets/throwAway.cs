using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwAway : MonoBehaviour
{
    public bool picked = false;
    public GameObject thisBall;
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!picked && thisBall != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                picked = true; 
                thisBall.transform.position = new Vector3(transform.position.x+0.5f, transform.position.y, transform.position.z+0.5f);
                thisBall.transform.parent = cam.transform;
                Rigidbody rb = thisBall.GetComponent<Rigidbody>();
                rb.isKinematic = true;
                
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pickup")
        {
            picked p = other.gameObject.GetComponent<picked>();
            p.approached = true;
            thisBall = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "pickup")
        {
            picked p = other.gameObject.GetComponent<picked>();
            p.approached = false;
            thisBall = null;
        }
    }

}
