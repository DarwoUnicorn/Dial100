using UnityEditor;

[CustomEditor(typeof(LevelParameters))]
public class GameParametersEditor : Editor
{
    private LevelParameters _parameters;

    private void OnEnable()
    {
        _parameters = (LevelParameters)target;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        DrawDefaultInspector();
        EditorGUI.BeginChangeCheck();
        DrawFieldMap();
        if(EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(_parameters);
        }
    }

    private void DrawFieldMap()
    {
        if(_parameters.Field.Map == null)
        {
            return;
        }
        EditorGUILayout.BeginHorizontal();
        for(int i = 0; i < _parameters.Field.Map.Length; i++)
        {
            EditorGUILayout.BeginVertical();
            for(int j = _parameters.Field.Map[i].Length - 1; j >= 0; j--)
            {
                Undo.RecordObject(_parameters, "Change Field Map");
                _parameters.Field.Map[i][j] = EditorGUILayout.Toggle(_parameters.Field.Map[i][j]);
            }
            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndHorizontal();
    }
}
