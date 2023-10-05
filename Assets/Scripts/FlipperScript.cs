using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FlipperScript : MonoBehaviour
{
    /*
     * This is the flipper animation control thing 
     */

    [SerializeField] public AnimationCurve curve;
    private Rigidbody rigidb;
    private float timer;
    private Quaternion start_rot;
    [SerializeField] public bool right;

    private void Start()
    {
        start_rot = transform.rotation;
        rigidb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (right == true && Input.GetKey(KeyCode.RightArrow))
        {
            timer = 0;
        }
        else if (right != true && Input.GetKey(KeyCode.LeftArrow))
        {
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (right == true)
        {
            rigidb.MoveRotation(start_rot * Quaternion.Euler(0, curve.Evaluate(timer) * -45f, 0));

        }
        else if (right != true)
        {
            rigidb.MoveRotation(start_rot * Quaternion.Euler(0, curve.Evaluate(timer) * 45f, 0));

        }
    }
}
