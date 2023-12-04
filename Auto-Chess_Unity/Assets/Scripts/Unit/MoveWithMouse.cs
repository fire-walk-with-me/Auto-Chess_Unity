using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 oldObjectPos;
    Camera cam;
    float camZDistance;

    bool checkCollision;
    bool collided;

    void Start()
    {
        cam = Camera.main;
        camZDistance = cam.WorldToScreenPoint(transform.position).z;
    }
    private void OnMouseDown()
    {
        if (FindObjectOfType<RoundManager>().ActiveRound() || gameObject.tag == "Competitor") return;

        oldObjectPos = transform.position;
    }

    private void OnMouseDrag()
    {
        if (FindObjectOfType<RoundManager>().ActiveRound() || gameObject.tag == "Competitor") return;

        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 32f);

        transform.position = cam.ScreenToWorldPoint(mousePos);
    }
    private void OnMouseUp()
    {
        if (gameObject.tag == "Competitor") return;

        checkCollision = true;
        StartCoroutine(CheckCollisionWithPlacementNode());
    }

    private IEnumerator CheckCollisionWithPlacementNode()
    {
        gameObject.transform.position = new Vector3(transform.position.x, 1.3f, transform.position.z);

        yield return new WaitForSeconds(0.2f);

        if (!collided) PlaceBack();
        collided = false;
        GameInfo.Info.GetSideline().RemoveUnitFromSideline(gameObject);
    }

    public void SetCollided(bool collision)
    {
        collided = collision;
    }

    public void SetCheckCollision(bool collision)
    {
        checkCollision = collision;
    }

    public bool CheckCollision() => checkCollision;
    public void PlaceBack()
    {
        transform.position = oldObjectPos;
        collided = false;
    }
}
