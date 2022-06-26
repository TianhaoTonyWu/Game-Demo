using UnityEngine;
using System.Collections;
public class Fighter : MonoBehaviour, Character 
{
    public int mp {
        get {return 100; }
        set {}
    }
    public int ap {
        get {return 100; }
        set {}
    }
    public int health {
        get {return 100; }
        set {}
    }

    public void Attack()
    {
        Debug.Log("Not implemented yet");
    }

    void Start()
    {
        
    }
}