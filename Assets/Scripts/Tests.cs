using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tests : MonoBehaviour {

	void start()
    {
        TestInventory();
    }

void TestInventory()
{
    BonusItem bonus = new BonusItem(name: "Bonus1", weight: 2f, points: 100);
    AccessItem key = new AccessItem(name: "key1", weight: 2f, door: 1);
    BonusItem anvil = new BonusItem(name: "anvil", weight: 9f, points: 900);

    Debug.Log(message: "Adding bonus success: " + Inventory.instance.AddItem(bonus));
    Debug.Log(message: "Adding key success: " + Inventory.instance.AddItem(key));
    Debug.Log(message: "");
    Debug.Log(message: "INVENTORY:");
    Inventory.instance.printToConsole();

    //Inventory.instance.removeItem(bonus);
    Debug.Log(message: "INVENTORY (after removing):");
    Inventory.instance.printToConsole();

    //Inventory.instance.removeItem(anvil);
    Debug.Log(message: "INVENTORY (after FAKE removing):");
    Inventory.instance.printToConsole();
    }
}
