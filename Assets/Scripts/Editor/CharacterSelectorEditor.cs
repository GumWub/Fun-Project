using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    private string[] _characterNames;
    private string[] _environmentNames;

    private void OnEnable()
    {
        RebuildNameArrays();
    }

    private void RebuildNameArrays()
    {
        GameManager gm = (GameManager)target;

        if (gm.CharacterDB != null)
        {
            _characterNames = new string[gm.CharacterDB.characterAttributes.Count];
            for (int i = 0; i < _characterNames.Length; i++)
                _characterNames[i] = gm.CharacterDB.characterAttributes[i].Name;
        }

        if (gm.EnvironmentDB != null)
        {
            _environmentNames = new string[gm.EnvironmentDB.EnvironmentProperties.Count];
            for (int i = 0; i < _environmentNames.Length; i++)
                _environmentNames[i] = gm.EnvironmentDB.EnvironmentProperties[i].Name;
        }
    }

    public override void OnInspectorGUI()
    {
        GameManager gm = (GameManager)target;

        serializedObject.Update();
        DrawDefaultInspector();

        GUILayout.Space(20f);
        GUILayout.Label("Current Data", EditorStyles.boldLabel);

        EditorGUI.BeginChangeCheck();

        if (gm.CharacterDB != null && _characterNames != null)
        {
            gm.CurrentCharacterIndex = EditorGUILayout.Popup(
                "Selected Character",
                gm.CurrentCharacterIndex,
                _characterNames
            );
        }

        if (gm.EnvironmentDB != null && _environmentNames != null)
        {
            gm.CurrentEnvironmentIndex = EditorGUILayout.Popup(
                "Selected Environment",
                gm.CurrentEnvironmentIndex,
                _environmentNames
            );
        }

        if (EditorGUI. EndChangeCheck())
        {
            Undo.RecordObject(gm, "Changed GameManager Selection");

            if (Application.isPlaying)
            {
                gm.HandleCharacterSelection(gm.CurrentCharacterIndex);
                gm.HandleEnvironmentSelection(gm.CurrentEnvironmentIndex);
            }

            EditorPrefs.SetInt("CurrentCharacterIndex", gm.CurrentCharacterIndex);
            EditorPrefs.SetInt("CurrentEnvironment", gm.CurrentEnvironmentIndex);

            EditorUtility.SetDirty(gm);
        }

        serializedObject.ApplyModifiedProperties();
    }
}