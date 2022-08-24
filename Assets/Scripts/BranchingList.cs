using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using UnityEngine;

public class BranchingList<T> : Collection<T> {
    public BranchingList<T>.Node<T> headNode { get; private set; }
    public int count => _count;
    private int _count;

    public BranchingList() {
        this.headNode = null;
        this._count = 0;
    }

    public BranchingList(T headNodeData) {
        this.headNode = new Node<T>(headNodeData);
        this._count = 1;
    }

    //public bool RemoveData(T data) {
        //this._count -= 1;
    //}

    public void AddNodeAt(T before, T data) {
        var beforeNode = _SearchFor(before, headNode);
        if (beforeNode == null) {
            throw new NullReferenceException();
        }
        beforeNode.AddBranch(new Node<T>(data));
        this._count += 1;
    }

    public Node<T> GetNodeFor(T data) {
        if (_count > 0) {
            return _SearchFor(data, headNode);
        }
        return null;
    }

    public bool Exists(T data) {
        if (_count > 0) {
            return (_SearchFor(data, headNode) != null);
        }
        return false;
    }

    //TODO: rigoursly test method below
    private static Node<T> _SearchFor(in T searching, Node<T> headNode) {
        if (headNode.data.Equals(searching)) {
            return headNode;
        }
        if (headNode == null || headNode.branches == 0) {
            return null;
        }
        for (int i = 0; i < headNode.branches; ++i) {
            Node<T> node = headNode.GetBranchAt(i);
            if (node != null) {
                return _SearchFor(searching, node);
            }
        }
        return null;
    }

    public class Node<T> : IEquatable<Node<T>> {
        public int branches => _branch.Count;
        public T data { get; private set; }
        private List<Node<T>> _branch;

        public Node() {
            this.data = default(T);
            this._branch = new List<Node<T>>();
        }

        public Node(T data) {
            this.data = data;
            this._branch = new List<Node<T>>();
        }

        public Node(T data, List<Node<T>> branch) {
            this.data = data;
            this._branch = branch;
        }
        
        public Node<T> GetBranchAt(int index) {
            if (index >= _branch.Count) {
                Debug.LogError(index + " is not a valid branch number for this node");
            }
            return this._branch[index];
        }

        public void AddBranch(Node<T> newBranch) {
            this._branch.Add(newBranch);
        }

        public bool Equals(Node<T> node) {
            return (this.data.Equals(node.data)) && (this._branch == node._branch);
        }

        public override bool Equals(object obj) {
            if (obj == null || obj.GetType() != this.GetType()) {
                return false;
            }
            return base.Equals((Node<T>)obj);
        }

        public static bool operator !=(Node<T> node1, Node<T> node2) {
            return (!node1.data.Equals(node2.data)) || (!node1._branch.Equals(node2._branch));
        }

        public static bool operator ==(Node<T> node1, Node<T> node2) {
            return (node1.data.Equals(node2.data)) && (node1._branch.Equals(node2._branch));
        }
        
        public override int GetHashCode() {
            if (this.data != null) {
                return this.data.GetHashCode();
            }
            return base.GetHashCode();
        }
    }
}
