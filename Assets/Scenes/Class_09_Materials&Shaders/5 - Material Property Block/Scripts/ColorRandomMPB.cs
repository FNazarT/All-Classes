using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRandomMPB : MonoBehaviour
{
	private new Renderer renderer;
	private MaterialPropertyBlock block;

	void Start()
	{
		renderer = GetComponent<Renderer>();
		block = new MaterialPropertyBlock();
	}

	void Update()
	{
		Color color = GetRandomColor();
		block.SetColor("_Color", color);
		renderer.SetPropertyBlock(block);
	}

	Color GetRandomColor()
	{
		Color toReturn = new Color();
		toReturn.r = Random.Range(0f, 1f);
		toReturn.g = Random.Range(0f, 1f);
		toReturn.b = Random.Range(0f, 1f);
		toReturn.a = 1;
		return toReturn;
	}
}
