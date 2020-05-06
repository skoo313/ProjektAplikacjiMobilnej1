using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    protected Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();

    }

    // Update is called once per frame
    void Update()
    {

        var rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(joystick.Horizontal * 10f, rb.velocity.y, joystick.Vertical * 10f);
    }
}
