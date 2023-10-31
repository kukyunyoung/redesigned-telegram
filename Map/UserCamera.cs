using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UserCamera : MonoBehaviour
{
    public Camera camera_ = null;
    Vector3 CameraPosition = new Vector3 (0, 2.4f, -10);
    public GameObject Player;
    public GameObject LeftMap;
    public GameObject RightMap;
    public GameObject BottomMap;

    public int IsCameraState = 1;

    Vector3 PlayerPosition;
    float CameraMoveSpeed = 3f;

    float Size_X, Size_Y;

    float L_map_left, L_map_right, L_map_bottom, L_map_top;
    Vector3 LeftMapPosition, LeftMapScale;
    float R_map_left, R_map_right, R_map_bottom, R_map_top;
    Vector3 RightMapPosition, RightMapScale;
    float B_map_left, B_map_right, B_map_bottom, B_map_top;
    Vector3 BottomMapPosition, BottomMapScale;

    void Start()
    {
        Size_Y = camera_.orthographicSize;
        Size_X = camera_.orthographicSize * Screen.width / Screen.height; // Screen.width = 1920, Screen.height = 1080

        PlayerPosition = Player.GetComponent<Transform>().position;

        LeftMapPosition = LeftMap.GetComponent<Transform>().position;
        LeftMapScale = LeftMap.GetComponent<Transform>().localScale;

        // øﬁ¬ ∏ ¿« top, bottom, left, right
        L_map_left = LeftMapPosition.x - (LeftMapScale.x / 2);
        L_map_right = LeftMapPosition.x + (LeftMapScale.x / 2);
        L_map_bottom = LeftMapPosition.y - (LeftMapScale.y / 2);
        L_map_top = LeftMapPosition.y + (LeftMapScale.y / 2);

        RightMapPosition = RightMap.GetComponent<Transform>().position;
        RightMapScale = RightMap.GetComponent<Transform>().localScale;

        // ∏ ¿« top, bottom, left, right
        R_map_left = RightMapPosition.x - (RightMapScale.x / 2);
        R_map_right = RightMapPosition.x + (RightMapScale.x / 2);
        R_map_bottom = RightMapPosition.y - (RightMapScale.y / 2);
        R_map_top = RightMapPosition.y + (RightMapScale.y / 2);

        BottomMapPosition = BottomMap.GetComponent<Transform>().position;
        BottomMapScale = BottomMap.GetComponent<Transform>().localScale;

        // ∏ ¿« top, bottom, left, right
        B_map_left = BottomMapPosition.x - (BottomMapScale.x / 2);
        B_map_right = BottomMapPosition.x + (BottomMapScale.x / 2);
        B_map_bottom = BottomMapPosition.y - (BottomMapScale.y / 2);
        B_map_top = BottomMapPosition.y + (BottomMapScale.y / 2);

        IsCameraState = 1;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        PlayerPosition = Player.GetComponent<Transform>().position;
        L_LimitCameraArea();
        R_LimitCameraArea();
        B_LimitCameraArea();
    }

    void L_LimitCameraArea()
    {
        if (IsCameraState == 1)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerPosition + CameraPosition, Time.deltaTime * CameraMoveSpeed);

            float x = Mathf.Clamp(transform.position.x, L_map_left + Size_X, L_map_right - Size_X);
            float y = Mathf.Clamp(transform.position.y, L_map_bottom + Size_Y, L_map_top - Size_Y);

            transform.position = new Vector3(x, y, -10f);
        }
    }

    void R_LimitCameraArea()
    {
        if (IsCameraState == 2)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerPosition + CameraPosition, Time.deltaTime * CameraMoveSpeed);

            float x = Mathf.Clamp(transform.position.x, R_map_left + Size_X, R_map_right - Size_X);
            float y = Mathf.Clamp(transform.position.y, R_map_bottom + Size_Y, R_map_top - Size_Y);

            transform.position = new Vector3(x, y, -10f);
        }
    }
    void B_LimitCameraArea()    {
        if (IsCameraState == 3)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerPosition + CameraPosition, Time.deltaTime * CameraMoveSpeed);

            float x = Mathf.Clamp(transform.position.x, B_map_left + Size_X, B_map_right - Size_X);
            float y = Mathf.Clamp(transform.position.y, B_map_bottom + Size_Y, B_map_top - Size_Y);

            transform.position = new Vector3(x, y, -10f);
        }
    }
}
