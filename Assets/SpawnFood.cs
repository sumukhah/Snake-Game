using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject FoodPrefab;
    public Transform borderRight;
    public Transform borderLeft;
    public Transform borderUp;
    public Transform borderBottom;

    void Start()
    {
        InvokeRepeating("Spawn", 3, 4);
    }

    void Spawn()
    {
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
        int y = (int)Random.Range(borderUp.position.y, borderBottom.position.y);

        Instantiate(FoodPrefab, new Vector2(x, y), Quaternion.identity);
    }

}
