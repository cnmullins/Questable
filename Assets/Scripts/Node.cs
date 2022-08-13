using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;

public class Node {
    public Rect rect;
    public string name;

    public GUIStyle style;

    public List<Node> initNodes;
    public List<Node> resultNodes;

    public Node (Rect sizePos, Object data, GUIStyle nodeStyle) {
        rect = sizePos;
        style = nodeStyle;
    }

    public void Drag(in Vector2 move) {
        rect.position += move;
    }

    public void Draw() {
        GUI.Box(rect, name, style);
    }
}
