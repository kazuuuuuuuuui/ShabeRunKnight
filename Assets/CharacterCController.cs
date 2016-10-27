using UnityEngine;
using System.Collections;

public class CharacterCController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // スペースキーでジャンプ
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Jump!!");

            //this.rigidbody2D.AddForce(Vector2.up * 400f);
        }
    }
}
