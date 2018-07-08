using DunGen;
using UnityEngine;

    public sealed class AutoBounds : MonoBehaviour
    {
        public static bool GizmosVisible;
        public static Color GizmosColor;

        private void OnDrawGizmos()
        {
            if (GizmosVisible)
            {
                Gizmos.color = GizmosColor;
                Gizmos.DrawCube(UnityUtil.CalculateObjectBounds(gameObject,false,false,false).center,UnityUtil.CalculateObjectBounds(gameObject,false,false,false).size);
            }
        }
    }

