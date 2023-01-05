using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour{
    [Header("General variables")]
    bool alive = true;
    int lives = 3;
    public float jumpForce = 10;
    public float speed = 5;
    public Rigidbody rb;
    float horizontalInput;
    public float horizontalMul = 2;

    [Header("Damage Overlay")]
    public Image overlay;//our DamageOverlay Gameobject
    public float duration;//how long the image stays fully opaque
    public float fadeSpeed;//how quickly the image will fade
    private float durationTimer; //timer to check against the duration

    void Start(){
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
    }

    private void FixedUpdate(){
        if (!alive) return; 

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMul;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }
    private void Update(){
        horizontalInput = Input.GetAxis("Horizontal");
        //make player die if outside of map
        if (transform.position.y < -5){
            Die();
        }
        //stop double jump
        if(transform.position.y < 2){
            //make player jump
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
        if (overlay.color.a > 0)//check overlay alpha value
        {
            durationTimer += Time.deltaTime;
            if(durationTimer > duration)
            {
                //fade image
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }
        
    }
    //actions with tags
    private void OnTriggerEnter(Collider other){
        //life decrease action
        if (other.CompareTag("Obstacle")) {
            durationTimer = 0;//reset duration timer
            overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1);
            lives--;//decrement lives
            //kill player if player has 0 or less lives
            if(lives <= 0)
            {
                Die();
            }
            
        }
        
        //increment player's main score with crystal tag
        if (other.CompareTag("Crystal"))
        {
            // Add to the player's score
            GameManager.inst.IncrementScore();

            // Destroy this coin object
            Destroy(other.gameObject);
        }

        //increment player's gold score with gold tag
        if (other.CompareTag("Gold"))
        {
            // Add to the player's score
            GameManager.inst.IncrementGold();

            // Destroy this coin object
            Destroy(other.gameObject);
        }

    }

    //death action
    public void Die()
    {
        //set alive bool to false
        alive = false;
        //edit this later to take player to death card which will take player back to the play scene or home scene depending on player choice
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   
}
