using UnityEditor;
using UnityEngine;

    public class AutoBoundsWindow : EditorWindow 
    {
   

        [MenuItem("Window/Gizmos/Auto Bounds")]
        static void Init()
        {
            AutoBoundsWindow window = (AutoBoundsWindow)EditorWindow.GetWindow(typeof(AutoBoundsWindow));
            window.Show();
        }

        void OnGUI()
        {
            GUILayout.Label("Color Settings", EditorStyles.boldLabel);
            AutoBounds.GizmosColor = EditorGUILayout.ColorField("Gizmos Color", AutoBounds.GizmosColor);
            EditorGUILayout.Space();

            AutoBounds.GizmosColor.a = 255;

            GUILayout.Label("Visible Settings", EditorStyles.boldLabel);
            AutoBounds.GizmosVisible = EditorGUILayout.Toggle("Gizmos Visible", AutoBounds.GizmosVisible);
            EditorGUILayout.Space();
        }

    }


