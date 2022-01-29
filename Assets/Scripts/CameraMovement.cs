class CameraMovement {
	Transform p1Transform;
	Transform p2Transform;
	[Range(0.0f,1.0f)]
	public float p2Strength;
	
	void Awake() {
	
	}
	
	void Start() {
		// @TODO: Replace temp call names
		p1Transform = GameObject.Find("Player1");
		p2Transform = GameObject.Find("Player2");	
	}
	
	void Update() {	
		Camera.Main.Transform.position = new Vecctor3(0.0f, Mathf.Lerp(p1Transform.position.y, p2Transform.position.y, p2Strength, Camera.Main.Transform.position.z);
	}
}