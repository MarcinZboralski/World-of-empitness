using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControler : MonoBehaviour
{
	List<KeyCode> myKeys = new List<KeyCode>();
	const string debuglogInfo = "User pressed: ";
	void Start()
	{
		#region WSAD
		myKeys.Add (KeyCode.A);
		myKeys.Add (KeyCode.W);
		myKeys.Add (KeyCode.S);
		myKeys.Add (KeyCode.D);
		#endregion

		#region Arrows
		myKeys.Add (KeyCode.UpArrow);
		myKeys.Add (KeyCode.DownArrow);
		myKeys.Add (KeyCode.LeftArrow);
		myKeys.Add (KeyCode.RightArrow);
		#endregion

		#region 1-0 Up
		myKeys.Add (KeyCode.Alpha0);
		myKeys.Add (KeyCode.Alpha1);
		myKeys.Add (KeyCode.Alpha2);
		myKeys.Add (KeyCode.Alpha3);
		myKeys.Add (KeyCode.Alpha4);
		myKeys.Add (KeyCode.Alpha5);
		myKeys.Add (KeyCode.Alpha6);
		myKeys.Add (KeyCode.Alpha7);
		myKeys.Add (KeyCode.Alpha8);
		myKeys.Add (KeyCode.Alpha9);
		#endregion

		#region 1-0 Side
		myKeys.Add (KeyCode.Keypad0);
		myKeys.Add (KeyCode.Keypad1);
		myKeys.Add (KeyCode.Keypad2);
		myKeys.Add (KeyCode.Keypad3);
		myKeys.Add (KeyCode.Keypad4);
		myKeys.Add (KeyCode.Keypad5);
		myKeys.Add (KeyCode.Keypad6);
		myKeys.Add (KeyCode.Keypad7);
		myKeys.Add (KeyCode.Keypad8);
		myKeys.Add (KeyCode.Keypad9);
		#endregion

		#region F1-F12
		myKeys.Add (KeyCode.F1);
		myKeys.Add (KeyCode.F2);
		myKeys.Add (KeyCode.F3);
		myKeys.Add (KeyCode.F4);
		myKeys.Add (KeyCode.F5);
		myKeys.Add (KeyCode.F6);
		myKeys.Add (KeyCode.F7);
		myKeys.Add (KeyCode.F8);
		myKeys.Add (KeyCode.F9);
		myKeys.Add (KeyCode.F10);
		myKeys.Add (KeyCode.F11);
		myKeys.Add (KeyCode.F12);
		#endregion

		#region Q-P
		myKeys.Add (KeyCode.Q);
		myKeys.Add (KeyCode.E);
		myKeys.Add (KeyCode.R);
		myKeys.Add (KeyCode.T);
		myKeys.Add (KeyCode.Y);
		myKeys.Add (KeyCode.U);
		myKeys.Add (KeyCode.I);
		myKeys.Add (KeyCode.O);
		myKeys.Add (KeyCode.P);
		#endregion

		#region F-L
		myKeys.Add (KeyCode.F);
		myKeys.Add (KeyCode.G);
		myKeys.Add (KeyCode.H);
		myKeys.Add (KeyCode.J);
		myKeys.Add (KeyCode.K);
		myKeys.Add (KeyCode.L);
		#endregion

		#region Z-M
		myKeys.Add (KeyCode.Z);
		myKeys.Add (KeyCode.X);
		myKeys.Add (KeyCode.C);
		myKeys.Add (KeyCode.V);
		myKeys.Add (KeyCode.B);
		myKeys.Add (KeyCode.N);
		myKeys.Add (KeyCode.M);
		#endregion

		#region OTHERS
		myKeys.Add(KeyCode.Escape);
		#endregion
	}

	void Update () 
	{
		foreach (KeyCode keyCode in myKeys) 
		{
			if (Input.GetKey (keyCode)) 
			{
				switch (keyCode)
				{
				#region WSAD
				case KeyCode.A:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.W:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.S:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.D:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				#endregion

				#region Arrows
				case KeyCode.UpArrow:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.DownArrow:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.LeftArrow:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.RightArrow:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				#endregion

				#region 1-0 Up
				case KeyCode.Alpha0:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.Alpha1:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.Alpha2:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.Alpha3:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.Alpha4:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.Alpha5:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.Alpha6:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.Alpha7:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.Alpha8:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.Alpha9:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				#endregion
				
				#region 1-0 Side
				case KeyCode.Keypad0:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.Keypad1:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.Keypad2:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.Keypad3:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.Keypad4:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.Keypad5:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.Keypad6:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.Keypad7:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.Keypad8:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.Keypad9:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				#endregion

				#region F1-F12
				case KeyCode.F1:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.F2:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.F3:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.F4:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.F5:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.F6:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.F7:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.F8:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.F9:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.F10:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.F11:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.F12:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				#endregion

				#region Q-P
				case KeyCode.Q:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.E:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.R:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.T:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.Y:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.U:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.I:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.O:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.P:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				#endregion

				#region F-L
				case KeyCode.F:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.G:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.H:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.J:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.K:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.L:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				#endregion

				#region Z-M
				case KeyCode.Z:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.X:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.C:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.V:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.B:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.N:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				case KeyCode.M:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				#endregion

				#region OTHERS
				case KeyCode.Escape:
					Debug.Log(debuglogInfo + keyCode.ToString());
					break;
				#endregion
				}
			}
		}
	}
}
