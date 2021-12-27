using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    #region Variables
    
    [Tooltip("Speed of the player.")]
    [SerializeField] private float speed;
    
    private Vector3 velocity;
    private Rigidbody playerRigidbody;

    private float screenHalfWidth;
    private float playerHalfWidth;

    private float screenHalfHeight;
    private float playerHalfHeight;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        playerHalfHeight = this.transform.localScale.y / 2f;
        screenHalfHeight = Camera.main.orthographicSize; // orthographicSize is only Half Height

        playerHalfWidth = this.transform.localScale.x / 2f;
        screenHalfWidth = Camera.main.aspect * screenHalfHeight;

        playerRigidbody = GetComponent<Rigidbody>(); // Get reference to the Rigidbody
                                                     // component attached to the
                                                     // PlayerObject associated with this
                                                     // Player script, which is also  
                                                     // attached to the PlayerObject
    }

    // Update is called once per frame
    void Update()
    {
        // Put user updates here
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        Vector3 direction = input.normalized;
        velocity = speed * direction;
        print(velocity);
    }

    private void FixedUpdate()
    {
        // Put non-user updates here
        playerRigidbody.position += velocity * Time.fixedDeltaTime;

        if (playerRigidbody.position.x > screenHalfWidth + playerHalfWidth) 
        {
            playerRigidbody.position = new Vector3 (-1 * ( screenHalfWidth + playerHalfWidth ), 
                playerRigidbody.position.y, 0);
        }

        if (playerRigidbody.position.x < -1 * ( screenHalfWidth + playerHalfWidth ) )
        {
            playerRigidbody.position = new Vector3(screenHalfWidth + playerHalfWidth,
                playerRigidbody.position.y, 0);
        }

        if (playerRigidbody.position.y < - screenHalfHeight + playerHalfHeight)
        {
            playerRigidbody.position = new Vector3(playerRigidbody.position.x, - screenHalfHeight + playerHalfHeight, 0);
        }

        if (playerRigidbody.position.y > screenHalfHeight - playerHalfHeight)
        {
            playerRigidbody.position = new Vector3(playerRigidbody.position.x, screenHalfHeight - playerHalfHeight, 0);
        }

    }
}
