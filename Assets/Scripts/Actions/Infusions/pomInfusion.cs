using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pomInfusion : infusionAbstract
{
    public override void _nAttackTap()
    {
        Debug.Log("pom attack");
    }

    public override void _nAttackHold()
    {
        Debug.Log("pom attack hold");
    }

    public override void _nAttackHoldStop()
    {
        Debug.Log("pom attack hold stop");
    }
    
    public override void _eTap()
    {
        Debug.Log("pom ability tap");
    }
}
