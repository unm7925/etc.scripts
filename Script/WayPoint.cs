using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] Npc npcPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable {  get { return isPlaceable; } }
    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlaced = npcPrefab.CreateNpc(npcPrefab, transform.position);
            isPlaceable = !isPlaced;
        }
    }
}
