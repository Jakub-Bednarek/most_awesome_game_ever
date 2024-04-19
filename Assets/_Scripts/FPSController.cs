using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public Camera playerCamera;

    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    public bool canMove;
    public bool canTeleport = false;
    public Canvas UI;
    private int cooldownTeleport;
    private int overHeatTeleport;
    private Vector3 moveDirection = Vector3.zero;
    float rotationX;
   
    //Teleport
    public float level1 = 1f;
    public float level2 = -8f;
    private bool firstLevel = true;
    private Collision collision;
     CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        if (canTeleport) 
            UI.transform.Find("TeleportAbility").gameObject.SetActive(true);
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        #region Handles Movement

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        
        #endregion
	
        #region Handles Jumping

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        #endregion

        #region Handles Rotation

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        
        #endregion

        #region Teleport

        if (Input.GetButtonDown("Teleport") && canMove && canTeleport)
        {
            cooldownTeleport = 10;
            if (firstLevel)
            { 
                TeleportToLevel(level2);
                playerCamera.gameObject.GetComponent<DotMatrixEffect>().on = true;
                playerCamera.gameObject.GetComponent<DotMatrixEffect>().amount = 200;
                StartCoroutine(OverHeat());
            }
            else
            {
                
                TeleportToLevel(level1);
                playerCamera.gameObject.GetComponent<DotMatrixEffect>().on = false;
            }
            firstLevel = !firstLevel;
            StartCoroutine(CooldownTeleport());
        } 
        #endregion
        
        #region Shooting
        
        
        
        #endregion
    }
    void TeleportToLevel(float yPosition)
    {
        Vector3 location = transform.position;
        location.y = yPosition;
        transform.position = location;
        Physics.SyncTransforms();
    }
    private System.Collections.IEnumerator CooldownTeleport()
    {
        canTeleport = false;
        UI.transform.Find("Cooldown").gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        cooldownTeleport--;
        UI.transform.Find("Cooldown").gameObject.GetComponent<TextMeshProUGUI>().text = cooldownTeleport.ToString();
        if (cooldownTeleport > 0)
            StartCoroutine(CooldownTeleport());
        else
        {
            StopCoroutine(CooldownTeleport());
            canTeleport = true;
            UI.transform.Find("Cooldown").gameObject.GetComponent<TextMeshProUGUI>().text = "10";
            UI.transform.Find("Cooldown").gameObject.SetActive(false);
        }
    }
    private System.Collections.IEnumerator OverHeat()
    {
        yield return new WaitForSeconds(1);
        playerCamera.gameObject.GetComponent<DotMatrixEffect>().amount = playerCamera.gameObject.GetComponent<DotMatrixEffect>().amount - 4;
        if (playerCamera.gameObject.GetComponent<DotMatrixEffect>().amount > 3 && !firstLevel)
            StartCoroutine(OverHeat());
        else if (playerCamera.gameObject.GetComponent<DotMatrixEffect>().amount <= 3 && !firstLevel)
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
        else
            StopCoroutine(OverHeat());
    }
    
}
