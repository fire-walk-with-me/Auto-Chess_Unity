using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] Transform camera;

    private void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Transform>();
    }
    private void LateUpdate()
    {
        transform.LookAt(transform.position + camera.forward);
    }
}
