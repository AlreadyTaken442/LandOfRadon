using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
{

    public Sprite lootSprite;
    public string lootname;
    public int dropChance;

    public Loot(string lootName, int dropChance)
    {
        this.lootname = lootName;
        this.dropChance = dropChance;
    }
}
