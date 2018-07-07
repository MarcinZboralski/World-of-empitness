using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DunGen;
using UnityEngine;

public sealed class AutoBounds : MonoBehaviour
{
    public bool useDebug;

    private void OnDrawGizmos()
    {
        if (useDebug)
        {
            Gizmos.color = new Color(0f, 1f, 0.22f);
            Gizmos.DrawCube(UnityUtil.CalculateObjectBounds(gameObject,false,false,false).center,UnityUtil.CalculateObjectBounds(gameObject,false,false,false).size);
        }
    }
}
