using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;
/*
public struct Quest {
    PlayerTask[] tasks;
}
*/
[System.Serializable]
[CreateAssetMenu(fileName = "Campaign", menuName = "Tools/Campaign", order = 0)]
public class Campaign : ScriptableObject {
    public Object[] quests => _quests;
    public Object[] achievements => _achievements;
    public Settings config => _config;

    [SerializeField] private Object[] _quests;
    [SerializeField] private Object[] _achievements;
    [SerializeField] private Settings _config;

    public bool ValidateProgress(in string quest, in string task) {

        return false;
    }
}

#if UNITY_EDITOR

[CustomEditor(typeof(Campaign))]
public class CampaignEditor : Editor {
    Campaign myObject;

    private void OnEnable() {
        myObject = (Campaign)target;
    }
    
    public override void OnInspectorGUI() {
        //display overview data
        EditorGUILayout.LabelField("Quests:", myObject.quests.Length.ToString());
        EditorGUILayout.LabelField("Achievements:", myObject.achievements.Length.ToString());

        EditorGUILayout.Space();
        //button for displaying complex editor window
        if (GUILayout.Button("View Campaign")) {

            Debug.Log("You hit the editor window");
            CampaignWindow.Open(myObject);

        }

    }
}

#endif