using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Node", menuName = "Graph/Node", order = 0)]
public class Node_SO : ScriptableObject
{
    [SerializeField] private string _nodeName;
    public string NodeName { get => _nodeName; set => _nodeName = value; }

    [SerializeField] private int _numberOfNuts;
    public int NumberOfNuts { get => _numberOfNuts; set => _numberOfNuts = value; }

    [SerializeField] private int _distance;
    public int Distance { get => _distance; set => _distance = value; }
}
