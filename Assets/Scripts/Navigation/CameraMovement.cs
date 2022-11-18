using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Position vars")]
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    [Header("Animator")]
    public Animator anim;

    [Header("Position reset")]
    public VectorValue cameraMin;
    public VectorValue camreaMax;

    // Start is called before the first frame update
    void Start()
    {
        maxPosition = camreaMax.initialValue;
        minPosition = cameraMin.initialValue;
        transform.position = new Vector3(target.position.x,target.position.y,transform.position.z);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position!=target.position)
        {
            Vector3 targetPosition = new(target.position.x, target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }

    public void StartScreenShake()
    {
        anim.SetBool("shakeActive", true);
        StartCoroutine(ShakeCo());
    }

    public IEnumerator ShakeCo()
    {
        yield return null;
        anim.SetBool("shakeActive", false);
    }



}
