using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    /*
     * 
     * This is the movement logic of the player ball. 
     * 
     */

    [SerializeField] public float speedIncrease;
    public float maxSpeed;
    private Rigidbody rigid;
    public bool b_inStart;
    Vector3 StartImpulse;
    float speeder;
    private void Start()
    {
        b_inStart = false;
        maxSpeed = 150.0f;
        speedIncrease = 0;
        rigid = GetComponent<Rigidbody>();
        speeder = 1f;
    }

    private void FixedUpdate()
    {
        if (b_inStart)
        {            
            if (Input.GetKey(KeyCode.Space))
            {
                //speedIncrease += 1.0f;
                speeder = 10.0f;

                GetForce(speeder);

                rigid.AddForce(StartImpulse, ForceMode.Impulse);
                //speedIncrease = 0f;
            }

            //if (Input.GetKeyUp(KeyCode.Space))
            //{
            //    speeder = 150.0f;
                    
            //    GetForce(speeder);

            //    //Debug.Log("Key was released, speeder is: " + speeder);
            //    //Debug.Log("The Impulse Vector was: " + StartImpulse);

            //    rigid.AddForce(StartImpulse, ForceMode.Impulse);
            //    speedIncrease = 0f;
            //}
        }
    }

    void GetForce(float multiplier)
    {
        StartImpulse = Vector3.forward * multiplier;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "StartArea")
        {
            b_inStart = true;
        }
        else
        {
            b_inStart = false;
        }
    }
}
