using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DefaultExecutionOrder(-1)]
public class DayManager : MonoBehaviour
{
    // singleton instance
    public static DayManager Instance;

    public int day;
    public Transform directionalLightPivot;

    [HideInInspector] public UnityEvent OnEndDay;

    [HideInInspector] public int time = 0;

    private DataManager dm;
    private InventoryManager im;
    private StructureManager sm;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        dm = DataManager.Instance;
        im = InventoryManager.Instance;
        sm = StructureManager.Instance;
        day = dm.gameData.day;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndDay()
    {
        OnEndDay.Invoke();
        day += 1;
        int money = im.money;
        ItemData[] id = im.Serialize();
        StructureData[] sd = sm.Serialize();
        dm.UpdateData(day, money, id, sd);
        dm.Save();
    }
}
