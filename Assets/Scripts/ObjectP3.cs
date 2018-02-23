using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectP3 : MonoBehaviour
{

    public GameObject rock, bush, tree, coin, skeleton, tombStone, cross;

    void Start()
    {
        Time.timeScale = 1;
    }

    public void PlaceObject(Vector2 cords, bool isEnemy)
    {
        float rnd = Random.value;

        if (rnd < 0.2f)
        {
                Instantiate(cross, new Vector3(cords.x, cords.y + 1.52f, 1f), Quaternion.identity);
        }

        if (rnd >= 0.2f && rnd < 0.3f)
        {
            Instantiate(tombStone, new Vector3(cords.x, cords.y + 1f, 1f), Quaternion.identity);
        }
        if (rnd >= 0.3f && rnd < 0.45f)
        {
            Instantiate(rock, new Vector3(cords.x, cords.y + 1f, 1f), Quaternion.identity);
        }
        if (rnd >= 0.45f && rnd < 0.6f)
        {
            Instantiate(skeleton, new Vector3(cords.x, cords.y + 0.8f, 1f), Quaternion.identity);
        }
        if (rnd >= 0.6f && rnd < 0.8f)
        {
            Instantiate(bush, new Vector3(cords.x, cords.y + 1.42f, 1f), Quaternion.identity);
        }
        if (rnd >= 0.8f)
        {
            Instantiate(tree, new Vector3(cords.x, cords.y + 2.7f, 1f), Quaternion.identity);
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
