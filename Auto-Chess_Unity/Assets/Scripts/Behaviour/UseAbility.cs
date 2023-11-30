using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAbility : AIBehaviour
{
    //Feel free to add spcial abilities to the champs!
    //Follow the same structure as the other behaviour scrips, e.g Attack
    //The units will automatically use the abilitiy that you add in this script!

    public override void DoAction()
    {
        thisUnit.TakeMana();

    }
}
