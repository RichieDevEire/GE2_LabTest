using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpawner : MonoBehaviour 
{
	public GameObject eagle;
	public float gap = 20f;
	public int followers = 2;

	// Use this for initialization
	void Awake () 
	{
		for (int i = 0; i < followers; i++){
			float angle = i * Mathf.PI * 2 / followers;
			Vector3 pos = new Vector3(Mathf.Cos(angle),0, Mathf.Sin(angle)) * gap;
			Instantiate(eagle, pos, Quaternion.identity);
			}
		}
	}
