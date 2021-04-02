using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    public AudioSource audioSource;
    public AudioClip jumpSound, pickUpSound;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Slider staminaBarShift;
    [SerializeField] int maxStamina = 100;
    [SerializeField] float currentStamina;
    private Coroutine regen;
    Vector3 velocity;
    bool isGrounded;
    private int redKey, yellowKey, blueKey;
    public GameObject key1, key2, key3;
    void Start()
    {
        speed = 7f;
        currentStamina = maxStamina;
        staminaBarShift.maxValue = maxStamina;
        staminaBarShift.value = maxStamina;
        redKey = 0; blueKey = 0; yellowKey = 0;
    }
        void Awake()
        {
            key1 = GameObject.Find("redKey");
            key2 = GameObject.Find("blueKey");
            key3 = GameObject.Find("yellowKey");
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

  Vector3 move = transform.right * x + transform.forward * z;

   controller.Move(move * speed * Time.deltaTime);

   if(Input.GetButtonDown("Jump") && isGrounded)
   {
       PlaySound(jumpSound);
       velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
   }
   if (currentStamina > 0.011f)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                UseStamina(0.011f);
                speed = 14f;
            }
            else
            {
                speed = 7f;
            }
        }
        else if (currentStamina < 0.011f)
        {
            staminaBarShift.value = currentStamina;
            speed = 7f;
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
        if(collision.gameObject.tag == "ExitDoor")
        {
            if(redKey == 1 && blueKey == 1 && yellowKey == 1)
            {
                Cursor.visible = true;
                SceneManager.LoadScene("WinScreen");
            }
            else
                {
                Debug.Log("this Works");
            }
        }
    }
}
