using UnityEngine;

[CreateAssetMenu (fileName = "Food", menuName = "Food")]

public class FoodSO : ScriptableObject
{
    [SerializeField] private float _nutritionalValue;

    public float NutritionalValue { get { return _nutritionalValue; } }
}
