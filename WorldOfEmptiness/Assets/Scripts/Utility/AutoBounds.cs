using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DunGen;
using UnityEngine;

public sealed class AutoBounds : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position,UnityUtil.CalculateObjectBounds(gameObject,false,false,false).size);
    }
}
