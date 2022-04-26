using UnityEditor;

[CustomEditor(typeof(FieldParameters), true)] [CanEditMultipleObjects()]
public class FieldParametersEditor : Editor
{
    private FieldParameters _parameters;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        DrawDefaultInspector();
        EditorGUI.BeginChangeCheck();
        if(targets.Length == 1)
        {
            DrawFieldMap();
        }
        if(EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(_parameters);
        }
    }

    private void DrawFieldMap()
    {
        if(_parameters.Map == null)
        {
            return;
        }
        EditorGUILayout.BeginHorizontal();
        for(int i = 0; i < _parameters.Map.Length; i++)
        {
            EditorGUILayout.BeginVertical();
            for(int j = _parameters.Map[i].Length - 1; j >= 0; j--)
            {
                Undo.RecordObject(_parameters, "Change Field Map");
                _parameters.Map[i][j] = EditorGUILayout.Toggle(_parameters.Map[i][j]);
            }
            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndHorizontal();
    }

    private void OnEnable()
    {
        _parameters = (FieldParameters)target;
    }
}
