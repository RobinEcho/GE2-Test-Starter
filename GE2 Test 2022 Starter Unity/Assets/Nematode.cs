using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nematode : MonoBehaviour
{
    public int length = 5;

    public Material material;

    // use for spawn the body of nematode
    public GameObject body;
    int Core;
    float Pos = 0f, radius = 0f;


    NoiseWander Navigation;
    void Awake()
    {

        // spawn a random lenght for the nematode
        length = Random.Range(7,20);
        Core = (int)(length / 2);

        Debug.Log("core is: " + Core);


        // The head of Nematode with specific component
        GameObject BodyClone = GameObject.Instantiate<GameObject>(body);
        BodyClone.transform.SetParent(this.transform);

        // Before the biggest core spawnning, radius incease
        BodyClone.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

        // Record current radius
        radius = BodyClone.transform.localScale.x / 2;
        BodyClone.transform.position = new Vector3(Pos + radius, 0, 0);
        Navigation = BodyClone.AddComponent<NoiseWander>();
        BodyClone.AddComponent<ObstacleAvoidance>();

        // Sign a random speed
        Navigation.ChangeSpeed(Random.Range(10f,20f));


        // Spawnning
        for (int i = 1; i < length; i++)
        {
            // instantiate body and set as child of it
            BodyClone = GameObject.Instantiate<GameObject>(body);
            BodyClone.transform.SetParent(this.transform);
            
            // Before the biggest core spawnning, radius incease
            if (i < Core) {
                BodyClone.transform.localScale = new Vector3(0.2f * (i + 1), 0.2f * (i + 1), 0.2f * (i + 1));

                // Record current radius
                radius = BodyClone.transform.localScale.x / 2;

                BodyClone.transform.position = new Vector3(Pos + radius, 0, 0);
                
            }
            else
            {
                BodyClone.transform.localScale = new Vector3(0.2f * (length - i), 0.2f * (length - i), 0.2f * (length - i));

                // Record current radius
                radius = BodyClone.transform.localScale.x / 2;

                BodyClone.transform.position = new Vector3(Pos + radius, 0, 0);
            }

            // The new position is at the edge of this body part
            Pos = BodyClone.transform.position.x + radius;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
