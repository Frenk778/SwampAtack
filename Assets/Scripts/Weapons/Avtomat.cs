using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avtomat : Wapon
{
    public override void Shoot(Transform shootPoint)
    {
        Instantiate(Bullet, shootPoint.position, Quaternion.identity);
    }
}
