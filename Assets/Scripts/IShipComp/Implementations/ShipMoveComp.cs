using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMoveComp : MonoBehaviour, IMovementComponent
{
    // [Header("Manager Values")]
    // public Vector3 position;
    // public Vector3 velocity;
    // public bool isSelected = false;
    // public GameObject selectionCircle;
    // public int ID;
    // public Vector3 repelPotential;
    // public Vector3 attractPotential;
    // public LineRenderer line;
    // [Header("Change After Start")]
    // public float speed;
    // public float desiredSpeed;
    // public float heading; //Degs
    // public float desiredHeading; //Degs
    // public bool evasionMode = false;
    // //public Vector3 target = Vector3.zero;
    // public List<Vector3> pathList = new List<Vector3>();
    // public bool playerMove = false;
    // public int moveState = 0;
    // //0 = Dead
    // //1 = Hold Positon
    // //2 = GotoTarget
    // [Header("Hold After Start")]
    // public float acceleration = 7;
    // public float turnRate = 45;
    // public float maxSpeed = 40;
    // public float minSpeed =-20;
    // public float mass;
    // public GameObject myCameraNode;
    // void Start()
    // {
    //     velocity = Vector3.zero;
    //     position = transform.localPosition;
    //     heading = transform.eulerAngles.y;
    //     repelPotential = Vector3.zero;
    //     attractPotential = Vector3.zero;
    //     line = GetComponent<LineRenderer>();
    //     line.startColor = Color.cyan;
    //     line.endColor = Color.cyan;
    // }

    // Vector3 eulerRotation = Vector3.zero;
    // // Update is called once per frame
    // void Update()
    // {
    //     if(moveState==1 && !isSelected)
    //     {
    //         FindPath();
    //     }
    //     //Potential Feilds
    //     float magnitude = 0;
    //     Vector3 sum = Vector3.zero;
    //     repelPotential = Vector3.forward;
    //     attractPotential = Vector3.forward;
    //     float range = maxSpeed-minSpeed;
    //     Vector3 dif;
    //     if(moveState!=0 && moveState!=3)
    //     { 
    //         foreach(BoatEntity ent in EntityMgr.inst.boatEntities)
    //         {
    //             if(ent.ID == ID)
    //                 continue;

    //             dif = ent.position - position;
    //             magnitude = dif.magnitude;
    //             float closestDist = Utils.ClosestDistOfApproach(position, velocity, ent.position, ent.position);
    //             if ((closestDist < AIMgr.inst.tooClose * ent.mass || isCBDR(ent)) && magnitude<AIMgr.inst.potentialDistanceMax)
    //                 repelPotential += dif.normalized * ent.mass * (AIMgr.inst.aAvoidance * Mathf.Pow(magnitude, AIMgr.inst.eAvoidance));
    //         }

    //         foreach(BouyEnt ent in EntityMgr.inst.bouyEntities)
    //         {
    //             dif = ent.transform.position - position;
    //             magnitude = dif.magnitude;
    //             //float closestDist = Utils.ClosestDistOfApproach(position, velocity, ent.transform.position, ent.transform.position);
    //             if (magnitude < AIMgr.inst.tooClose * ent.mass)
    //                 repelPotential += dif.normalized * ent.mass * (AIMgr.inst.aAvoidance * Mathf.Pow(magnitude, AIMgr.inst.eAvoidance));
    //         }
            
            
    //         Vector3 netPotential = Vector3.zero;
          
    //         dif = Vector3.zero;
    //         if(moveState==2)
    //             dif = pathList[0] - position;
    //         sum = dif;
    //         magnitude = dif.magnitude;
    //         if(pathList.Count>0 && !playerMove)
    //         {
    //             if(myDirection==direction.West && pathList[0].x<position.x)
    //             {
    //                 nextMove();
    //             }
    //             else if(myDirection==direction.East && pathList[0].x>position.x)
    //             {
    //                 nextMove();
    //             }
    //             if(myDirection==direction.AcrossN && pathList[0].z>position.z)
    //             {
    //                 nextMove();
    //             }
    //             else if(myDirection==direction.AcrossS && pathList[0].z<position.z)
    //             {
    //                 nextMove();
    //             }
    //         }
    //         else if(playerMove && (pathList[0]-position).magnitude < 20f)
    //         {
    //             nextMove();
    //         }
    //         attractPotential = sum.normalized * AIMgr.inst.aAttraction * Mathf.Pow(magnitude, AIMgr.inst.eAttraction);
    //         //Potenial Movers
    //         netPotential = attractPotential - repelPotential;
    //         if(moveState==2)
    //         {
    //             desiredHeading=Utils.ConvertTo360(Mathf.Rad2Deg * Mathf.Atan2(netPotential.x, netPotential.z));
    //             desiredSpeed=minSpeed + ((Mathf.Cos(Utils.AngleDifrenceNegatives(desiredHeading, heading) * Mathf.Deg2Rad) + 1)/2.0f)*range;
    //             // Debug.DrawLine(transform.localPosition, -1*transform.localPosition+repelPotential, Color.red, 0.0f);
    //             // Debug.DrawLine(position, 3*position+attractPotential, Color.green, 0.0f);
    //             // Debug.DrawLine(position, 3*position+netPotential, Color.blue, 0.0f);
    //         }
    //     }
        
    //     //Selection Toggle
    //     //selectionCircle.SetActive(isSelected);
    //     desiredSpeed=Mathf.Clamp(desiredSpeed,minSpeed,maxSpeed);
    //     //Acceleration Control
    //     if(Utils.ApproxEqual(speed,desiredSpeed, EntityMgr.inst.gameSpeed))
    //     {;}
    //     else if(speed < desiredSpeed)
    //     {
    //         speed+= acceleration * Time.deltaTime * EntityMgr.inst.gameSpeed;
    //     }
    //     else if(speed > desiredSpeed)
    //     {
    //         speed-= acceleration * Time.deltaTime * EntityMgr.inst.gameSpeed;
    //     }

    //     //Turn Control
    //     if(Utils.ApproxEqual(heading,desiredHeading, EntityMgr.inst.gameSpeed))
    //     {;}
    //     else if(Utils.AngleDifrenceNegatives(heading,desiredHeading) > 0)
    //     {
    //         heading+= turnRate * Time.deltaTime * EntityMgr.inst.gameSpeed;
    //     }
    //     else if(Utils.AngleDifrenceNegatives(heading,desiredHeading) < 0)
    //     {
    //         heading-= turnRate * Time.deltaTime * EntityMgr.inst.gameSpeed;
    //     }

    //     heading = Utils.ConvertTo360(heading);
    //     //Velocity Math
    //     speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
    //     velocity.x = Mathf.Sin(heading * Mathf.Deg2Rad) * speed * EntityMgr.inst.gameSpeed;
    //     velocity.z = Mathf.Cos(heading * Mathf.Deg2Rad) * speed * EntityMgr.inst.gameSpeed;
        
    //     position+=velocity * Time.deltaTime;
    //     transform.localPosition=position;

    //     //Turn math
    //     eulerRotation.y= heading;
    //     transform.localEulerAngles=eulerRotation;
    // }

    // public void FindPath()
    // {
    //     Vector3 nextMove = ZoneMgr.inst.FindNextMover(position,myDirection);
    //     if(nextMove==Vector3.zero && (myDirection == direction.West || myDirection == direction.East))
    //     {
    //         Destroy(gameObject);
    //         ZoneMgr.inst.SummonShip();
    //         EntityMgr.inst.boatEntities.Remove(this);
    //         if(isSelected)
    //         {
    //             SelectionMgr.inst.selectedBoats.Remove(this);
    //         }
    //     }
    //     else
    //         FindPath(nextMove);
    // }

    // public void FindPath(Vector3 nextMove)
    // {
    //     while(nextMove!=Vector3.zero)
    //     {
    //         Move(nextMove);
    //         nextMove = ZoneMgr.inst.FindNextMover(nextMove,myDirection);
    //     }
    //     if(myDirection==direction.AcrossN || myDirection==direction.AcrossS)
    //     {
    //         if(Random.Range(0,2)==1)
    //             myDirection=direction.East;
    //         else
    //             myDirection=direction.West;
    //         if(pathList.Count>0)
    //             FindPath(pathList[pathList.Count-1]);
    //     }
    //     else
    //         Move(ZoneMgr.inst.GetEnd(myDirection));
    // }

    // public void Move(Vector3 newTarget)
    // {
    //     moveState=2;
    //     pathList.Add(newTarget);
    // }
    // public bool nextMove()
    // {
    //     evasionMode=false;
    //     if(pathList.Count==0)
    //         return false;
    //     pathList.RemoveAt(0);
    //     if(pathList.Count==0)
    //         Stop();
    //     return true;
    // }

    // public void firstMove(Vector3 newTarget)
    // {
    //     moveState=2;
    //     pathList.Insert(0,newTarget);
    // }

    // bool isCBDR(BoatEntity otherShip)
    // {
    //     //Constant Bearing
    //     if(!Utils.ApproxEqual(otherShip.heading,otherShip.desiredHeading))
    //         return false;
    //     //Decreasing Range
    //     float curRange=(position-otherShip.position).magnitude;
    //     float nextRange=(position+(velocity*Time.deltaTime)-(otherShip.position+(otherShip.velocity*Time.deltaTime))).magnitude;
    //     if(!(nextRange<curRange))
    //         return false;

    //     return true;
        
    // }
    // void BoatRulesAvoidCrash(BoatEntity otherShip)
    // {
    //     if(!evasionMode)
    //     {
    //         Vector3 deltaPos = otherShip.position - position;
    //         float deltaAngle = Vector3.Angle(transform.forward, deltaPos);
    //         if(deltaAngle>120)
    //         {
    //             desiredSpeed = speed;
    //             desiredHeading = heading;
    //         }
    //         else if (Vector3.Angle(transform.right, deltaPos)>deltaAngle&&deltaAngle>15)
    //         {
    //             Vector3 otherSternPos = otherShip.position + (otherShip.transform.forward * -1 * otherShip.mass);
    //             evasionMode = true;
    //             firstMove(otherSternPos);   
    //         }
    //         else
    //         {
    //             desiredSpeed = speed;
    //             desiredHeading = heading;
    //         }
    //     }
    //     //float deltaHeadings = otherShip.heading - heading;
        
    // }

    // public void Stop()
    // {
    //     moveState=1;
    //     pathList.Clear();
    //     desiredSpeed=0;
    //     playerMove=false;
    // }

    // private void OnGUI() 
    // {
    //     if(isSelected && pathList.Count>0)
    //     {
    //         RenderPath();
    //     }
    //     else
    //     {
    //         line.positionCount = 1;
    //     }
    // }

    // void RenderPath()
    // {
    //     line.SetPosition(0, new Vector3(transform.position.x, 10, transform.position.z));
    //     line.positionCount = pathList.Count+1;
    //     float newWidth = CameraControlls.inst.YawNode.transform.position.y/180;
    //     line.startWidth = newWidth;
    //     line.endWidth = newWidth;
    //     for(int i = 1; i < pathList.Count+1; i++)
    //     {
    //         line.SetPosition(i, new Vector3(pathList[i-1].x, 10, pathList[i-1].z));
    //     }
    // }
}
