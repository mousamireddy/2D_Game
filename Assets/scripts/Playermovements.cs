using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Playermovements : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;
    public float gravity = 1f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    //public float jumpCount = 2f;
    bool isGround;
    public float PlayerHealth = 100;
    public Image PlayerHealthImage;
    public Text PlayerHealthText;
    Vector3 Distances;
    float timee=10f;
    // Update is called once per frame
    private void Start()
    {
            Distances = transform.position;
        
    }
    void Update()
    {
        // Updating Health Image in uI
        timee-=Time.deltaTime;
        if (timee <= 0)
        {
            if(Distances == transform.position)
            {
                PlayerHealth = PlayerHealth-5f;
                PlayerHealthImage.fillAmount = PlayerHealth / 100;
                //Debug.Log(Distances);
            }
            timee = 10f;
            Distances = transform.position;
            
        }
            PlayerHealthImage.fillAmount = PlayerHealth / 100;
        if(PlayerHealth <= 0)
        {
            PlayerHealth = 0;
            SceneManager.LoadScene("game over");
        }
        PlayerHealthText.text = PlayerHealth.ToString();
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z  = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move*speed*Time.deltaTime);
        if(Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EGGTRAY")
        {
            PlayerHealth = 100f;
            
            StartCoroutine(ShowEggTray(other.gameObject));
        }
    }

    IEnumerator ShowEggTray(GameObject Tray)
    {
        Tray.SetActive(false);
        yield return new WaitForSeconds(20f);
        Tray.SetActive(true);

    }
    


}
