using UnityEditor;

[CustomEditor(typeof(GameParameters))]
public class GameParametersEditor : Editor
{
    private GameParameters _gameParameters;

    private void OnEnable()
    {
        _gameParameters = (GameParameters)target;
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
            EditorUtility.SetDirty(_gameParameters);
        }
    }

    private void DrawFieldMap()
    {
        EditorGUILayout.BeginHorizontal();
        for(int i = 0; i < _gameParameters.FieldMap.Length; i++)
        {
            EditorGUILayout.BeginVertical();
            for(int j = _gameParameters.FieldMap[i].Length - 1; j >= 0; j--)
            {
                Undo.RecordObject(_gameParameters, "Change Field Map");
                _gameParameters.FieldMap[i][j] = EditorGUILayout.Toggle(_gameParameters.FieldMap[i][j]);
            }
            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndHorizontal();
    }
}
