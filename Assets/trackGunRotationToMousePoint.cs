using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackGunRotationToMousePoint : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        Vector3 aimDirection3 = (mousePosition - transform.position).normalized;
        Vector2 aimDirection = aimDirection3;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation; //Set the rotation
    }
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vec.z = 0f;
        //Debug.Log(vec);
        return vec;

    }
}
