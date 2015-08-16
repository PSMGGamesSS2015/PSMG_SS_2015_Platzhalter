using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]
public class EnemyAI : MonoBehaviour {

	public Transform target;

	public float updateRate = 2f;
	private Seeker seeker;
	private Rigidbody2D rb2d;

	public Path path;

	private float speed = 1000f;
	public ForceMode2D fMode;

	[HideInInspector]
	public bool pathIsEnded = false;

	public float nextWaypointDistance = 3;
	private int currentWaypoint = 0;

	void Start()
	{
		seeker = GetComponent<Seeker> ();
		rb2d = GetComponent<Rigidbody2D> ();

		if (target == null) {
			Debug.LogError("No Player found.");
			return;
		}

		seeker.StartPath (transform.position, target.position, onPathComplete);

		StartCoroutine (UpdatePath());
	}

	IEnumerator UpdatePath(){
		if (target == null) {
			return false;
		}
		seeker.StartPath (transform.position, target.position, onPathComplete);
		yield return new WaitForSeconds (1f / updateRate);
		StartCoroutine (UpdatePath ());
	}

	public void onPathComplete(Path p){
		Debug.Log ("We got a path:" + p.error);
		if (!p.error) {
			path = p;
			currentWaypoint = 0;
		}
	}

	void FixedUpdate(){
		if (target == null) {
			return;
		}
		if (path == null) {
			return;
		}
		if (currentWaypoint >= path.vectorPath.Count) {
			if(pathIsEnded)
				return;
			Debug.Log ("End of path reached.");
			pathIsEnded = true;
			return;
		}
		pathIsEnded = false;
		Vector3 dir = (path.vectorPath [currentWaypoint] - transform.position).normalized;
		dir *= speed * Time.fixedDeltaTime;

		rb2d.AddForce (dir,fMode);
		float dist = Vector3.Distance (transform.position, path.vectorPath [currentWaypoint]);
		if (dist < nextWaypointDistance) {
			currentWaypoint++;
			return;
		}
	}

}
