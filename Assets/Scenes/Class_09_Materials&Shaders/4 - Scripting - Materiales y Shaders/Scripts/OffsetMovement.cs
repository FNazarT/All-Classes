using UnityEngine;

public class OffsetMovement : MonoBehaviour
{
	public Vector2 moveSpeed;
	private new Renderer renderer;

	Vector2 offset;

	private void Start()
	{
		renderer = GetComponent<Renderer>();
	}

	void Update()
	{
		offset.x += moveSpeed.x * Time.deltaTime;
		offset.y += moveSpeed.y * Time.deltaTime;

		renderer.material.SetTextureOffset("_MainTex", offset);
	}
}
