using UnityEngine;

public class ColorRandomClon : MonoBehaviour
{
	private new Renderer renderer;

	void Start()
	{
		renderer = GetComponent<Renderer>();
	}

	void Update()
	{
		Color color = GetRandomColor();
		renderer.material.SetColor("_Color", color);
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
