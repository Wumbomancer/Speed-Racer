using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

    public float speed;
	public float rotationSpeed;
	public GameObject DriftCar;
	public Text countText;
	public Text winText;
    private Rigidbody rb;
	private int count;
	
	
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
		winText.text = "";
		DriftCar.SetActive(true);
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
		float gas = Input.GetAxis("Gas")* (-1);
		bool cancel = Input.GetButtonDown ("Exit");
		if (cancel == true)
		{
			Application.Quit();
		}
		Vector3 straight = new Vector3 (0.0f,0.0f,gas);
        //Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		Vector3 rotation = new Vector3 (0.0f, moveHorizontal, 0.0f);
		transform.Rotate(rotation*rotationSpeed*gas);
        //rb.AddForce (movement * speed);
		//rb.MovePosition(transform.position+straight);
		rb.AddRelativeForce(straight *speed);
    }
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText();
		}
		
	}
	
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		if (count >= 12)
		{
			winText.text = "You Win";
		}
	}
}