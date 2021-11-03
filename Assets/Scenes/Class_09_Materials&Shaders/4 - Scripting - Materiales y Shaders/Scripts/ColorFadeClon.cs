using UnityEngine;

public class ColorFadeClon : MonoBehaviour
{
	public Color fromColor = Color.black;
	public Color toColor = Color.white;
	[Range(0.1f, 10f)]
	public float speed = 1;

	private new Renderer renderer;

	void Start()
	{
		renderer = GetComponent<Renderer>();
	}

	void Update()
	{
		Color color = GetTweenColor();
		renderer.material.SetColor("_Color", color);
	}

	Color GetTweenColor()
	{
		float completePercent = (Mathf.Sin(Time.time * speed) + 1) * 0.5f; // desde 0 a 1 en vez de 0 a 2
		Color toReturn = Color.Lerp(fromColor, toColor, completePercent);
		return toReturn;
	}
}
