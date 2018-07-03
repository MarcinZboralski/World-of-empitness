using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

[Serializable]
public class AISettings
{
    public AIType AiType;
    public string Name;
    public float Radius;
    public float Height;
    [Range(0f,60f)]public float MaxSlope;
    public Transform Target;
    public float AgentMaxSpeed;
   [NonSerialized] public float StopDistance;

    public AISettings(AIType aiType, string name, float radius, float height, float maxSlope, float agentMaxSpeed, Transform target)
    {
        AiType = aiType;
        Name = name;
        Radius = radius;
        Height = height;
        MaxSlope = maxSlope;
        Target = target;
        AgentMaxSpeed = agentMaxSpeed;
    }

    public void Init(NavMeshAgent agent)
    {
        if (Name == null)
        {
            Name = agent.name;
        }

        if (Radius == 0)
        {
            Radius = agent.radius;
        }

        if (Height == 0)
        {
            Height = agent.height;
        }

        if (MaxSlope > 60f)
        {
            Debug.LogError("Valid Maximum MaxSlope");
            MaxSlope = 60f;
        }

        if (MaxSlope < 0f)
        {
            Debug.LogError("Valid Minimum MaxSlope");
            MaxSlope = 0f;
        }

        if (AgentMaxSpeed < 0)
        {
            AgentMaxSpeed = agent.speed;
        }

        if (StopDistance <= 0)
        {
            StopDistance = CalculateStopingDistance();
        }
    }

    public float CalculateStopingDistance()
    {
        return Radius * 2.5f + 0.3f;
    }

}
