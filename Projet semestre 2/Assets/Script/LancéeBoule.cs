using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancéeBoule : MonoBehaviour
{

    [SerializeField] private float coolDown;

    [SerializeField] private float forceLancée;

    [SerializeField] private GameObject camPlayer;
    [SerializeField] private GameObject boulePre;
    [SerializeField] private GameObject bouleParent;


    [SerializeField] private Transform main;


    private GameObject newBoule;

    private bool enJoue;
    private Rigidbody RB;
    private float countDown;

    // Start is called before the first frame update
    void Start()
    {
        enJoue = true;
        newBoule = GameObject.Find("Boule");
        RB = newBoule.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enJoue)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RB.isKinematic = false;
                newBoule.transform.parent = bouleParent.transform;
                RB.AddForce(camPlayer.transform.forward * forceLancée);
                enJoue = false;
                
            }
        }
        else
        {
            countDown += Time.deltaTime;

            if(countDown >= coolDown)
            {
                newBoule = Instantiate(boulePre, main.position, transform.rotation, transform);
                RB = newBoule.GetComponent<Rigidbody>();
                RB.isKinematic = true;
                enJoue = true;
                countDown = 0;
            }
        }

       
    }
}
