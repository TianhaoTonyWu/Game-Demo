using UnityEngine;
using System.Collections;
public interface Character
{
    int mp {get; set;}
    int ap {get; set;}
    int health {get; set;}
    void Attack();
}