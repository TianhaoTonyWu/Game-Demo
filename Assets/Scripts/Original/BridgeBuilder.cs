using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBuilder : MonoBehaviour
{
    public GameObject bridgeSymbol;
    public GameObject hexGrid;

    /* Directions
    // 0 -> W - E
    // 1 -> NE - SW
    // 2 -> NW - SE
    */
    public int BridgeDirection {get; set;}

    // Start is called before the first frame update
    void Start()
    {
        BridgeDirection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateBridge() 
    {
        bridgeSymbol.transform.Rotate(new Vector3(0,0,60));
     
        BridgeDirection = (BridgeDirection + 1) % 3;
        Debug.Log(BridgeDirection);
        
    }

    public void BuildBridge() 
    {

    }
}
