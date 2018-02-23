using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlacement3 : MonoBehaviour {

    public GameObject saw, slime, zombie;
    [Range(0.0f, 1.0f)]
    float rnd;

    public void PlaceEnemy(Vector2 cords)
    {
        float rnd = Random.value;

        if (rnd < 0.2f)
        {
            Instantiate(saw, new Vector3(cords.x, cords.y + 1, -1), Quaternion.identity);
        }
        else if (rnd >= 0.2f && rnd < 0.4f){
            Instantiate(slime, new Vector3(cords.x, cords.y + 1, -1), Quaternion.identity);
        }
        else
        {
            Instantiate(zombie, new Vector3(cords.x, cords.y + 1.15f, -1), Quaternion.identity);
        }
    }
}
