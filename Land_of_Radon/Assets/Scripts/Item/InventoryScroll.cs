using UnityEngine;

public class InventoryScroll : MonoBehaviour
{
    public GameObject[] items;  // Eine Liste von Objekten, die in deinem Inventar enthalten sind
    public Transform hand;  // Die Position, an der das ausgew�hlte Objekt in der Hand des Spielers platziert wird

    private int selectedItem = 0;  // Der aktuell ausgew�hlte Slot im Inventar

    private void Start()
    {
        // W�hle das erste Objekt im Inventar aus, wenn das Skript gestartet wird
        SelectItem(selectedItem);
    }

    private void Update()
    {
        // Scrolle durch die Inventarslots, wenn das Mausrad gedreht wird
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            if (scroll > 0)
            {
                // Wenn das Mausrad nach oben gedreht wird, gehe zum vorherigen Slot
                selectedItem--;
                if (selectedItem < 0)
                {
                    // Wenn das Ende des Inventars erreicht ist, gehe zur�ck zum letzten Slot
                    selectedItem = items.Length - 1;
                }
            }
            else if (scroll < 0)
            {
                // Wenn das Mausrad nach unten gedreht wird, gehe zum n�chsten Slot
                selectedItem++;
                if (selectedItem > items.Length - 1)
                {
                    // Wenn das Ende des Inventars erreicht ist, gehe zur�ck zum ersten Slot
                    selectedItem = 0;
                }
            }
            // Aktualisiere das ausgew�hlte Objekt im Inventar
            SelectItem(selectedItem);
        }
    }

    private void SelectItem(int index)
    {
        // Setze das ausgew�hlte Objekt in die Hand des Spielers
        for (int i = 0; i < items.Length; i++)
        {
            if (i == index)
            {
                // Wenn das aktuelle Objekt ausgew�hlt wurde, zeige es an und positioniere es in der Hand des Spielers
                items[i].SetActive(true);
                items[i].transform.position = hand.position;
                items[i].transform.parent = hand;
            }
            else
            {
                // Wenn das aktuelle Objekt nicht ausgew�hlt wurde, deaktiviere es und setze es wieder in das Inventar
                items[i].SetActive(false);
                items[i].transform.parent = transform;
            }
        }
    }
}
