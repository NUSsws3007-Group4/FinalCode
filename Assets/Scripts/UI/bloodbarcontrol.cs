using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bloodbarcontrol : MonoBehaviour
{
    public int maxblood=5;
    private const float alterspeed=3f;
    private const float effectalterspeed=2f;

    public Image bloodbarentity=null;
    public Image bloodbareffect=null;
    public Image bloodbarframe=null;
    public Image bloodicon=null;
    public RectTransform canvasrt;

    private float bloodvolume;
    private float effectvolume;
    private int targetvolume;
    private float entitydeltavolume;
    private float effectdeltavolume;
    private Vector2 entitysize;
    private Vector2 effectsize;
    private float rate;

    public Text showtext;
    public Text deltatext;
    private float timer;

    private string inttostring(int k)
    {
        string m="";
        if(k==0) m="0";
        while(k>0)
        {
            m=(char)(k%10+48)+m;
            k/=10;
        }
        return m;
    }

    public void changemaxblood(int delta)
    {
        maxblood+=delta;
    }

    public float getvolume()
    {
        return targetvolume;
    }

    public void setvolume(int delta)
    {
        if(delta<0) delta=0;
        if(delta>maxblood) delta=maxblood;
        targetvolume=delta;
    }

    public void increasevolume(int delta)
    {
        targetvolume=targetvolume+delta;

        showtext.text=inttostring(targetvolume);
        timer=2f;
        deltatext.text="+"+inttostring(delta);
        deltatext.color=new Color(0f,1f,0f,1f);
        deltatext.gameObject.SetActive(true);

        if(targetvolume<0) targetvolume=0;
        if(targetvolume>maxblood) targetvolume=maxblood;
        if(targetvolume>bloodvolume) entitydeltavolume=alterspeed; else entitydeltavolume=-alterspeed;

    }

    public void decreasevolume(int delta)
    {
        targetvolume=targetvolume-delta;

        showtext.text=inttostring(targetvolume);
        timer=2f;
        deltatext.text="-"+inttostring(delta);
        deltatext.color=new Color(1f,0f,0f,1f);
        deltatext.gameObject.SetActive(true);

        if(targetvolume<0) targetvolume=0;
        if(targetvolume>maxblood) targetvolume=maxblood;
        if(targetvolume>bloodvolume) entitydeltavolume=alterspeed; else entitydeltavolume=-alterspeed;
    }

    public void setsize()
    {
        entitysize=canvasrt.sizeDelta;
        entitysize.x/=5f;
        entitysize.y/=30f;
        bloodbarframe.GetComponent<RectTransform>().sizeDelta=entitysize;
        bloodbarentity.GetComponent<RectTransform>().sizeDelta=new Vector2(entitysize.x*bloodvolume/maxblood,entitysize.y);//entitysize*bloodvolume/maxblood;
        bloodbareffect.GetComponent<RectTransform>().sizeDelta=new Vector2(entitysize.x*effectvolume/maxblood,entitysize.y);

        showtext.GetComponent<RectTransform>().sizeDelta=new Vector2(entitysize.y*4f,entitysize.y);
        deltatext.GetComponent<RectTransform>().sizeDelta=new Vector2(entitysize.y*4f,entitysize.y);
        showtext.fontSize=(int)(entitysize.y*8.5f/10f);
        deltatext.fontSize=showtext.fontSize;
        //bloodbarframe.GetComponent<RectTransform>().anchoredPosition=new Vector3(entitysize.y*2f+10f,-entitysize.y,0f);      
        //bloodbarentity.GetComponent<RectTransform>().anchoredPosition=new Vector3(entitysize.y*2f+10f,-entitysize.y,0f);
        //bloodbareffect.GetComponent<RectTransform>().anchoredPosition=new Vector3(entitysize.y*2f+10f,-entitysize.y,0f);
        entitysize.x=entitysize.y;
        bloodicon.GetComponent<RectTransform>().sizeDelta=entitysize;
        bloodicon.GetComponent<RectTransform>().anchoredPosition=new Vector3(entitysize.y,-entitysize.y,0f);

        entitysize=bloodbarentity.GetComponent<RectTransform>().sizeDelta;
        effectsize=bloodbareffect.GetComponent<RectTransform>().sizeDelta;
        rate=bloodbarframe.GetComponent<RectTransform>().sizeDelta.x/maxblood;
    }

    void Start()
    {
        //initiate size and position
        bloodvolume=maxblood;
        effectvolume=maxblood;
        targetvolume=maxblood;

        showtext.text=inttostring(maxblood);
        deltatext.text="";
        deltatext.gameObject.SetActive(false);

        setsize();
        entitydeltavolume=0f;
        effectdeltavolume=0f;
        entitysize=bloodbarframe.GetComponent<RectTransform>().sizeDelta;
        effectsize=entitysize;
        rate=entitysize.x/maxblood;
        timer=0f;
    }

    void Update()
    {
        if(bloodvolume!=targetvolume)
        {
            bloodvolume+=entitydeltavolume*Time.unscaledDeltaTime;
            if((entitydeltavolume>0 && bloodvolume>targetvolume) || (entitydeltavolume<0 && bloodvolume<targetvolume))
            {
                bloodvolume=targetvolume;
            }
        }
        if(effectvolume!=bloodvolume)
        {
            if(bloodvolume<effectvolume) effectdeltavolume=-effectalterspeed; else effectdeltavolume=effectalterspeed;
            effectvolume+=effectdeltavolume*Time.unscaledDeltaTime;
            if(bloodvolume==targetvolume && ((effectdeltavolume>0 && effectvolume>bloodvolume) || (effectdeltavolume<0 && effectvolume<bloodvolume)))
            {
                effectvolume=bloodvolume;
            }
        }

        entitysize.x=bloodvolume*rate;
        effectsize.x=effectvolume*rate;
        bloodbarentity.GetComponent<RectTransform>().sizeDelta=entitysize;
        bloodbareffect.GetComponent<RectTransform>().sizeDelta=effectsize;

        if(timer>0) timer-=Time.unscaledDeltaTime;
        if(timer<0)
        {
            timer=0;
            deltatext.gameObject.SetActive(false);
        }
    }
}