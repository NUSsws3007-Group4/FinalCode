using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBoard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        TutorialManager tu;

        if (other.gameObject.layer == 19)
        {
            if (tu = gameObject.GetComponent<TutorialManager>())
            {
                tu.showBox();
            }
            foreach (Transform i in transform)
            {
                i.gameObject.SetActive(false);
            }
            gameObject.SetActive(false);
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        TutorialManager tu;

        if (other.gameObject.layer == 19)
        {
            if (tu = gameObject.GetComponent<TutorialManager>())
            {
                tu.showBox();
            }
            foreach (Transform i in transform)
            {
                i.gameObject.SetActive(false);
            }
            gameObject.SetActive(false);
        }
    }


}
