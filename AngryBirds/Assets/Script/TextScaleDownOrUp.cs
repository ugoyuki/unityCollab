using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScaleDownOrUp : MonoBehaviour
{
    public float time, ChangeSpeed;
    public bool enlarge = true;

    void Start()
    {

    }

    void Update()
    {

        if(time < 0)
        {
            Destroy(gameObject);
            return;
        }

        float changeSpeed = Time.deltaTime * ChangeSpeed;

        //if (time < 0)
        //{
        //    enlarge = true;
        //}
        //if (time > 0.7f)
        //{
        //    enlarge = false;
        //}

        if (enlarge == true)
        {
            time -= Time.deltaTime;
            transform.localScale += new Vector3(changeSpeed, changeSpeed, changeSpeed);
        }
        else
        {
            time -= Time.deltaTime;
            transform.localScale -= new Vector3(changeSpeed, changeSpeed, changeSpeed);
        }
    }
}
