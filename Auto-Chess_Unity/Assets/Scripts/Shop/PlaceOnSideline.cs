using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceOnSideline : MonoBehaviour
{
    [SerializeField] Sideline sideline;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<Unit>().Active()) return;

        MoveWithMouse mwm = other.gameObject.GetComponent<MoveWithMouse>();

        if (sideline.PlaceUnitOnBench(mwm.gameObject))
        {

        }
        else
        {
            mwm.PlaceBack();
        }
    }
}
