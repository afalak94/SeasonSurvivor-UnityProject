using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlacement2 : MonoBehaviour {

    public GameObject saw, slime, shroom;
    [Range(0.0f, 1.0f)]
    float rnd;

    public void PlaceEnemy(Vector2 cords)
    {
        float rnd = Random.value;

        if (rnd < 0.3f)
        {
            Instantiate(saw, new Vector3(cords.x, cords.y + 1, -1), Quaternion.identity);
        }
        else if (rnd >= 0.3f && rnd < 0.7f){
            Instantiate(slime, new Vector3(cords.x, cords.y + 1, -1), Quaternion.identity);
        }
        else
        {
            Instantiate(shroom, new Vector3(cords.x, cords.y + 1.15f, -1), Quaternion.identity);
        }
    }
}
