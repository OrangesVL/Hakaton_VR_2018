using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
	public GameObject plane;
	public GameObject wall;
	public int[,] mapArray = {
		{0, 0, 0},
		{1, 1, 0},
		{0, 0, 0}
	};

    // Use this for initialization
    void Start () {
		if (plane == null || wall == null) {
			return;
		}

		Vector3 position = transform.position;
		for (int i = 0; i < mapArray.GetLength(0); i++) {
			position.x += 1;
			position.z = transform.position.z;

			for (int j = 0; j < mapArray.GetLength(1); j++) {
				position.z += 1;
				if (mapArray[i,j] == 0) {
					Instantiate(plane, position, Quaternion.identity, this.transform);
				}
				else if (mapArray[i,j] == 1) {
					Instantiate(wall, position, Quaternion.identity, this.transform);
				}
				position.z += 0.1f;
			}

			position.x += 0.1f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
