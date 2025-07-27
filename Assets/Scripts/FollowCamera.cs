using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    Vector3 offset;
    //Vector2 minposition = new Vector2(-24f, -13f);
    //Vector2 maxposition = new Vector2(21f, 10f);


    private void Start()
    {
        if (target == null)
            return;

        offset = transform.position - target.position;
    }
    private void Update()
    {
        if (target == null)
            return;
        Vector3 pos= transform.position;
        pos = offset + target.position;
        //float clampX = Mathf.Clamp(pos.x, minposition.x, maxposition.x);
        //float clampY = Mathf.Clamp(pos.y, minposition.y, maxposition.y);
        //transform.position = new Vector3(clampX, clampY,transform.position.z);
        transform.position = pos;
    }
}
