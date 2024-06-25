using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper
{
    public static bool CheckPlayerRange (Vector3 position, float range) {
        return Physics.CheckSphere(position, range, LayerMask.GetMask("Player"));
    }
}
