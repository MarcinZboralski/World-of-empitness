﻿using UnityEditor;
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
        }

        private void ShowInfo(AISettings settings)
        {
            var bs = NavMesh.GetSettingsByID(agentType.intValue);
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("AI Informations");
            EditorGUILayout.LabelField("Radius: " + bs.agentRadius);
            EditorGUILayout.LabelField("Height: " + bs.agentHeight);
            EditorGUILayout.LabelField("Max Slope: " + bs.agentSlope);
            EditorGUILayout.LabelField("Step Height: " + bs.agentClimb);
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("AI Stop Distance: " + settings.StopDistance);
            EditorGUILayout.LabelField("AI Maximum Speed: " + settings.AgentMaxSpeed);

        }
    }
}
