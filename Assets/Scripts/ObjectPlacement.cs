using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacement : MonoBehaviour {

	public GameObject box, sign, rock, cactus, coin;

    void Start()
    {
        Time.timeScale = 1;
    }

    public void PlaceObject(Vector2 cords, bool isEnemy) {
		float rnd = Random.value;

		if (rnd < 0.2f) {
			if (isEnemy == false) {
				Instantiate (box, new Vector3 (cords.x, cords.y + 1f, 1f), Quaternion.identity);
			} else {
				Instantiate (cactus, new Vector3 (cords.x, cords.y + 1.42f, 1f), Quaternion.identity);
			}
		}

		if (rnd >= 0.2f && rnd < 0.3f) {
			Instantiate (sign, new Vector3 (cords.x, cords.y + 1f, 1f), Quaternion.identity);
		}
		if (rnd >= 0.3f && rnd < 0.6f) {
			Instantiate (rock, new Vector3 (cords.x, cords.y + 1f, 1f), Quaternion.identity);
		}
		if (rnd >= 0.6f && rnd < 0.8f) {
			Instantiate (cactus, new Vector3 (cords.x, cords.y + 1.42f, 1f), Quaternion.identity);
		}
		if (rnd >= 0.8f) {
			Instantiate (cactus, new Vector3 (cords.x, cords.y + 1.42f, 1f), Quaternion.identity);
		}
	}

	public void PlaceCoin(Vector2 cords, int amount, int start){
		for (int a = 0; a < amount; a++) {
			Instantiate (coin, new Vector3 ((cords.x + start) + a, cords.y + 1, 0), Quaternion.identity);
		}
	}
}
