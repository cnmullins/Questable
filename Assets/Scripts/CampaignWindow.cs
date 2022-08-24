using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UI;

public class CampaignWindow : EditorWindow {
    private const float LINE_THICKNESS = 0.5f;
    private const float GRID_DENSITY = 75f;

    private Color BACKGROUND_COLOR  { get {
        var color = Color.black;
        color.a = 0.5f;
        return color;
    } }
    private Color LINE_COLOR => Color.gray;
    private static List<Node> _nodes = new List<Node>();
    private static GUIStyle _nodeStyle;
    private static Campaign _camp;
    private static int _questIndex;
    private static Quest _viewing;
    private static bool _unfolded;

    private void OnEnable() {
        _camp = CampaignEditor.myObject;
        _questIndex = 0;
        _viewing = null;
        _unfolded = true;
    }

    private void OnGUI() {
        GUI.skin = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Game);
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical(
            GUILayout.MinWidth(position.width * 0.15f),
            GUILayout.MaxWidth(position.width * 0.45f)
        );

        _unfolded = EditorGUILayout.Foldout(_unfolded, "Show All Quests");
        if (_unfolded && _camp.quests.Length > 0) {
            string[] titles = _camp.quests.Select(q => q.title).ToArray();
            //if (_camp.quests.Length > 0) {
                //titles = _camp.quests.Select(q => q.title).ToArray();
            //}
            _questIndex = EditorGUILayout.Popup(_questIndex, titles);
            _viewing = _camp.quests[_questIndex];
            //open foldout
            _viewing.title = EditorGUILayout.TextField("Title:", _viewing.title);
            _viewing.description = EditorGUILayout.TextField("Description:", _viewing.description);
            _viewing.reward = EditorGUILayout.TextField("Reward:", _viewing.reward);
            //view dialogue
        }
        GUILayout.EndVertical();
        GUILayout.Space(position.width * 0.25f);
        if (GUILayout.Button("Add New Quest", GUILayout.ExpandWidth(false))) {
            _camp.AddNewQuest();
        }
        if (GUILayout.Button("Create New Node", GUILayout.ExpandWidth(false))) {
            ConstructNode();
        }
        //GUILayout.Space(500);
        if (GUILayout.Button("Save Quest", GUILayout.ExpandWidth(false))) {
            Debug.Log("WIP: Saving Quest to Campaign.");
            _camp.SaveData(_nodes.ToArray(), _viewing); //what quest are we currently viewing?
        }
        GUILayout.EndHorizontal();

        //TODO: create space for side tool bar
        Rect gridSpace = new Rect(
            (_unfolded) ? 0.45f * position.width : 0, 
            50, 
            position.width,
            position.height
        );

        _DrawGrid(gridSpace);
        _DrawNodes(gridSpace);
        /*

        */
        if (hasFocus) {
            //Vector2 mousePos = MouseEventBase<Vector2>.localMousePosition;
            //Debug.Log("mousePos: " + mousePos);
        }
        if (GUI.changed) {
            Repaint();
            //_camp.SaveData(_nodes.ToArray());
        }
    }

    public static void Init(in Campaign campaign) {
        //initialize
        if (campaign.quests.Length > 0) {
            _viewing = campaign.quests[0];
        }
        _nodeStyle = new GUIStyle();
        _nodeStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/node1.png") as Texture2D;
        _nodeStyle.border = new RectOffset(12, 12, 12, 12);
        _camp = campaign;
        //open
        var window = (CampaignWindow)EditorWindow.GetWindow(typeof(CampaignWindow));
        window.Show();
    }

    public void ConstructNode() {
        //construct rect
        Vector2 center = rootVisualElement.layout.center;
        Rect rect = new Rect(center.x, center.y, 100f, 50f);
        //draw on center of screen
        Node node = new Node(rect);
        node.Draw(_nodeStyle);
        //add to list of nodes
        _nodes.Add(node);
    }

    private void _DrawGrid(in Rect drawSpace) {
        Rect horLine = new Rect(drawSpace.x, GRID_DENSITY + drawSpace.y, drawSpace.width, LINE_THICKNESS);
        Rect vertLine = new Rect(GRID_DENSITY + drawSpace.x, drawSpace.y, LINE_THICKNESS, drawSpace.height);
        float n = Mathf.Max(Mathf.Floor(drawSpace.width), Mathf.Floor(drawSpace.height));

        EditorGUI.DrawRect(drawSpace, BACKGROUND_COLOR);

        for (float i = 0; i < n; i += GRID_DENSITY) {
            //float spacer = i * GRID_DENSITY;
            bool thicker = ((i/GRID_DENSITY) % 5 == 0); // divide i by grid density?
            Rect tempRect;
            if (i < drawSpace.x + drawSpace.width) {
                tempRect = horLine;
                EditorGUI.DrawRect(tempRect, LINE_COLOR);
                horLine.y += i;
            }
            if (i < drawSpace.y + drawSpace.height) {
                tempRect = vertLine;
                EditorGUI.DrawRect(tempRect, LINE_COLOR);
                vertLine.x += i;
            }
        }
    }

    private void _DrawNodes(in Rect drawSpace) {
        if (_nodes.Count == 0) return;
        foreach (var node in _nodes) {
            if (!drawSpace.Overlaps(node.rect)) continue;
            node.Draw(_nodeStyle);
        }
    }
}
