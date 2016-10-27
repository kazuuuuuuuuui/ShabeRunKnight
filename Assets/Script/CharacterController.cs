using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float 上昇値; // masuo comment

    GetMicroPhoneVolume gmpv;

    private SpriteRenderer spr;

    //private GameObject hukidashi;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gmpv = GetComponent<GetMicroPhoneVolume>();
        //spr = GetComponentInChildren<SpriteRenderer>();
        spr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //ジャンプ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump!!");
           // spr.enabled = true;
            rb.AddForce(Vector2.up * 上昇値);
        }

        rb.AddForce(Vector2.right * gmpv.最大速度);
    }
}
