using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject GameManager;
    public int movespeed = 5;
    public float leftrightspeed = 1500;

    public Rigidbody rigid;

    public AIfollow ai;
    private float curDistance;


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();

    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    public void Update()
    {

        //ai.curdis = curDistance;
    }

    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    private void LateUpdate()
    {
        transform.Translate(Vector3.forward * movespeed * Time.deltaTime, Space.World);

        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        if (SwipeManager.swipeLeft)
        {
            Debug.Log("sang trai");
            if (this.gameObject.transform.position.x > -4.4)
            {
                //transform.Translate(Vector3.left * Time.deltaTime * leftrightspeed);
                rigid.velocity = Vector3.left * Time.deltaTime * leftrightspeed;
            }
        }
        //if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        if (SwipeManager.swipeRight)
        {
            Debug.Log("sang phai");
            if (this.gameObject.transform.position.x < 4.4)
            {
                //transform.Translate(Vector3.left * Time.deltaTime * leftrightspeed * -1);
                rigid.velocity = Vector3.left * Time.deltaTime * leftrightspeed * -1;
            }
        }

        ai.Follow(transform.position, 4);


    }
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Vachdich")
        {
            Debug.Log("End Game");
            //GameManager.GetComponent<Endrun>().enabled = true;

        }

        if (other.gameObject.tag == "CoinSpeed")
        {
            Debug.Log("Tang Toc");
            FindObjectOfType<AudioManager>().playSound("CoinPickup");

            movespeed = 10;
            Destroy(other.gameObject);
            StartCoroutine(timespeed());
        }

        if (other.gameObject.tag == "Obstacle")
        {
            Debug.Log("Giam Toc");
            movespeed = 1;
            StartCoroutine(giamspeed());
        }


        if (other.gameObject.tag == "CoinMoney")
        {
            Debug.Log("Tang Coin");
            FindObjectOfType<AudioManager>().playSound("CoinPickup");

            CoinCount.coinCount += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Ai")
        {
            Debug.Log("Bi bat");
            FindObjectOfType<AudioManager>().playSound("EndMusic");
            //GameManager.GetComponent<Endrun>().enabled = true;

        }
    }

    IEnumerator timespeed()
    {
        yield return new WaitForSeconds(1f);
        movespeed = 5;
    }

    IEnumerator giamspeed()
    {
        yield return new WaitForSeconds(1f);
        movespeed = 5;
    }


}
