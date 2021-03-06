using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public AudioSource audioSource;
    public AudioClip jumpSound, pickUpSound, healthSound, hurtSound, crateSound,jumpPadSound, weaponPickUp;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Slider staminaBarShift;
    [SerializeField] int maxStamina = 100;
    [SerializeField] float currentStamina;
    private Coroutine regen;
    public GameObject weapon;
    Vector3 velocity;
    private bool isMoving;
    public AudioSource moving;
    bool isGrounded;
    private int redKey, yellowKey, blueKey;
    public GameObject key1, key2, key3, bar1, bar2, bar3, bar4, bar5, bar6, bar7, bar8, bar9, bar10, deathTransition, canvasStuff;
    public int health;
    public Transform checkpoint;
    public TMP_Text distanceText;
    public GameObject transition;

    private float distance;
    void Start()
    {
        health = 10;
        speed = 7f;
        currentStamina = maxStamina;
        staminaBarShift.maxValue = maxStamina;
        staminaBarShift.value = maxStamina;
        redKey = 0; blueKey = 0; yellowKey = 0;
        distanceText.text = "Find all KeyCards";
        deathTransition.SetActive(false);
        transition.SetActive(false);
    }
        void Awake()
        {
            key1 = GameObject.Find("redKey");
            key2 = GameObject.Find("blueKey");
            key3 = GameObject.Find("yellowKey");
            bar1 = GameObject.Find("GreenBar1");
            bar2 = GameObject.Find("GreenBar2");
            bar3 = GameObject.Find("GreenBar3");
            bar4 = GameObject.Find("GreenBar4");
            bar5 = GameObject.Find("GreenBar5");
            bar6 = GameObject.Find("YellowBar6");
            bar7 = GameObject.Find("YellowBar7");
            bar8 = GameObject.Find("YellowBar8");
            bar9 = GameObject.Find("RedBar9");
            bar10 = GameObject.Find("RedBar10");
        }

     public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        if(z !=0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        if (isMoving && isGrounded)
            {
                if(!moving.isPlaying)
                moving.Play();
            }
            else 
                moving.Stop();

        Vector3 move = transform.right * x + transform.forward * z;

   controller.Move(move * speed * Time.deltaTime);
   if(Input.GetButtonDown("Jump") && isGrounded)
   {
            PlaySound(jumpSound);
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
   }
   
    if(redKey == 1)
        {
            key1.SetActive(true);
        }
        else
            key1.SetActive(false);
    if(blueKey ==1)
        {
            key2.SetActive(true);
        }
        else
            key2.SetActive(false);
    if(yellowKey == 1)
        {
            key3.SetActive(true);
        }
        else
            key3.SetActive(false);
   velocity.y += gravity * Time.deltaTime;
   controller.Move(velocity * Time.deltaTime);
    if (health == 0)
        {
            canvasStuff.SetActive(false);
            deathTransition.SetActive(true);
            weapon.SetActive(false);
            PlayerMovement pm = GetComponent<PlayerMovement>();
            pm.enabled = false;
            StartCoroutine("WaitExit");
        }
        if (health == 0)
        {
            bar1.SetActive(false);
            bar2.SetActive(false);
            bar3.SetActive(false);
            bar4.SetActive(false);
            bar5.SetActive(false);
            bar6.SetActive(false);
            bar7.SetActive(false);
            bar8.SetActive(false);
            bar9.SetActive(false);
            bar10.SetActive(false);
        }
        if (health == 1)
        {
            bar1.SetActive(false);
            bar2.SetActive(false);
            bar3.SetActive(false);
            bar4.SetActive(false);
            bar5.SetActive(false);
            bar6.SetActive(false);
            bar7.SetActive(false);
            bar8.SetActive(false);
            bar9.SetActive(false);
            bar10.SetActive(true);
        }
        if (health == 2)
        {
            bar1.SetActive(false);
            bar2.SetActive(false);
            bar3.SetActive(false);
            bar4.SetActive(false);
            bar5.SetActive(false);
            bar6.SetActive(false);
            bar7.SetActive(false);
            bar8.SetActive(false);
            bar9.SetActive(true);
            bar10.SetActive(true);
        }
        if (health == 3)
        {
            bar1.SetActive(false);
            bar2.SetActive(false);
            bar3.SetActive(false);
            bar4.SetActive(false);
            bar5.SetActive(false);
            bar6.SetActive(false);
            bar7.SetActive(false);
            bar8.SetActive(true);
            bar9.SetActive(true);
            bar10.SetActive(true);
        }
        if (health == 4)
        {
            bar1.SetActive(false);
            bar2.SetActive(false);
            bar3.SetActive(false);
            bar4.SetActive(false);
            bar5.SetActive(false);
            bar6.SetActive(false);
            bar7.SetActive(true);
            bar8.SetActive(true);
            bar9.SetActive(true);
            bar10.SetActive(true);
        }
        if (health == 5)
        {
            bar1.SetActive(false);
            bar2.SetActive(false);
            bar3.SetActive(false);
            bar4.SetActive(false);
            bar5.SetActive(false);
            bar6.SetActive(true);
            bar7.SetActive(true);
            bar8.SetActive(true);
            bar9.SetActive(true);
            bar10.SetActive(true);
        }
        if (health == 6)
        {
            bar1.SetActive(false);
            bar2.SetActive(false);
            bar3.SetActive(false);
            bar4.SetActive(false);
            bar5.SetActive(true);
            bar6.SetActive(true);
            bar7.SetActive(true);
            bar8.SetActive(true);
            bar9.SetActive(true);
            bar10.SetActive(true);
        }
        if (health == 7)
        {
            bar1.SetActive(false);
            bar2.SetActive(false);
            bar3.SetActive(false);
            bar4.SetActive(true);
            bar5.SetActive(true);
            bar6.SetActive(true);
            bar7.SetActive(true);
            bar8.SetActive(true);
            bar9.SetActive(true);
            bar10.SetActive(true);
        }
         if (health == 8)
        {
            bar1.SetActive(false);
            bar2.SetActive(false);
            bar3.SetActive(true);
            bar4.SetActive(true);
            bar5.SetActive(true);
            bar6.SetActive(true);
            bar7.SetActive(true);
            bar8.SetActive(true);
            bar9.SetActive(true);
            bar10.SetActive(true);
        }
         if (health == 9)
        {
            bar1.SetActive(false);
            bar2.SetActive(true);
            bar3.SetActive(true);
            bar4.SetActive(true);
            bar5.SetActive(true);
            bar6.SetActive(true);
            bar7.SetActive(true);
            bar8.SetActive(true);
            bar9.SetActive(true);
            bar10.SetActive(true);
        }
         if (health == 10)
        {
            bar1.SetActive(true);
            bar2.SetActive(true);
            bar3.SetActive(true);
            bar4.SetActive(true);
            bar5.SetActive(true);
            bar6.SetActive(true);
            bar7.SetActive(true);
            bar8.SetActive(true);
            bar9.SetActive(true);
            bar10.SetActive(true);
        }
        if (blueKey == 1 && redKey == 1 && yellowKey == 1)
        {
            distance = (checkpoint.transform.position - transform.position).magnitude;
            distanceText.text = "Distance to Exit: " + distance.ToString("F1") + "M";
        }
    }
    void FixedUpdate()
    {
        if (currentStamina > 0.30f)
        {
            if(Input.GetKey(KeyCode.LeftShift)&& isMoving == true)
            {
                UseStamina(0.30f);
                speed = 14f;
            }
            else
            {
                speed = 7f;
            }
        }
        else if (currentStamina < 0.30f)
        {
            staminaBarShift.value = currentStamina;
            speed = 7f;
        }
    }

    IEnumerator WaitExit()
    {
        yield return new WaitForSeconds(1.5f);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("LoseScreen");
    }
    public void UseStamina(float amount)
    {
        if(currentStamina - amount >=0)
        {
            currentStamina -= amount;
            staminaBarShift.value = currentStamina;

            if(regen !=null)
            {
                StopCoroutine(regen);
            }
            regen = StartCoroutine(RegenStamina());
        }
    }
    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(0.7f);

        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 100;
            staminaBarShift.value = currentStamina;
            yield return new WaitForSeconds(0.05f);
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "ExitDoor")
        {
            if(redKey == 1 && blueKey == 1 && yellowKey == 1)
            {
                Debug.Log("Work");
                transition.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                canvasStuff.SetActive(false);
                weapon.SetActive(false);
                PlayerMovement pm = GetComponent<PlayerMovement>();
                pm.enabled = false;
                StartCoroutine("WinExit");
            }
        }
        if(collision.gameObject.tag == "WeaponPickUp")
        {
            PlaySound(weaponPickUp);
        }
        if(collision.gameObject.tag == "redKey")
        {
            if(redKey < 1)
            {
                redKey += 1;
                Destroy(collision.gameObject);
                PlaySound(pickUpSound);
            }
        }
        if(collision.gameObject.tag == "blueKey")
        {
            if(blueKey < 1)
            {
                blueKey += 1;
                Destroy(collision.gameObject);
                PlaySound(pickUpSound);
            }
        }
        if(collision.gameObject.tag == "yellowKey")
        {
            if(yellowKey < 1)
            {
                yellowKey += 1;
                Destroy(collision.gameObject);
                PlaySound(pickUpSound);
            }
        }
        if(collision.gameObject.tag =="HealthPickUp")
        {
           if (health < 10)
                {
                health += 1;
                PlaySound(healthSound);
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "JumpPad")
        {
            jumpHeight = 25f;
        }
        if (collision.gameObject.tag == "Explosion" && health > 0)
        {
            health = health - 1;
            PlaySound(hurtSound);
            Debug.Log("Bomb");
        }
        if(collision.gameObject.tag =="PistolAmmo")
        {
            PlaySound(crateSound);
        }
    }
    void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.tag == "JumpPad")
        {
            jumpHeight = 3f;
            PlaySound(jumpPadSound);
        }
    }
     void OnCollisionEnter(Collision collider)
    {
        if(collider.gameObject.tag == "Bullet" && health > 0)
        {
            health -= 1;
            Debug.Log("Hi There");
            PlaySound(hurtSound);
        }

    }
    IEnumerator WinExit()
    {
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("WinScreen");
    }
}
