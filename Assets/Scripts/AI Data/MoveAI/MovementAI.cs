using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class MovementAI: MonoBehaviour
{
    //public int t;
    public virtual Vector2 decideMovement()
    {
        return new Vector2(0, 0);
    }
}
