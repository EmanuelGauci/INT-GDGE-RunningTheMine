using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour{
    [Header("General variables")]
    public bool alive = true;
    public static int lives = 3;
    public float jumpForce = 1;
    int speed = 17;
    public Rigidbody rb;
    float horizontalInput;
    public float horizontalMul = 2;
    int speedboost=0;
    int jumpfixcounter = 0;

    [Header("Damage Overlay")]
    public Image overlay;
    public float duration;
    public float fadeSpeed;
    private float durationTimer;

    void Start(){
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
        GameManager.score = 0;//reset score
        GameManager.gold = 0;//reset gold
    }

    private void FixedUpdate(){
        if (!alive) return;
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMul;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update(){
        horizontalInput = Input.GetAxis("Horizontal");
        if (transform.position.y < -5){//make player die if outside of map
            Die();
        }
        if(transform.position.y < 2){//stop double jump
            if (Input.GetButtonDown("Jump")){
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
        //damage screen fading
        if (overlay.color.a > 0){//check overlay alpha value
            durationTimer += Time.deltaTime;
            if(durationTimer > duration){
                //fade image
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }
    }
    //actions with tags
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Obstacle")){
            durationTimer = 0;
            overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1);
            lives--;
            if(lives <= 0){
                Die();//kill player if player has 0 or less lives
                lives = 3;//reset lives
            }
        }
        if (other.CompareTag("Crystal")){
            GameManager.inst.IncrementScore();
            Destroy(other.gameObject);
            speedboost++;
            if (speedboost >= 30){
                speed ++;
                speedboost = 0;
                GameManager.inst.IncrementSpeedBoost();
            }
        }
        if (other.CompareTag("Gold")){
            GameManager.inst.IncrementGold();
            Destroy(other.gameObject);
            //increase a life if 10 gold are picked up
            if (GameManager.gold >= 10){
                lives++;
                GameManager.gold = 0;
            }
        }
        if (other.CompareTag("wall")){
            Die();
        }
    }
    
    //death action
    public void Die(){
        alive = false;
        SceneManager.LoadScene("death screen");
    }

   
}
