using UnityEngine;
using TMPro;

namespace _Scripts
{
	public class Letter : MonoBehaviour, IInteractable
	{
		public Canvas canvas;
		public string text;
		public bool isButton = false;
		public FPSController _player;
    
		public void Interact(FPSController player)
		{
			canvas.transform.Find("LetterText").GetComponent<TextMeshProUGUI>().text = text;
			if (!canvas.gameObject.activeSelf)
				EnableCanvas();
			
			if (isButton)
				gameObject.transform.Find("ButtonToShowTheWall").gameObject.SetActive(true);
		}
		public void Update()
		{
			if (canvas.gameObject.activeSelf && Input.GetButtonDown("Cancel"))
				DisableCanvas();
		}
		private void DisableCanvas()
		{
			canvas.gameObject.SetActive(false);
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			_player.canMove = true;
		}
		
		private void EnableCanvas()
		{
			canvas.gameObject.SetActive(true);
			Cursor.visible = true;
			_player.canMove = false;
			Cursor.lockState = CursorLockMode.None;
		}
	}
}