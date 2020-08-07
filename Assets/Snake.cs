using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Snake : MonoBehaviour
{
    Vector2 direction = Vector2.right;
    List<Transform> tail = new List<Transform>();
    bool ate = false;

    // Tail Prefab
    public GameObject tailPrefab;
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Move", 0.1f, 0.1f);
        // Rigidbody snake = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move in a new Direction?
        if (Input.GetKey(KeyCode.RightArrow))
            direction = Vector2.right;
        else if (Input.GetKey(KeyCode.DownArrow))
            direction = -Vector2.up;    // '-up' means 'down'
        else if (Input.GetKey(KeyCode.LeftArrow))
            direction = -Vector2.right; // '-right' means 'left'
        else if (Input.GetKey(KeyCode.UpArrow))
            direction = Vector2.up;
    }

    void Move()
    {
        Vector2 v = transform.position;
        transform.Translate(direction);

        if (ate)
        {
            GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);
            tail.Insert(0, g.transform);
            ate = false;
        }
        else if (tail.Count > 0)
        {
            // Move last Tail Element to where the Head was
            tail.Last().position = v;

            // Add to front of list, remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log(coll.name);
        if (coll.name.Contains("FoodPrefab"))
        {
            ate = true;

            Destroy(coll.gameObject);
        }
        else
        {
            Destroy(gameObject);
            GameObject go = (GameObject)Instantiate(gameOver);
        }
    }
}
