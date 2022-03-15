using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExampleMoveCode", menuName = "MoveCode")]
public class MoveCode : ScriptableObject
{
    public virtual void SetDestination(GameObject GM)
    {
        return;
    }
}
