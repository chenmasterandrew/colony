using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureInstance : MonoBehaviour
{
    [SerializeField] private Transform[] animalSpawns;
    [HideInInspector] public Structure config;
    [HideInInspector] public StructureDirection direction;
    [HideInInspector] public int row;
    [HideInInspector] public int col;
    [HideInInspector] public (int, int)[] occupied;
    [HideInInspector] public HashSet<AnimalInstance> animals;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(Structure structure, StructureDirection direction, int row, int col, (int, int)[] occupied, AnimalData[] animals)
    {
        config = structure;
        this.direction = direction;
        this.row = row;
        this.col = col;
        this.occupied = occupied;
        if (animals != null)
        {
            foreach (AnimalData data in animals)
            {
                SpawnAnimal(data);
            }
        }
        switch (direction)
        {
            case StructureDirection.West:
                transform.Rotate(Vector3.up * 90);
                break;
            case StructureDirection.North:
                transform.Rotate(Vector3.up * 180);
                break;
            case StructureDirection.East:
                transform.Rotate(Vector3.up * 270);
                break;
        }
    }

    public void SpawnAnimal(AnimalData data)
    {
        if (animals.Count < config.animalLimit)
            return;

        Animal animal = AnimalManager.Instance.typeToAnimal[data.type];

        GameObject go = Instantiate(animal.prefab);
        // go.transform.position = animalSpawn.position;
        AnimalInstance ai = go.GetComponent<AnimalInstance>();
        ai.Setup(animal, data.displayName, data.daysUnfed);
    }

    public void SpawnAnimal(AnimalType type)
    {

    }
}
