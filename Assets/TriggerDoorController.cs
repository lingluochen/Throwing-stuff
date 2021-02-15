using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    public GameObject myDoor = null;
    private Animator anim;
    public bool open = false;
    public bool opened = false;
    AnimatorClipInfo[] m_CurrentClipInfo;
    void Start()
    {
        anim = myDoor.GetComponent<Animator>();
    }
    void Update()
    {
        if (open)
        {

            anim.SetBool("open", true);
            //gameObject.SetActive(false);
            m_CurrentClipInfo = anim.GetCurrentAnimatorClipInfo(0);
            string m_ClipName = m_CurrentClipInfo[0].clip.name;
            if (m_ClipName == "DoorClose" && opened == false)
            {
                myDoor.transform.rotation = Quaternion.Euler(0, -90, 0);;
                opened = true;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pickup")){
            open = true; 
        }
    }
}