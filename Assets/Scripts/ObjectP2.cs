using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectP2 : MonoBehaviour
{

    public GameObject box, sign, rock, mushroom1, mushroom2, tree, coin;

    void Start()
    {
        Time.timeScale = 1;
    }

    public void PlaceObject(Vector2 cords, bool isEnemy)
    {
        float rnd = Random.value;

        if (rnd < 0.2f)
        {
            if (isEnemy == false)
            {
                Instantiate(box, new Vector3(cords.x, cords.y + 1f, 1f), Quaternion.identity);
            }
            else {
                Instantiate(mushroom1, new Vector3(cords.x, cords.y + 1.42f, 1f), Quaternion.identity);
            }
        }

        if (rnd >= 0.2f && rnd < 0.3f)
        {
            Instantiate(sign, new Vector3(cords.x, cords.y + 1f, 1f), Quaternion.identity);
        }
        if (rnd >= 0.3f && rnd < 0.45f)
        {
            Instantiate(rock, new Vector3(cords.x, cords.y + 1f, 1f), Quaternion.identity);
        }
        if (rnd >= 0.45f && rnd < 0.6f)
        {
            Instantiate(mushroom1, new Vector3(cords.x, cords.y + 1.42f, 1f), Quaternion.identity);
        }
        if (rnd >= 0.6f && rnd < 0.8f)
        {
            Instantiate(mushroom2, new Vector3(cords.x, cords.y + 1.05f, 1f), Quaternion.identity);
        }
        if (rnd >= 0.8f)
        {
            Instantiate(tree, new Vector3(cords.x - 3f, cords.y + 0.5f, 1f), Quaternion.identity);
        }
    }

    public void PlaceCoin(Vector2 cords, int amount, int start)
    {
        for (int a = 0; a < amount; a++)
        {
            Instantiate(coin, new Vector3((cords.x + start) + a, cords.y + 1, 0), Quaternion.identity);
        }
    }
}
