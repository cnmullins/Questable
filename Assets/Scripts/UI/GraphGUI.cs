/*
using UnityEditor;


private UnityEditor.Graphs.Graph graph;
private NodeEditorGUI nodeEditorGUI;
public class NodeEditorGUI : UnityEditor.Graphs.GraphGUI {

    private void OnEnable() {
        graph = CreateInstance<UnityEditor.Graphs.Graph>();
        nodeEditorGUI = CreateInstance<NodeEditorGUI>();
        nodeEditorGUI.graph = graph;
    }

    private void OnGUI() {
        nodeEditorGUI.BeginGraphGUI(this, new Rect(0f, 0f, position.width, position.height));
        nodeEditorGUI.EndGraphGUI();
    }
}
*/