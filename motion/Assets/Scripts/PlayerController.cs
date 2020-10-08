using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerController : MonoBehaviour {
    public GameObject Player;
    public GameObject Camera;
    public float speed;
    private Transform PlayerTransform;
    private Transform CameraTransform;
    private float ii;
    // Use this for initialization
    void Start () {
 
        PlayerTransform = transform.parent;
        CameraTransform = GetComponent<Transform>();

        CameraTransform.transform.Rotate(360f, 0, 0);

    }
	
	// Update is called once per frame
	void Update () {
        float X_Rotation = Input.GetAxis("Mouse X");
        float Y_Rotation = Input.GetAxis("Mouse Y");
        PlayerTransform.transform.Rotate(0, X_Rotation, 0);

        //オイラー角と、マウスの変化量を足したものをラジアンに変換
        ii = (Camera.transform.localEulerAngles.x - Y_Rotation) * Mathf.Deg2Rad;
        //sin関数で-1~1の範囲に変換
        ii = Mathf.Sin(ii);

        //角度の制限をつけてやる
        if (ii > -0.6f && ii < 0.2f)
        {
            CameraTransform.transform.Rotate(-Y_Rotation, 0, 0);
            //float kk = Y_Rotation;
        }

        float angleDir = PlayerTransform.transform.eulerAngles.y * (Mathf.PI / 180.0f);
        Vector3 dir1 = new Vector3(Mathf.Sin(angleDir), 0, Mathf.Cos(angleDir));
        Vector3 dir2 = new Vector3(-Mathf.Cos(angleDir), 0, Mathf.Sin(angleDir));
        
        
        if (Input.GetKey(KeyCode.W))
        {
            PlayerTransform.transform.position += dir1 * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            PlayerTransform.transform.position += dir2 * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerTransform.transform.position += -dir2 * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            PlayerTransform.transform.position += -dir1 * speed * Time.deltaTime;
        }
 
    }
}