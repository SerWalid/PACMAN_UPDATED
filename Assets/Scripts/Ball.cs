using System;
using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public Ghost ghostController;
    public Ghost ghostController1;
    public Ghost ghostController2;
    public Ghost ghostController3;

    private bool ghostCollisionEnabled = false;
    public int coins;
    public float moveSpeed = 5f;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            Debug.Log("Coin collected");
            coins = coins + 1;
            Debug.Log(coins);
            other.gameObject.SetActive(false);
            StartCoroutine(ReactivateCoinAfterDelay(other.gameObject, 2f));
            if (coins >= 2)
            {
                coins = 0;
                ghostCollisionEnabled = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost") && ghostCollisionEnabled)
        {
            ghostController.DisableNavMeshAgent();
            ghostController.ResetGhostPosition();
        }
        if (other.CompareTag("Ghost1") && ghostCollisionEnabled)
        {
            ghostController1.DisableNavMeshAgent();
            ghostController1.ResetGhostPosition();
        }
        if (other.CompareTag("Ghost2") && ghostCollisionEnabled)
        {
            ghostController2.DisableNavMeshAgent();
            ghostController2.ResetGhostPosition();
        }
        if (other.CompareTag("Ghost3") && ghostCollisionEnabled)
        {
            ghostController3.DisableNavMeshAgent();
            ghostController3.ResetGhostPosition();
        }
    }

    private IEnumerator ReactivateCoinAfterDelay(GameObject coinToReactivate, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (coinToReactivate != null)
        {
            coinToReactivate.SetActive(true);
        }
    }
}