using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class f1 : MonoBehaviour
{

    float time;
    float timeDelay;

    // Start is called before the first frame update
    [SerializeField] private float jumpheight;

    void Start()
    {
        time = 0f;
        timeDelay = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + 1f * Time.deltaTime;
        if (time >= timeDelay)
        {
            time = 0f;
            this.transform.position = this.transform.position + new Vector3(0f, 1f, 0f);


        }



    }
}
