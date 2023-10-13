using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementNode : MonoBehaviour
{
    [SerializeField] bool occupied;
    [SerializeField] Material activeMaterial;
    [SerializeField] List<Material> materialList = new List<Material>();
    [SerializeField] RoundManager roundManager;
    Vector3 position;

    private void Start()
    {
        occupied = false;
        SetOpaque();
        position = transform.position;
        position.y = 1.1f;
    }

    private void Update()
    { 
        if (occupied) activeMaterial = materialList[1];
        else activeMaterial = materialList[0];

        if(roundManager.ActiveRound()) SetTransparant();
        else SetOpaque();

        gameObject.GetComponent<Renderer>().material = activeMaterial;
    }

    public void ChangeOccupied()
    {
        occupied = !occupied;
    }

    public void SetTransparant()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    public void SetOpaque()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}
