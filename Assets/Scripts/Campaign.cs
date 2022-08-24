using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;

[System.Serializable]
[CreateAssetMenu(fileName = "Campaign", menuName = "Tools/Campaign", order = 0)]
public class Campaign : ScriptableObject {
    public Quest[] quests => _quests;
    public Object[] achievements => _achievements;
    public Settings config => _config;

    [SerializeField] private Quest[] _quests;
    [SerializeField] private Object[] _achievements; //resolve achievements through UnityEvents
    [SerializeField] private Settings _config;

    public Campaign() {
        _quests = new Quest[0];
        _achievements = new Object[0];
    }

    public bool ValidateProgress(in string quest, in string task) {

        return false;
    }

    public void AddNewQuest() {
        int count = _quests.Length;
        var questsCopy = new Quest[count + 1];
        for (int i = 0; i < count; ++i) {
            questsCopy[i] = _quests[i];
        }
        questsCopy[count] = new Quest();
        _quests = questsCopy;
    }

    public void ClearData() {
        this._quests = new Quest[0];
        this._achievements = new Object[0];
    }

    public void SaveData(Node[] nodes, Quest quest) {
        /*
        _quests.Select
        var newNodes = 
            from n in nodes
            where n.Value == quest
            select node;
        //check if nodes exist in this
        foreach (var n in nodes) {
            if (!_quests.ForEach(q => q.dialogueList.Exists(n))) {
                //now save it
                Debug.Log("saving an node");
            }
        }
        */
        Debug.Log("fix this function");
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(Campaign))]
public class CampaignEditor : Editor {
    public static Campaign myObject { get; private set; }

    private void OnEnable() {
        myObject = (Campaign)target;
        Debug.Log("hit");
    }
    
    public override void OnInspectorGUI() {
        //display overview data
        EditorGUILayout.LabelField("Quests:", myObject.quests.Length.ToString());
        EditorGUILayout.LabelField("Achievements:", myObject.achievements.Length.ToString());

        EditorGUILayout.Space();
        //button for displaying complex editor window
        if (GUILayout.Button("View Campaign")) {
            Debug.Log("You hit the editor window");
            CampaignWindow.Init(myObject);
        }
        if (GUILayout.Button("Save Current Window")) {
            //save object
            Debug.Log("Values from windows are saved");
            serializedObject.ApplyModifiedProperties();
        }
        if (GUILayout.Button("Clear Data")) {
            myObject.ClearData();
        }
    }
}
#endif