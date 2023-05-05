﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {
	AudioSource audio_src;
	public Color rayColor = Color.white;
	public List<Transform> path_objs = new List<Transform>();
	public Transform spring_origin_transform;
	public Transform spring_destination_transform;
	Transform[] theArray = new Transform[2];
	public AudioClip spring_sound_effect;
	float homing_attack_distance = 30f;

	// Use this for initialization
	void Start () {
		audio_src = GetComponent<AudioSource> ();

	}

	void OnDrawGizmos()
	{
		Gizmos.color = rayColor;
		theArray [0] = spring_origin_transform;
		theArray [1] = spring_destination_transform;
		path_objs.Clear ();
		foreach (Transform path_obj in theArray) {
			path_objs.Add (path_obj);
		}

		for (int i = 0; i < path_objs.Count; i++) {
			Vector3 pos = path_objs [i].position;
			if (i > 0) {
				Vector3 previous = path_objs [i - 1].position;
				Gizmos.DrawLine (previous, pos);
				Gizmos.DrawWireSphere (pos, 0.3f);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<SonicController> ()) {
			audio_src.PlayOneShot (spring_sound_effect);
			SonicController.Instance.initialize_spring_state ();
			SonicController.Instance.spring_target = spring_destination_transform.gameObject;
		}
	}
}
