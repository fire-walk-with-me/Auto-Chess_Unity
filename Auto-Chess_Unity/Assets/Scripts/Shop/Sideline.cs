using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Sideline : MonoBehaviour
{
    [SerializeField] List<GameObject> sidelines = new List<GameObject>();
    [SerializeField] List<GameObject> spawnpoints = new List<GameObject>();
    PlayerHuman player;
    UIManager uiManager;
    const int maxSidelineSize = 6;
    Vector3 pos;
    Quaternion rot;

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerHuman>().GetComponent<PlayerHuman>();
        uiManager = GameObject.FindObjectOfType<UIManager>().GetComponent<UIManager>();
        pos = transform.position;
        rot = transform.rotation;
    }

    private void Update()
    {
      transform.position = pos;
      transform.rotation = rot;
    }

    public List<GameObject> Sidelines() => sidelines;

    public bool SpaceOnBench()
    {
        if (sidelines.Count >= maxSidelineSize) return false;

        return true;
    }

    public void SetSidelineInactive()
    {
        foreach (GameObject unit in sidelines)
        {
            unit.GetComponent<Unit>().SetInactive();
        }
    }

    public void InstanciateUnit(GameObject unit, StatRandomizer statRan)
    {
        Instantiate(unit);
        unit.gameObject.transform.position = spawnpoints[sidelines.Count].transform.position;
        unit.GetComponent<Unit>().SetInactive();
        unit.GetComponent<Stats>().SetStats(statRan.GetMaxHealth(), statRan.GetMaxMana(), statRan.GetManaRegen(), statRan.GetAttack(), statRan.GetAttackSpeed(), statRan.GetAttackDistance(), statRan.GetDefence());
        sidelines.Add(unit);
    }

    public void PutUnitOnBench(GameObject unit)
    {
        sidelines.Add(unit);
    }

    public void RemoveUnitFromSideline(GameObject unit)
    {
        if (!sidelines.Contains(unit)) return;
        sidelines.Remove(unit);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MoveWithMouse>())
        {
            MoveWithMouse mwm = collision.gameObject.GetComponent<MoveWithMouse>();

            if (SpaceOnBench())
            {
                mwm.GetComponent<Unit>().PlaceUnitOnSideLine();
                gameObject.transform.position = spawnpoints[sidelines.Count].transform.position;
                sidelines.Add(collision.gameObject);
            }
            else
            {
                mwm.PlaceBack();
            }
        }
    }
}
