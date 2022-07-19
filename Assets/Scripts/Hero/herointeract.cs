using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class herointeract : MonoBehaviour
{
    // Start is called before the first frame update
    public bloodbarcontrol mUIManager = null;
    private float mHurtTimer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "cherry")
        {
            Destroy(collider.gameObject);
            mUIManager.increasevolume(1f);
        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.layer == 14 || collider.gameObject.layer == 13)
        {
            mHurtTimer = 0;
            mUIManager.decreasevolume(1f);
            gameObject.GetComponent<HeroBehavior>().hurt();
        }
        //gameObject.GetComponent<HeroMovement>().setspeed(-50*((float)gameObject.GetComponent<HeroMovement>().getMoveDirection()));
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 14 || collider.gameObject.layer == 13)
        {
            mHurtTimer += Time.deltaTime;
            if (mHurtTimer >= 1f)
            {
                mHurtTimer = 0;
                mUIManager.decreasevolume(1f);
                gameObject.GetComponent<HeroBehavior>().hurt();
            }
            
        }
        //gameObject.GetComponent<HeroMovement>().setspeed(-50*((float)gameObject.GetComponent<HeroMovement>().getMoveDirection()));
    }

}
