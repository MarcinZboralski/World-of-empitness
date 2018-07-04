using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControler : MonoBehaviour
{
	void Update () 
	{
		#region WSAD
		if (Input.GetKey (KeyCode.A))
			Debug.Log ("User used: A");
		if (Input.GetKey (KeyCode.W))
			Debug.Log ("User used: W");
		if (Input.GetKey (KeyCode.S))
			Debug.Log ("User used: S");
		if (Input.GetKey (KeyCode.D))
			Debug.Log ("User used: D");
		#endregion

		#region Arrows
		if (Input.GetKey (KeyCode.DownArrow))
			Debug.Log ("User used: DownArrow");
		if (Input.GetKey (KeyCode.UpArrow))
			Debug.Log ("User used: UpArrow");
		if (Input.GetKey (KeyCode.RightArrow))
			Debug.Log ("User used: RightArrow");
		if (Input.GetKey (KeyCode.LeftArrow))
			Debug.Log ("User used: Left Arrow");
		#endregion

		#region AlphaNumeric
		if (Input.GetKey (KeyCode.Alpha1))
			Debug.Log ("User used: 1");
		if (Input.GetKey (KeyCode.Alpha2))
			Debug.Log ("User used: 2");
		if (Input.GetKey (KeyCode.Alpha3))
			Debug.Log ("User used: 3");
		if (Input.GetKey (KeyCode.Alpha4))
			Debug.Log ("User used: 4");
		if (Input.GetKey (KeyCode.Alpha5))
			Debug.Log ("User used: 5");
		if (Input.GetKey (KeyCode.Alpha6))
			Debug.Log ("User used: 6");
		if (Input.GetKey (KeyCode.Alpha7))
			Debug.Log ("User used: 7");
		if (Input.GetKey (KeyCode.Alpha8))
			Debug.Log ("User used: 8");
		if (Input.GetKey (KeyCode.Alpha9))
			Debug.Log ("User used: 9");
		if (Input.GetKey (KeyCode.Alpha0))
			Debug.Log ("User used: 0");
		#endregion

		#region Q-P
		if (Input.GetKey (KeyCode.Q))
			Debug.Log ("User used: Q");
		if (Input.GetKey (KeyCode.E))
			Debug.Log ("User used: E");
		if (Input.GetKey (KeyCode.R))
			Debug.Log ("User used: R");
		if (Input.GetKey (KeyCode.T))
			Debug.Log ("User used: T");
		if (Input.GetKey (KeyCode.Y))
			Debug.Log ("User used: Y");
		if (Input.GetKey (KeyCode.U))
			Debug.Log ("User used: U");
		if (Input.GetKey (KeyCode.I))
			Debug.Log ("User used: I");
		if (Input.GetKey (KeyCode.O))
			Debug.Log ("User used: O");
		if (Input.GetKey (KeyCode.P))
			Debug.Log ("User used: P");
		#endregion

		#region F-L
		if (Input.GetKey (KeyCode.F))
			Debug.Log ("User used: F");
		if (Input.GetKey (KeyCode.G))
			Debug.Log ("User used: G");
		if (Input.GetKey (KeyCode.H)
			Debug.Log ("User used: H");
		if (Input.GetKey (KeyCode.J))
			Debug.Log ("User used: J");
		if (Input.GetKey (KeyCode.K))
			Debug.Log ("User used: K");
		if (Input.GetKey (KeyCode.L))
			Debug.Log ("User used: L");
		#endregion

		#region Z-M
		if (Input.GetKey (KeyCode.Z))
			Debug.Log ("User used: Z");
		if (Input.GetKey (KeyCode.X))
			Debug.Log ("User used: X");
		if (Input.GetKey (KeyCode.C))
			Debug.Log ("User used: C");
		if (Input.GetKey (KeyCode.V))
			Debug.Log ("User used: V");
		if (Input.GetKey (KeyCode.B))
			Debug.Log ("User used: B");
		if (Input.GetKey (KeyCode.N))
			Debug.Log ("User used: N");
		if (Input.GetKey (KeyCode.M))
			Debug.Log ("User used: M");
		#endregion
	}
}
