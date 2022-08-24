using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
using UnityEditor.UI;
using Object = UnityEngine.Object;

public class Node {
    private const float CONNECT_SIZE = 10f;
    public Rect rect;
    public string name;
    public bool isNew { get; private set; }

    //public Vector2 inPos => new Vector2(rect.x - (rect.width/2f), rect.y);
    public Rect inRect { get {
        return new Rect(rect.x, rect.y + (rect.height/3f), CONNECT_SIZE, CONNECT_SIZE);
    } }
    //public Vector2 outPos => new Vector2(rect.x + (rect.width/2f), rect.y);
    public Rect outRect { get {
        return new Rect(rect.x + rect.width, rect.y, CONNECT_SIZE, CONNECT_SIZE);
    } }
    //public Vector2 outPos => new Vector2(rect.x + (rect.width/2f), rect.y);

    public List<Node.Connector> inConnectors;
    public List<Node.Connector> outConnectors;

    public Node(Rect sizePos, Object data=null) {
        isNew = false;
        rect = sizePos;
        inConnectors = new List<Node.Connector>();
        outConnectors = new List<Node.Connector>();
        if (data == null) {
            name = "New Node";
            isNew = true;
        }
    }

    public void Drag(in Vector2 move) {
        rect.position += move;
    }

    public void Draw(in GUIStyle style) {
        GUI.Box(rect, name, style);
        //left button
        if (GUI.Button(inRect, "<")) {
            Debug.Log("left button hit");
        }
        //right button
        if (GUI.Button(outRect, ">")) {
            Debug.Log("right button hit");
        }
        //draw all connection points and connections
        if (inConnectors.Count > 0) {
            inConnectors.ForEach((Node.Connector c) => { c.Draw(); });
        }
        if (outConnectors.Count > 0) {
            outConnectors.ForEach((Node.Connector c) => { c.Draw(); });
        }
    }

    #region ConnectorClass
    public class Connector {
        public int branch = 0; // default branch
        public Rect rect;
        public string startingConnection; // "in" or "out"
        public Node inNode;
        public Node outNode;

        public Connector(Node startNode, bool isIn, int branchNum) {
            branch = branchNum;
            if (isIn) {
                inNode = startNode;
                return;
            }
            outNode = startNode;
        }

        public void Draw() {
            Handles.DrawBezier(
                outNode.outRect.position,
                inNode.inRect.position,
                outNode.outRect.position + Vector2.left * 50f,
                inNode.inRect.position - Vector2.left * 50f,
                Settings.NODE_CONNECTOR_COLORS[branch],
                null, 
                3f
            );
        }
    }
    #endregion
}
