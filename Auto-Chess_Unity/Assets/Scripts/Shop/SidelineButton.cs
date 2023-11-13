using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SidelineButton : MonoBehaviour
{
    [SerializeField] GameObject UnitOnButton;
    TMP_Text tmpt;

    private void Start()
    {
        tmpt = gameObject.GetComponentInChildren<TMP_Text>();
    }

    public void SetName()
    {
        if(UnitOnButton != null)
        {
            tmpt.text = UnitOnButton.GetComponent<Unit>().UnitName();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void SetUnitOnButton(GameObject unit)
    {
        UnitOnButton = unit;
    }

    public void RemoveUNitOnButton()
    {
        UnitOnButton = null;
    }
}
