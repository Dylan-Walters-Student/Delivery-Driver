using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject toFollow;
    //  this positions should be the same as the cars position

    void LateUpdate()
    {
        transform.position = toFollow.transform.position + new Vector3(0, 0, -10);
    }
}
