using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    [SerializeField] Vector3 heading;
    [SerializeField] Vector3 direction;
    [SerializeField] float distanceToTarget;
    GameObject target;

    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    private void Update()
    {
        CalculateDirection();

        gameObject.transform.position += direction * Time.deltaTime * 100;
    }

    private void CalculateDirection()
    {
        if (target == null) return;
        heading = target.transform.position - transform.position;
        distanceToTarget = heading.magnitude;
        direction = heading / distanceToTarget;
        gameObject.transform.rotation = Quaternion.LookRotation(direction);
    }

    public void SetTarget(GameObject Target)
    {
        target = Target;
    }
}
