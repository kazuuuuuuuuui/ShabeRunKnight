using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour
{
    public GameObject player;
    private Camera camera;

    // Use this for initialization
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //追従するキャラクターのy座標
        float player_x = player.transform.position.x;

        //現在のカメラのx
        float camera_x = camera.transform.position.x;

        //次のx
        float new_x = Mathf.Lerp(camera_x, player_x, 0.5f);

        transform.position = new Vector3(new_x, transform.position.y, transform.position.z);
    }
}
