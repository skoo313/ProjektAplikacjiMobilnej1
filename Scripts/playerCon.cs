using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCon : MonoBehaviour
{
    protected Joystick joystick;
    protected Button button;

    public float walk_speed = 2f;
    public float run_speed = 5f;

    private Animator aa;

    // Start is called before the first frame update
    void Start()
    {
        
        joystick = FindObjectOfType<Joystick>();
        button = GetComponent<Button>();
        aa = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 input = new Vector2(joystick.Horizontal , joystick.Vertical );
        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {             //radiany                                                                   stopnie
            transform.eulerAngles = Vector3.up * Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
        }
  
        bool running = GameObject.Find("RunButton").GetComponent<runButton>().buttonPressed;
        float speed = ((running) ? run_speed : walk_speed) * inputDir.magnitude;

        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

        float animSpeed = ((running) ? 1 : .5f) * inputDir.magnitude;
        aa.SetFloat("animationChanger", animSpeed);
    }
}
