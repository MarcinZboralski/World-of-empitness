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

        [NonSerialized] public float StopDistance;

        public AIStatistic AiStatistic;

        public AISettings(AIType aiType, string name, int agentTypeID, Transform target, AIStatistic aiStatistic)
        {
            AiType = aiType;
            Name = name;
            this.agentTypeID = agentTypeID;
            Target = target;
            AiStatistic = aiStatistic;
        }

        public void Init(NavMeshAgent agent)
        {
    
        }

        //public float CalculateStopingDistance(float agentRadius)
        //{
        //    return agentRadius * 2.5f + 0.3f;
        //}

    }
}
