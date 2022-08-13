using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CampaignWindow : EditorWindow {


    //[MenuItem("Window/Campaign Window")]
    public static void Init() {
        var window = (CampaignWindow)EditorWindow.GetWindow(typeof(CampaignWindow));
        window.Show();
    }

    private void OnGUI() {
        GUILayout.Label("Campaign Editor", EditorStyles.boldLabel);
    }
}
