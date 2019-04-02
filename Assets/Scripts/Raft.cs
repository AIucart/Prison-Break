using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raft : Pickup
{
    public int partNumber;

    protected override Item CreateItem()
    {
        return new RaftItem(objectName, weight, partNumber);
    }
}