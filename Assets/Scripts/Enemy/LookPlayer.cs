using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{
    Camera c;
    // Start is called before the first frame update
    void Start()
    {
        c = GameObject.Find("Player").transform.Find("PCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(c.transform.position);
    }
}
