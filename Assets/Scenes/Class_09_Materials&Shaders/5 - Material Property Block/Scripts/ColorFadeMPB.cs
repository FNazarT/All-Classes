using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFadeMPB : MonoBehaviour
{
	public Color fromColor = Color.black;
	public Color toColor = Color.white;
	[Range(0.1f, 10f)]
	public float speed = 1;

	private new Renderer renderer;
	private MaterialPropertyBlock block;

	void Start()
	{
		renderer = GetComponent<Renderer>();
		block = new MaterialPropertyBlock();
	}

	void Update()
	{
		Color color = GetTweenColor();
		block.SetColor("_Color", color);
		renderer.SetPropertyBlock(block);
	}

	Color GetTweenColor()
	{
		float completePercent = (Mathf.Sin(Time.time * speed) + 1) * 0.5f; // desde 0 a 1 en vez de 0 a 2
		Color toReturn = Color.Lerp(fromColor, toColor, completePercent);
		return toReturn;
	}
}
