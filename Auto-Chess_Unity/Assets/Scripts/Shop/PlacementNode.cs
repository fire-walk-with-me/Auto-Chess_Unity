using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementNode : MonoBehaviour
{
    [SerializeField] bool occupied;
    [SerializeField] Material activeMaterial;
    [SerializeField] List<Material> materialList = new List<Material>();
    [SerializeField] RoundManager roundManager;
    [SerializeField] Color hoverColor;
    Vector3 position;
    Renderer rend;
    GameObject unitPlaced;
    
    Color startColor;

    private void Start()
    {
        occupied = false;
        SetOpaque();
        position = transform.position;
        position.y = 1.1f;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void Update()
    {
        //if (occupied)
        //{
        //    activeMaterial = materialList[1];
        //    rend.material = activeMaterial;
        //    startColor = rend.material.color;
        //}
        //else
        //{
        //    activeMaterial = materialList[0];
        //    rend.material = activeMaterial;
        //    startColor = rend.material.color;
        //}

        if (roundManager.ActiveRound()) SetTransparant();
        else SetOpaque();
    }

    private void OnMouseDown()
    {
        if (unitPlaced != null) return;

        
    }

    private void OnMouseEnter()
    {
        if (occupied) return;

        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
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
