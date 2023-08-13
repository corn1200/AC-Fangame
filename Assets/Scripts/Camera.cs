using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Player;
    private Vector3 pos = new Vector3(0, 15, -10);

    void Update()
    {
        this.gameObject.transform.position = Player.transform.position + pos;
    }
}
