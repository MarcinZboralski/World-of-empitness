using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    public class BaseAI : MonoBehaviour,AIAniamtor
    {
        public AISettings AISettings;

        protected NavMeshAgent Agent;

        private float distanceToTarget;


        public float DistanceToTarget
        {
            get { return distanceToTarget; }
        }

        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            AISettings.Init(Agent);
            Init();
        }

        public virtual void Init()
        {
            Agent.stoppingDistance = AISettings.StopDistance;
        }

        private void Update()
        {
            Move(AISettings.Target.position);
        }

        protected void Move(Vector3 Target)
        {
            if(NavMeshGeneratorAdapter.IsDone != true)return; 


            distanceToTarget = Vector3.Distance(Target, transform.position);

            if (distanceToTarget >= AISettings.StopDistance)
            {
                Agent.SetDestination(Target);
            }

        }

        private void OnDrawGizmos()
        {

        }

        public void SetAnimatror(bool walk, bool attack, bool death, bool hit)
        {
        
        }

        public void ResetAnimator()
        {
        
        }
    }
}
