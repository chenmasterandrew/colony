using UnityEngine;

[CreateAssetMenu(fileName = "Animal", menuName = "ScriptableObjects/Animal")]
public class Animal : ScriptableObject
{
    // type of the animal
    public AnimalType type;
    // prefab that is instantiated when the animal is created
    public GameObject prefab;
    // amount it costs to buy this animal;
    public int buyPrice;
    // days the animal can survive without food
    public int starveDays;
    // the item that this animal produces
    public Item product;
}
