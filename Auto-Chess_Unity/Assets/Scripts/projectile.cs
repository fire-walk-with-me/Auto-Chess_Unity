using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements.Experimental;

public class projectile : MonoBehaviour
{
    GameObject targetUnit;
    Vector3 heading;
    Vector3 direction;
    float distanceToTarget;
    bool shot;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        if (shot)
        {
            gameObject.transform.position += direction * Time.deltaTime * 10;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == targetUnit) Destroy(gameObject);
    }

    public void ShootTarget(GameObject target)
    {
        targetUnit = target;
        CalculateDirection();
        shot = true;
    }

    private void CalculateDirection()
    {
        heading = targetUnit.transform.position - transform.position;
        distanceToTarget = heading.magnitude;
        direction = heading / distanceToTarget;
    }
}
