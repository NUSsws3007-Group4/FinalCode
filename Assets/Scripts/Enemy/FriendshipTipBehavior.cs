using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendshipTipBehavior : SlimeBehavior
{
    public GameObject friendlyimage;
    public float timer;

    override protected void Start()
    {
        friendlyimage.SetActive(false);
        timer=0f;
        base.Start();
        mRigidbody.velocity = new Vector3(0, 0, 0);
        mFriendshipRequired = 0;
        friendshipAddValue = 60;
    }
    protected override void patrolBehavior()
    {
        Debug.Log("Slime patrolling");
    }
    protected override void friendlyBehavior()
    {
        base.friendlyBehavior();
        if (frienshipAdded)
        {
            Invoke("Death", 15);
        }
    }
    protected override void Update()
    {
        base.Update();
        if(timer>0)
        {
            timer-=Time.deltaTime;
            if(timer<=0)
            {
                timer=0;
                friendlyimage.SetActive(false);
            }
        }
    }

}