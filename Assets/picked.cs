using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picked : MonoBehaviour
{
    public bool approached = false;
    public Behaviour halo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (approached)
        {
            halo.enabled = true;
        }
        else
        {
            halo.enabled = false;
        }
    }
}
