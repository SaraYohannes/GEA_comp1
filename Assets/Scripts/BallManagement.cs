using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManagement : MonoBehaviour
{
    // When we start level we want to have three balls
    // if ball is destoryed, remove a ball from counter and add next ball on field
    [SerializeField] public int LifeCounter;
    [SerializeField] public GameObject playerBall;
    private Rigidbody rigid;
    private void Awake()
    {
        LifeCounter = 5;
        rigid = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            LifeCounter --;

            if (LifeCounter != 0)
            {
                //spawn new ball
                Debug.Log("A new ball is spawned in the pit");
                SpawnBall();
            }
            else
            {
                //game over
                Debug.Log("There are no more Lives left! Game over!");
                
            }
        }
    }

    private void SpawnBall()
    {
        GameObject player = Instantiate(playerBall);
    }
}
