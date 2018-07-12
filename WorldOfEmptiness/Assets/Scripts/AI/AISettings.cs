using System;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    [Serializable][CreateAssetMenu(fileName = "NewAISettings",menuName = "Assets/AI/Create AI Data")]
    public class AISettings : ScriptableObject
    {
        public AIType AiType;
        public string Name;
        public int agentTypeID;
        public Transform Target;
        public float AgentMaxSpeed;
        [NonSerialized] public float StopDistance;
        [NonSerialized] public NavMeshAgent Agent;

        public AIStatistic AiStatistic;

        public AISettings(AIType aiType, string name, int agentTypeID, Transform target, float agentMaxSpeed, AIStatistic aiStatistic)
        {
            AiType = aiType;
            Name = name;
            this.agentTypeID = agentTypeID;
            Target = target;
            AgentMaxSpeed = agentMaxSpeed;
            AiStatistic = aiStatistic;
        }

        public void Init(NavMeshAgent agent)
        {
            Agent = agent;
            if (Name == null)
            {
                Name = Agent.name;
            }

            if (AgentMaxSpeed < 0)
            {
                AgentMaxSpeed = Agent.speed;
            }

            if (StopDistance <= 0)
            {
                StopDistance = CalculateStopingDistance(Agent.radius);
            }
        }

        public float CalculateStopingDistance(float agentRadius)
        {
            return agentRadius * 2.5f + 0.3f;
        }

    }
}
