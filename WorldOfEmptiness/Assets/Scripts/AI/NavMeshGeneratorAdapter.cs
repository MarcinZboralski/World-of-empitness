using System.Collections;
using System.Collections.Generic;
using DunGen;
using DunGen.Adapters;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshSurface))]
public class NavMeshGeneratorAdapter : NavMeshAdapter
{
    private NavMeshSurface navMeshSurface;

    public static bool isDone;

    void Awake()
    {
        navMeshSurface = GetComponent<NavMeshSurface>();
    }

    public override void Generate(Dungeon dungeon)
    {
        navMeshSurface.BuildNavMesh();
        isDone = true;
    }
}
