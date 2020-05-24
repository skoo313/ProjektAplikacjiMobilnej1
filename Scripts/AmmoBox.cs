using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public Gun gun;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            gun.addToAmmo(30);
            Destroy(gameObject);

        }
    }

    void Update()
    {

        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }

   
    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.FindObjectOfType<Gun>();
    }



   

}
