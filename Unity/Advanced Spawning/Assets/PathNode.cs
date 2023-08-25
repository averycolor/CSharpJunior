using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
    [SerializeField] private PathNode _next;

    public PathNode GetNext()
    {
        if (_next == null)
        {
            throw new System.InvalidOperationException("Attempt to get the next node's position from a terminating node");
        } 
        else
        {
            return _next;
        }
    }
}
