using UnityEditor;
using UnityEngine.AI;
using UnityEditor.AI;
using UnityEngine;
namespace AI.Editor
{
    [CustomEditor(typeof(AISettings))]
    public class AISettingsEditor : UnityEditor.Editor
    {
        private SerializedProperty agentType;

        public const float diagramHeight = 200f;

        private void OnEnable()
        {
            agentType = serializedObject.FindProperty("agentTypeID");
        }

        public override void OnInspectorGUI()
        {
            AISettings Target = (AISettings)target;
            var bs = NavMesh.GetSettingsByID(agentType.intValue);

            if (bs.agentTypeID != -1)
            {

                Rect agentDiagramRect = EditorGUILayout.GetControlRect(false, diagramHeight);
               UnityEditor.AI.NavMeshEditorHelpers.DrawAgentDiagram(agentDiagramRect, bs.agentRadius, bs.agentHeight, bs.agentClimb, bs.agentSlope);
            }
            NavMeshComponentsGUIUtility.AgentTypePopup("Agent Type", agentType);
            ShowInfo(Target);
            ObjectFields(Target,bs);
        }

        private void ShowInfo(AISettings settings)
        {
           
            var bs = NavMesh.GetSettingsByID(agentType.intValue);
            settings.CalculateStopingDistance(bs.agentRadius);
            EditorGUILayout.Space();
            GUILayout.Label("AI Informations", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Radius: " + bs.agentRadius);
            EditorGUILayout.LabelField("Height: " + bs.agentHeight);
            EditorGUILayout.LabelField("Max Slope: " + bs.agentSlope);
            EditorGUILayout.LabelField("Step Height: " + bs.agentClimb);
            EditorGUILayout.Space();
            GUILayout.Label("AI Base Statistic", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("AI Stop Distance: " + settings.StopDistance);
            EditorGUILayout.LabelField("AI Maximum Speed: " + settings.AgentMaxSpeed);
            EditorGUILayout.LabelField("AI Target Name: " + settings.Target.name);
            GUILayout.Label("AI Statistic Objects Fileds", EditorStyles.boldLabel);
        }

        private void ObjectFields(AISettings settings,NavMeshBuildSettings agentSettings)
        {
            
            settings.StopDistance = settings.CalculateStopingDistance(agentSettings.agentRadius);
            settings.AgentMaxSpeed = EditorGUILayout.FloatField( "Agent Max Speed",settings.AgentMaxSpeed);
            settings.Target = EditorGUILayout.ObjectField("Target Player",settings.Target,typeof(Transform),false) as Transform;
            
        }
    }
}
