using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Parametrs")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private string playerTag;
    [SerializeField] private float movingSpeed;

    [SerializeField]
    float leftlimit;
    [SerializeField]
    float rightlimit;
    [SerializeField]
    float bottomlimit;
    [SerializeField]
    float upperlimit;

    private void Awake()
    {
        if (this.playerTransform == null)
        {
            if (this.playerTag == "")
            {
                this.playerTag = "Player";
            }
            this.playerTransform = GameObject.FindGameObjectWithTag(this.playerTag).transform;
        }
        this.transform.position = new Vector3()
        {
            x = this.playerTransform.position.x,
            y = this.playerTransform.position.y,
            z = this.playerTransform.position.z,
        };
    
    }  
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (this.playerTransform) 
        {
            Vector3 target = new Vector3()
            {
                x = this.playerTransform.position.x,
                y = this.playerTransform.position.y,
                z = this.playerTransform.position.z - 10,
            };

            Vector3 pos = Vector3.Lerp(this.transform.position, target, this.movingSpeed * Time.deltaTime);
            this.transform.position = pos;
        }

        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftlimit, rightlimit),
            Mathf.Clamp(transform.position.y, bottomlimit, upperlimit),
            transform.position.z
            );
    }
}
