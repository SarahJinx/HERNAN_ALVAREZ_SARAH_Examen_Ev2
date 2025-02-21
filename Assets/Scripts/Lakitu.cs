using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Lakitu : MonoBehaviour
{
    public GameObject target;
    public GameObject bulletPrefab;
    public float speed;
    private bool throwBullet;
    public float positionY = 0.8f;

    private float currTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<MarioScript>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        currTime += Time.deltaTime;

        if (currTime >= 5)
        {
            Destroy(bulletPrefab);
        }

        if (currTime >= 5)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            currTime = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<MarioScript>())
        {
            // Destroy(collision.gameObject);
            // collision.gameObject.SetActive(false);
            // Time.timeScale = 0;
            GameManager.instance.ResetTime();
            GameManager.instance.LoadScene("Game");
        }
    }
}
