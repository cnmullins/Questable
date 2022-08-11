using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Tools/Dialogue", order = 0)]
public class Dialogue : ScriptableObject {
    public string speaker;
    public string text;
    public Object requiredItem;

    public bool? IsDialogueSucceeded() {
        
        return false;
    }

    public bool? IsItemInInventory() {
        // I don't know is this inventory?

        return false;
    }
}
