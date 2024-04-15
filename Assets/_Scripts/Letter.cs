using UnityEngine;

namespace _Scripts
{
	public class Letter : MonoBehaviour, IInteractable
	{
		public Canvas canvas;
		private FPSController _player;
    
		public void Interact(FPSController player)
		{
			_player = player;
			if (!canvas.gameObject.activeSelf)
				EnableCanvas();
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