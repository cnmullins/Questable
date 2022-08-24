using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SettingsObject", menuName = "Tools/Dialogue", order = 2)]
public class Settings : ScriptableObject {
    public Object uiBackground;
    public Object uiButton;
    public Font baseFont;
    public Font titleFont;
    public bool uiEscape;
    public Object goodEventAudio; // ??
    public Object badEventAudio;// ??

    public static Color[] NODE_CONNECTOR_COLORS => new Color[] {
        Color.red,
        Color.green,
        Color.blue,
        Color.yellow,
        Color.black,
        Color.white,
        Color.gray,
        Color.magenta,
        Color.cyan,
    };
    /*
    vars
        UI Background
        UI Button
        Font
        Custom key or UI button?
        Audio for events
    */
}
