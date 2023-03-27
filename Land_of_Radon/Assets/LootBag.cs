using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class lootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<Loot> lootlist = new List<Loot>();

    Loot GetDroppedItem()
    {
        int randomNumer = Random.Range(1, 101); // 1-100  (erste und letze Zahl werden nicht gewerdet.)
        List<Loot> possibleItems = new List<Loot>();
        foreach (Loot item in lootList)
        {
            if(randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
    }


    // Start is called before the first frame update
   /* void Start()
    {
       lootlist.Add(new Loot("Gem"), 80)); Das ist ein Beispiel wie es noch geht.
    }
   */
}
