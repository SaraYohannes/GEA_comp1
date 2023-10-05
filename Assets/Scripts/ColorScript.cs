using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScript : MonoBehaviour
{
    [SerializeField] public GameUI emptyGUI;
    [SerializeField] public Material YellowMaterial;
    [SerializeField] public Material GreenMaterial;
    [SerializeField] public Material BlueMaterial;
    [SerializeField] public Material BaseMaterial;
    [SerializeField] public GameObject Player;
    private MeshRenderer meshRenderer;
    private Rigidbody rigid;
    bool b_hi;
    private float timer;

    private void Start()
    {
        b_hi = false;
        // rigid = Player.GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        //meshRenderer.material = meshRenderer.materials[0];
    }
    private void Update()
    {
        if (b_hi)
        {
            Debug.Log("b_hi is true");
            timer += 1f * Time.deltaTime;
            if (timer > 2)
            {
                Debug.Log("b_hi is now false and new material should be applied");
                b_hi = false;
                meshRenderer.material = BaseMaterial;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            b_hi = true;
            Debug.Log("The thing which hit was a Player!");
            ColourChanger();
            //AddSpeeding(other);
        }
    }

    private void ColourChanger()
    {
        if (this.tag == "Yellow")
        {
            emptyGUI.currentPointsCounter();

            meshRenderer.material = YellowMaterial;
        }
        if (this.tag == "Green")
        {
            emptyGUI.currentPointsCounter();

            meshRenderer.material = GreenMaterial;
        }
        if (this.tag == "Blue")
        {
            emptyGUI.currentPointsCounter();

            meshRenderer.material = BlueMaterial;
        }
    }

    private void AddSpeeding(Collider other)
    {
        Vector3 StartImpulse = Vector3.forward * 15.0f;

        rigid.AddForce(StartImpulse, ForceMode.Impulse);
    }
}
