using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 2f;
    public float angleSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Input.GetAxisRaw("Vertical") * Time.deltaTime);
        transform.Translate(Vector3.right * speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime);
        transform.Rotate(Vector3.up, Input.GetAxisRaw("Horizontal") * Time.deltaTime);
    }
}
