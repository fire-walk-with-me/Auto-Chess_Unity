using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellUnitNode : MonoBehaviour
{
    [SerializeField] Sideline sideline;
    [SerializeField] PlayerHuman human;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<MoveWithMouse>())
        {
            sideline.RemoveUnitFromSideline(other.gameObject);
            human.RemoveFromActiveUnits(other.gameObject);

            Destroy(other.gameObject);

            human.IncreaseGold(2);
        }
    }
}
