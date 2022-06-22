using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisions : MonoBehaviour
{
    public LayerMask PlayerLayer;
    public LayerMask RightGoalLayer;
    public LayerMask LeftGoalLayer;
    public LayerMask WallLayer;

    public System.Action OnPlayerCollision;
    public System.Action OnLeftGoalCollision;
    public System.Action OnRightGoalCollision;
    public System.Action OnWallCollision;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.right = VectorReflection(collision.contacts[0].normal, transform.right);
        CheckCollisionLayer(collision);
    }

    public void CheckCollisionLayer(Collision2D collision)
    {
        if (Utils.IsInLayerMask(collision.gameObject, PlayerLayer))
        {
            if (OnPlayerCollision != null)
            {
                OnPlayerCollision();
            }
        }
        if (Utils.IsInLayerMask(collision.gameObject, RightGoalLayer))
        {
            if (OnLeftGoalCollision != null)
            {
                OnLeftGoalCollision();
            }
        }
        if (Utils.IsInLayerMask(collision.gameObject, LeftGoalLayer))
        {
            if (OnRightGoalCollision != null)
            {
                OnRightGoalCollision();
            }
        }
        if (Utils.IsInLayerMask(collision.gameObject, WallLayer))
        {
            if (OnWallCollision != null)
            {
                OnWallCollision();
            }
        }
    }

    // To reflect the ball I used Vector Reflections: http://www.contemporarycalculus.com/dh/Calculus_all/CC11_7_VectorReflections.pdf
    public Vector3 VectorReflection(Vector3 SurfaceNormal, Vector3 EnterDirection)
    {
        Vector3 ReflectedDirection;
        ReflectedDirection = EnterDirection - 2 * Vector3.Dot(EnterDirection, SurfaceNormal) * SurfaceNormal;
        return ReflectedDirection;
    }
}