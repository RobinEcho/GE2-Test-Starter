using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NematodeSchool : MonoBehaviour
{
    public GameObject prefab;

    [Range (1, 5000)]
    public int radius = 50;
    
    public int count = 10;


    Constrain Limit;
    GameObject Nematode;

    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i < count; i++)
        {
            Nematode = Instantiate(prefab);
            Limit = Nematode.gameObject.transform.GetChild(0).gameObject.AddComponent<Constrain>();
            Limit.center = transform.position;
            Limit.radius = radius;
            Nematode.gameObject.transform.GetChild(0).gameObject.GetComponent<NoiseWander>().weight = (float)Nematode.transform.childCount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
