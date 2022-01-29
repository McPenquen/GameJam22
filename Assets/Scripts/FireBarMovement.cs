class FireBarMovement {
	public float speed;
	
	void Update() {
		transform.position += new Vector3(0.0f, speed, 0.0f);
	}
}