using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CampaignWindow : EditorWindow {

    public static void Open(in Campaign campaign) {
        var window = (CampaignWindow)EditorWindow.GetWindow<CampaignWindow>();
        window.Show();
        /*
            TODO:
            initialize values from argument object
        */
    }

    private void OnGUI() {
        GUILayout.Label("Campaign Editor", EditorStyles.boldLabel);
        /*

        */
    }
}
