using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Node", menuName = "Graph/Node", order = 0)]
public class Node_SO : ScriptableObject
{
    public string NodeName;
    public int NumberOfNuts;
    public int Distance;
    public Node_SO Parent;
    public bool NoParent;
}
