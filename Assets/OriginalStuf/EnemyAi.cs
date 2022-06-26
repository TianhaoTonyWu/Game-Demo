using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class EnemyAi : MonoBehaviour
{
    public HexGrid grid;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChasePlayer(Enemy enemy)
    {
        grid.ClearPath();
        HexUnit target = null;

        foreach(HexUnit unit in grid.units)
        {
            // Not enenmy
            if (unit.gameObject.GetComponent<Enemy>() == null)
            {
                target = unit;
                break;
            }
        }
        if(target)
        {
            List<int> indices = target.Location.GetDirectionsWithNeighbor();
            int randomIndex = Random.Range(0,indices.Count);
            HexCell destination = target.Location.GetNeighbor((HexDirection) indices[randomIndex]);
            HexCell departure = enemy.Location;
            if (destination != departure && enemy.IsValidDestination(destination)){
                grid.FindPath(departure, destination, 24);

                List<HexCell> path = grid.GetPath(departure, destination);
                enemy.Travel(path, target.Location);
            }
        }
    }

    public void SomeoneGoChase()
    {
        List<Enemy> enemies = new List<Enemy>();
        foreach(HexUnit u in grid.units)
        {
            if (u is Enemy)
            {
                enemies.Add((Enemy) u);
            }
        }
        int index = Random.Range(0,enemies.Count);
        ChasePlayer(enemies[index]);
    }
}*/
