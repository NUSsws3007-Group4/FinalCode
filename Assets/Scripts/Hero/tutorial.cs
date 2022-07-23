using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public GameObject moveimage;
    public GameObject jumpimage;
    public GameObject bagimage;
    public int state;
    private bool at,dt;

    void Awake()
    {
        moveimage.SetActive(true);
        jumpimage.SetActive(false);
        bagimage.SetActive(false);
        state=0;
        at=dt=false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(state==0)
        {
            if(Input.GetKeyDown(KeyCode.A)) at=true;
            if(Input.GetKeyDown(KeyCode.D)) dt=true;
            if(at && dt)
            {
                state++;
                moveimage.SetActive(false);
                jumpimage.SetActive(true);
            }
        }
        else if(state==1)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                state++;
                jumpimage.SetActive(false);
                bagimage.SetActive(true);
            }
        }
        else if(state==2)
        {
            if(Input.GetKeyDown(KeyCode.B))
            {
                state++;
                bagimage.SetActive(false);
            }
        }
    }
}