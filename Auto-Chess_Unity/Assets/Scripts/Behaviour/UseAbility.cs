using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAbility : AIBehaviour
{
    public override void DoAction()
    {
        thisUnit.TakeMana();

        Debug.Log(gameObject + "Cast Ability");
    }
}
