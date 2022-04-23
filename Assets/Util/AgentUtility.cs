using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class AgentUtility
{
    public static Vector3 FindTargetAxis(Vector3 callerPos, Vector3 targetPos)
    {
        return targetPos - callerPos;
    }

    public static void SeekAvoidInGroup(BehaviorCalculator calc, Vector3 callerPos, Vector3 targetPos, Rigidbody2D callerRB, Steerer steerer, float weight, int seekAvoid)
    {
        Vector3 targetBearing = AgentUtility.FindTargetAxis(calc.mono.sub.groupController.FormationAnchor, targetPos);
        WeightedDirection wd = new WeightedDirection(targetBearing, weight, .7f, false);

        calc.GiveWeightedDirection(wd);
    }

    public static void GoToSimple (BehaviorCalculator calc, Vector3 callerPos, Vector3 targetPos, float weight)
    {
        Vector3 targetBearing = (targetPos - callerPos);
        WeightedDirection wd = new WeightedDirection(targetBearing, weight, .5f, false);
        calc.GiveWeightedDirection(wd);
    }

    public static float ScaleSpeedWithDistance(Vector3 callerPos, Vector3 targetPos, float speed, float slowingDist)
    {
        float dist = (targetPos - callerPos).magnitude;
        float rampedSpeed = speed * dist / slowingDist;
        return Mathf.Min(rampedSpeed, speed);
    }

    public static Vector3 FindTargetFuturePos(Rigidbody2D callerRB, Rigidbody2D targetRB, Vector3 callerPos, Vector3 targetPos)
    {
        Vector3 targetVel = targetRB.velocity;
        float dist = Vector3.Distance(targetPos, callerPos);

        float distMod;
        if (callerRB.velocity.magnitude > 0)
        {
            distMod = dist / callerRB.velocity.magnitude;
        }
        else
        {
            distMod = 0f;
        }
        Vector3 targetPredicted = targetPos + targetVel * distMod;
        return targetPredicted;
    }

    public static void PursueEvade(BehaviorCalculator handler, Vector3 callerPos, Vector3 targetPos, Rigidbody2D callerRB, Rigidbody2D targetRB, float speed, Steerer steerer, Crosshair crosshair, int pursueEvade)
    {
        Vector3 tar = AgentUtility.FindTargetFuturePos(callerRB, targetRB, callerPos, targetPos);
        //crosshair.SetPosition(tar);
        SeekAvoidInGroup(handler, callerPos, tar, callerRB, steerer, speed, pursueEvade);
    }

    public static List<Collider2D> GetObstacleCollidersInBox(Vector3 callerPos, Rigidbody2D callerRB, float avoidWidth, float avoidDist)
    {
        Vector3 center = callerPos + (Vector3)callerRB.velocity.normalized * avoidDist / 2f;
        List<Collider2D> cols = Physics2D.OverlapBoxAll((Vector2)center, new Vector2(avoidDist, avoidWidth), Vector3.SignedAngle(Vector3.up, callerRB.velocity, Vector3.forward)).ToList<Collider2D>();
        List<Collider2D> colsToRemove = new List<Collider2D>();
        for (int i = 0; i < cols.Count; i++)
        {
            Obstacle ob = cols[i].GetComponent<Obstacle>();
            if (ob == null)
            {
                colsToRemove.Add(cols[i]);
            }
        }
        for (int i = 0; i < colsToRemove.Count; i++)
        {
            cols.Remove(colsToRemove[i]);
        }
        
        return cols; 
    }

    public static Collider2D FindClosestCollider(Vector3 callerPos, List<Collider2D> cols)
    {
        float closestDist = Mathf.Infinity;
        Collider2D closestCol = cols[0];
        for (int i = 0; i < cols.Count; i++)
        {
            float colDist = Vector3.Distance(callerPos, cols[i].transform.position);
            if (colDist < closestDist)
            {
                closestCol = cols[i];
                closestDist = colDist;
            }
        }
        return closestCol;
    }

    public static void SteerAwayFromCollider(BehaviorCalculator handler, Vector3 callerPos, Rigidbody2D callerRB, Collider2D col, Steerer steerer, float avoidDist, float weight)
    {
        Vector3 targetAxis = AgentUtility.FindTargetAxis(callerPos, col.transform.position);
        float colliderDist = (col.transform.position - callerPos).magnitude;
        float distanceRatio = (avoidDist - colliderDist) / avoidDist;
        Vector3 dodgingForce = -targetAxis.normalized * distanceRatio;
        Vector3 brakingForce = -callerRB.velocity.normalized * distanceRatio * distanceRatio * weight;
        Vector3 steeringForce = dodgingForce + brakingForce;

        WeightedDirection wd = new WeightedDirection(steeringForce, weight, .5f, false);

        handler.GiveWeightedDirection(wd);
    }



    public static List<Flocker> GetFlockersInRadius (Vector3 callerPos, Flocker callerFlocker, float radius)
    {
        List<Flocker> flockers = new List<Flocker>();
        Collider2D[] cols = Physics2D.OverlapCircleAll((Vector2)callerPos, radius);
        for (int i = 0; i < cols.Length; i++)
        {
            Flocker flocker = cols[i].gameObject.GetComponent<Flocker>();
            if (flocker != null && flocker != callerFlocker)
            {
                flockers.Add(flocker);
            }
        }
        return flockers; 
    }

    public static Vector3 GetAveragePositionOfFlockers (List<Flocker> flockers)
    {
        Vector3 avg = new Vector3(0, 0, 0);
        for (int i = 0; i < flockers.Count; i++)
        {
            avg += flockers[i].transform.position; 
        }
        avg = (1f / flockers.Count) * avg;
        return avg; 
    }

   

    public static Vector3 GetCenterOfGravity(Vector3[,] positions)
    {
        Vector3 avg = new Vector3(0, 0, 0);
        foreach (Vector3 pos in positions)
        {
            avg += pos;
        }
        avg = (1f / positions.Length) * avg;
        return avg;
    }
}
