using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

        Vector3 moveAdjustment = Vector3.zero;
        if(viewportPos.x < 0)
        {
            moveAdjustment.x += 1;
        }else if(viewportPos.x > 1)
        {
            moveAdjustment.x -= 1;
        }
        else if (viewportPos.y < 0)
        {
            moveAdjustment.y += 1;
        }
        else if (viewportPos.y > 1)
        {
            moveAdjustment.y -= 1;
        }

        transform.position = Camera.main.ViewportToWorldPoint(viewportPos + moveAdjustment);
    }
}
