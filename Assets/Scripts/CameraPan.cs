using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    [SerializeField] private Transform tr;
    [SerializeField] private Transform mainCamera;

    [SerializeField] float upper;
    [SerializeField] float lower;

    private void Start()
    {
        mainCamera = GameObject.Find("CM vcam1").GetComponent<Transform>().transform;
        tr = GetComponent<Transform>().transform;
    }

    private void Update()
    {
        if(Input.GetAxisRaw("Mouse ScrollWheel") > 0 && mainCamera.position.y <= upper)
        {
            tr.position = new Vector3(tr.position.x, tr.position.y + 100 * Time.deltaTime, tr.position.z);
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0 && mainCamera.position.y >= lower)
        {
            tr.position = new Vector3(tr.position.x, tr.position.y - 100 * Time.deltaTime, tr.position.z);
        }
    }

}
