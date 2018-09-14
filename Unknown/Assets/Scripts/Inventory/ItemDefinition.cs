using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item Definition")]
public class ItemDefinition : ScriptableObject
{

    [SerializeField]
    protected Sprite icon;

    /// <summary>
    /// Max amount of items can be placed in a stack
    /// </summary>
    [SerializeField]
    protected int maxStackAmount = 5;
    [SerializeField]
    protected GameObject prefab;
    [SerializeField]
    protected List<Recipe> recipes;

    public virtual Sprite Icon
    {
        get
        {
            return this.icon;
        }
    }

    public virtual int MaxStackAmount
    {
        get
        {
            return this.maxStackAmount;
        }
    }

    public virtual GameObject Prefab
    {
        get
        {
            return this.prefab;
        }
    }

    public virtual List<Recipe> Recipes
    {
        get
        {
            return this.recipes;
        }
    }

}

[System.Serializable]
public struct Recipe
{

    public ItemDefinition combinee;
    public ItemDefinition result;

}
