using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Tools/Dialogue", order = 1)]
public class Dialogue : ScriptableObject {
    public string speaker;
    public string text;
    public Object requiredItem;

    public bool? IsDialogueSucceeded() {
        
        return false;
    }

    public bool? IsItemInInventory() {

        return false;
    }
}