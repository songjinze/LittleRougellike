using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    public Player player;
    private Transform transform;
	// Use this for initialization
	void Start () {
        transform = GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position+new Vector3(0,0,-1);
	}
}
