using UnityEngine;
using UnityEditor;

namespace Wokarol.NavMesh2D
{
    [CustomEditor(typeof(NavMesh2DBaker))]
    public class NavMesh2DBakerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            //EditorGUILayout.HelpBox("Editor works :v", MessageType.Info);

            if (GUILayout.Button("Bake 2D")) {
                var baker = target as NavMesh2DBaker;
                baker.Bake();
            }
        }
    } 
}