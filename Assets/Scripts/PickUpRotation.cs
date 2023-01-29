using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PickUpRotation : MonoBehaviour
{
    void Start()
    {
        transform.DORotate(new Vector3(360, 360, 0), 5, RotateMode.FastBeyond360)
            .SetLoops(-1,LoopType.Restart)
            .SetRelative()
            .SetEase(Ease.Linear);
    }

}
