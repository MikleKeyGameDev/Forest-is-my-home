using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Cell> _cells;

    public bool SortingItems(ItemSO item)
    {
        if(item.IsQuatitative == true)
        {
            if(AddToCellQuatitative(item) == true)
            {
                return true;
            }
            else
            {
                if(AddVoidCell(item) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        else
        {
            if (AddVoidCell(item) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private bool AddVoidCell(ItemSO item)
    {
        for (int i = 0; i < _cells.Count; i++)
        {
            if (_cells[i].AddToVoid(item) == true)
            {
                return true;
            }
        }

        return false;
    }

    private bool AddToCellQuatitative(ItemSO item)
    {
        for (int i = 0; i < _cells.Count; i++)
        {
            if (_cells[i].AddToQuatitative(item) == true)
            {
                return true;
            }
        }

        return false;
    }
}
