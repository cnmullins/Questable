using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest {
    public string title;
    public string description;
    public string reward;
    public BranchingList<Dialogue> dialogueList;
    public int hash { get; private set; }

    public Quest() {
        this.title = "New Question";
        this.description = "New Description";
        this.reward = "Enter reward here";
        this.dialogueList = new BranchingList<Dialogue>();
        this.hash = Animator.StringToHash(System.DateTime.Now.ToString());
    }
}