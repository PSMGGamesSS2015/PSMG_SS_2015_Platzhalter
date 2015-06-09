using UnityEngine;
using System.Collections;

public class GorillaBossScript : MonoBehaviour {

	public Vector3 targetPosition;
	public float moveSpeed;
	
	void Start()
	{
		StartCoroutine(MoveToPosition(targetPosition));
	}
	
	IEnumerator MoveToPosition(Vector3 target)
	{
		while (transform.position != target)
		{
			transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
			yield return 0;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
