using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Helper helper = new Helper();
    [SerializeField]
    Camera cam;
    [SerializeField]
    Transform player;

    public Vector3 offset;
    [SerializeField]
    float followSpeed;
    [Range(1,10)]
    [SerializeField]
    float smoothFactor;

    [SerializeField]
    float minFOV = 9, maxFOV = 16, baseFOV, interpolationRate;
    bool isMoving;
    private void OnEnable()
    {
        //PlayerEventHandler.playerMoved += FollowPlayer;
        PlayerEventHandler.playerMoved += AdjustFovOnMove;
    }
    private void OnDisable()
    {
        //PlayerEventHandler.playerMoved -= FollowPlayer;
        PlayerEventHandler.playerMoved -= AdjustFovOnMove;
    }
    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        baseFOV = cam.orthographicSize;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        ReturnFOV();
    }
    private void FixedUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.position + offset;
            Vector3 smoothCam = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
            transform.position = smoothCam;
        }
    }
    void AdjustFovOnMove()
    {
        isMoving = true;
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, maxFOV, interpolationRate * Time.deltaTime);
        isMoving = false;
    }
    void ReturnFOV()
    {
        if (isMoving == false)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, baseFOV, (interpolationRate * 2) * Time.deltaTime);
        }
    }
}
