using DunGen;
using DunGen.Adapters;
using UnityEngine;
using UnityEngine.AI;

    [RequireComponent(typeof(NavMeshSurface))]
    public class NavMeshGeneratorAdapter : NavMeshAdapter
    {
        private NavMeshSurface navMeshSurface;

        private static bool isDone;

        public static bool IsDone
        {
            get { return isDone; }
        }

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
