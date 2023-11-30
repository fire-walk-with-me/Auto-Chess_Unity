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
    PlayerHuman playerHuman;
    Sideline sideline;
    Vector3 position;
    Renderer rend;
    GameObject unitPlaced;
    Color startColor;

    private void Start()
    {
        sideline = FindObjectOfType<Sideline>().GetComponent<Sideline>();
        playerHuman = FindObjectOfType<PlayerHuman>().GetComponent<PlayerHuman>();
        occupied = false;
        SetOpaque();
        position = transform.position;
        position.y = 1.2f;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void Update()
    {
        if (roundManager.ActiveRound() && !occupied) SetTransparant();
        else SetOpaque();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<MoveWithMouse>())
        {
            MoveWithMouse mwm = other.gameObject.GetComponent<MoveWithMouse>();
            if (!mwm.CheckCollision()) return;

            mwm.SetCollided(true);

            if (!occupied)
            {
                mwm.GetComponent<Unit>().PlaceUnitOnBoard(GetPosition());
            }
            else
            {
                mwm.PlaceBack();
            }

            mwm.SetCheckCollision(false);
        }
    }
    public Vector3 GetPosition() => position;
    public bool Occpied() => occupied;

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
