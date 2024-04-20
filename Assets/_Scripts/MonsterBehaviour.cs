using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FollowPlayer : MonoBehaviour
{
    public UnityEvent onMonsterDeathEvent = new();

    [SerializeField] float speed = 0.05f;
    [SerializeField] float levitationMagnitude = 5.0f;
    [SerializeField] float levitationSpeedFactor = 5.0f;
    public float lifeDurationInSeconds {get; set;}
    private Player player;
    private float currentLifespan = 0.0f;
    private Vector3 directionToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyIfTimeExceeded();
        UpdatePositionRelatedToPlayer();
    }

    private void DestroyIfTimeExceeded()
    {
        currentLifespan += Time.deltaTime;

        if(currentLifespan > lifeDurationInSeconds)
        {
            onMonsterDeathEvent.Invoke();
            Destroy(gameObject);
        }
    }

    private void UpdatePositionRelatedToPlayer()
    {
        float levitationHeightChange = Time.deltaTime * ((float)Math.Sin(currentLifespan * levitationSpeedFactor)) * levitationMagnitude;
        
        directionToPlayer = (player.transform.position - transform.position).normalized;
        transform.position += speed * Time.deltaTime * new Vector3(directionToPlayer.x, levitationHeightChange,  directionToPlayer.z);
    }
}
