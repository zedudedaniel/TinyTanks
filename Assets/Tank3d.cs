using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank3d : MonoBehaviour
{
    // Start is called before the first frame update

    public TankData tankData;
    public MoveCode moveCode;
    //public string moveAiName;
    public Color color;

    //public int HumanCount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //moveCode.SetDestination(gameObject);
        doStuff( gameObject );
    }

    private static void doStuff(GameObject obj)
    {
        Tank3d tank = obj.GetComponent<Tank3d>();
        tank.moveCode.SetDestination(obj);
    }
}
