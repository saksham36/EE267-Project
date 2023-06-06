using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float maxHealth = 100;
    [SerializeField] Transform head;
    public float playerHealth;
    public HealthBar healthBar;
    public TimeBar timeBar;
    public float speed = 2f; // just for debugging
    CharacterController characterController;
    public ReloadScreen reloadScreen;
    
    private bool waitbool;
    void Start()
    {
        // reloadScreen.Activate();
        // waitbool = false;
        // Debug.Log("Wait Start");
        // StartCoroutine(reloadMessageWait());
        // Debug.Log("Wait End");
        // if (waitbool == true)
        // {
        //     Debug.Log("its me i waited");
        // }
        // reloadScreen.Deactivate();

        playerHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        characterController = GetComponent<CharacterController>();
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        Debug.Log(string.Format("Player health: {0}",playerHealth));
        healthBar.SetHealth(playerHealth);
        if(playerHealth <= 0)
        {
            Debug.Log("No health left");
            FindObjectOfType<GameManager>().EndGame();
        }
        
    }

    // void OnCollisionEnter(Collision _collision)
    // {   
    //     Debug.Log(string.Format("Object tag",_collision.gameObject.tag));
        
    //     if(_collision.gameObject.tag == "Fire")
    //     {
    //         Debug.Log(string.Format("Just Touched fire."));
    //         TakeDamage(fireDamage);
    //     }
    // }

    public Vector3 GetHeadPosition()
    {
        return head.position;
    }

// //-------------------- DEBUG CODE START --------------------
//     Vector3 move;
//     float gravity = -2;
//     float velocityY = 0;
//     void Update() 
//     {
//         // For debugging to move around
//         velocityY += gravity * Time.deltaTime;
//         move.x = Input.GetAxis("Horizontal");
// 		move.z = Input.GetAxis("Vertical");
//         move.y = 0;
//         move = move.normalized;
//         Vector3 temp = Vector3.zero;
//         if(move.z == 1){
//             temp += transform.forward;
//         }
//         else if(move.z == -1)
//         {
//             temp += transform.forward * -1;
//         }
//         if(move.x == 1)
//         {
//             temp += transform.right;
//         }
//         else if(move.x == -1)
//         {
//             temp += transform.right * -1;
//         }

//         Vector3 velocity = temp * speed;
//         velocity.y = velocityY;
//         characterController.Move(velocity * Time.deltaTime);
//         if(characterController.isGrounded)
//         {
//             velocityY = 0;
//         }

//         // For debugging to see healthbar is working
//         if(Input.GetKeyDown(KeyCode.Space)) 
//         {
//             TakeDamage(20);
//         }

//     }
    
//     void FixedUpdate()
// 	{
// 		transform.Translate(move * Time.fixedDeltaTime * speed);
// 	}

   IEnumerator reloadMessageWait()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("hey i waited 5 secs of my life");
        waitbool = true;
        yield return null;
    
    }
// //-------------------- DEBUG CODE END -------------------- 
}
