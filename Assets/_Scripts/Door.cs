using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace _Scripts
{
	public class Door : MonoBehaviour, IInteractable
	{
		public bool isLocked;
		public bool isPin;
		public string solution = "1234";
		public  Canvas canvas;
		public  Canvas storyCanvas;
		public  string storyTextMain;
		public  string storyTextSub;
		private Animator _animator;
		private readonly string _openAnimationName = "DoorOpen";
		private readonly string _closeAnimationName = "DoorClose";
		private FPSController _player;
    
		// ReSharper disable Unity.PerformanceAnalysis
		public void Interact(FPSController player)
		{
			_player = player;
			if (!isLocked)
			{
				_animator = gameObject.transform.parent.gameObject.GetComponent<Animator>();
				_animator.ResetTrigger("close");
				if (_animator.GetCurrentAnimatorStateInfo(0).IsName(_openAnimationName))
				{
					_animator.ResetTrigger("open");
					_animator.SetTrigger("close");
				} 
				else if (_animator.GetCurrentAnimatorStateInfo(0).IsName(_closeAnimationName))
				{
					_animator.ResetTrigger("close");
					_animator.SetTrigger("open");
				}
				else
				{
					_animator.ResetTrigger("close");
					_animator.SetTrigger("open");
				}
			}

			if (isPin && isLocked)
				EnableCanvas();

			if (!isPin && isLocked)
			{
				storyCanvas.gameObject.SetActive(true);
				storyCanvas.transform.Find("TextMain").GetComponent<TextMeshProUGUI>().text = storyTextMain;
				storyCanvas.transform.Find("TextSub").GetComponent<TextMeshProUGUI>().text = storyTextSub;
			}
		}

		private void Update()
		{
			if (isPin && canvas.gameObject.activeSelf && Input.GetButtonDown("Cancel"))
				DisableCanvas();
		}

		private void DisableCanvas()
		{
			canvas.gameObject.SetActive(false);
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			_player.canMove = true;
			canvas.transform.Find("InputField").gameObject.GetComponent<TMP_InputField>().text = "";
		}
		
		private void EnableCanvas()
		{
			canvas.gameObject.SetActive(true);
			Cursor.visible = true;
			_player.canMove = false;
			Cursor.lockState = CursorLockMode.None;
		}
		
		public void OnButtonClick()
	    {
		    Debug.Log(canvas.transform.Find("InputField").gameObject.GetComponent<TMP_InputField>().text);
	        if (canvas.transform.Find("InputField").gameObject.GetComponent<TMP_InputField>().text == solution)
	        {
		        isLocked = false;
		        DisableCanvas();
		        
	        }
	    }
	}
	
	[CustomEditor(typeof(Door))] 
	public class DoorEditor : Editor
	{
	    public override void OnInspectorGUI()
	    {
	        Door door = (Door)target;
	        
			door.isLocked = GUILayout.Toggle(door.isLocked, "Is Locked");
			door.isPin = GUILayout.Toggle(door.isPin, "Is PIN");

			if (door.isPin)
			{
				GUILayout.BeginHorizontal();
				GUILayout.Label("Solution");
				door.solution = GUILayout.TextField(door.solution);
				GUILayout.EndHorizontal();
				
				GUILayout.BeginHorizontal();
				GUILayout.Label("Canvas");
				door.canvas = (Canvas)EditorGUILayout.ObjectField(door.canvas, typeof(Canvas), true);
				GUILayout.EndHorizontal();
			}
			if (door.isLocked && !door.isPin)
			{
				GUILayout.BeginHorizontal();
				GUILayout.Label("Story Canvas");
				door.storyCanvas = (Canvas)EditorGUILayout.ObjectField(door.storyCanvas, typeof(Canvas), true);
				GUILayout.EndHorizontal();
				
				GUILayout.BeginHorizontal();
				GUILayout.Label("Story Canvas Text");
				door.storyTextMain = EditorGUILayout.TextField(door.storyTextMain);
				GUILayout.EndHorizontal();
				
				GUILayout.BeginHorizontal();
				GUILayout.Label("Story Canvas Sub Text");
				door.storyTextSub = EditorGUILayout.TextField(door.storyTextSub);
				GUILayout.EndHorizontal();
			}
			
	    }
	}
}