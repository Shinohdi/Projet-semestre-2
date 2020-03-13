using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimCamera : MonoBehaviour
{

    [SerializeField] private GameObject target;
    [SerializeField] private float rotateSpeed;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var hor = Input.GetAxis("Mouse X") * rotateSpeed;
        target.transform.Rotate(0, hor, 0);

        var desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position - (rotation * offset);

        transform.LookAt(target.transform);
    }

   
}
