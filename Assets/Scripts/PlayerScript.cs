using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class PlayerScript : Agent {

  public GameObject target;
  public float moveSpeed;

  private Rigidbody rigidBody;

  void Start () {
    rigidBody = gameObject.GetComponent<Rigidbody>();
  }

  public override void OnEpisodeBegin() {
    float playerX = Random.Range(-4.4f, 4.4f);
    float playerZ = Random.Range(-4.4f, 4.4f);
    
    gameObject.transform.rotation = Quaternion.identity;
    gameObject.transform.localPosition = new Vector3(playerX, 1, playerZ);
  
    float targetX = Random.Range(-4.4f, 4.4f);
    float targetZ = Random.Range(-4.4f, 4.4f);
  
    while (playerX - 1.1 > targetX && targetX < playerX + 1.1 &&
    playerZ - 1.1 > targetZ && targetZ < playerZ + 1.1) {
      targetX = Random.Range(-4.4f, 4.4f);
      targetZ = Random.Range(-4.4f, 4.4f);
    }

    target.transform.rotation = Quaternion.identity;
    target.transform.localPosition = new Vector3(targetX, 1, targetZ);
  }

  public override void CollectObservations(VectorSensor sensor) {
    sensor.AddObservation(gameObject.transform.localPosition);
    sensor.AddObservation(target.transform.localPosition);
  }

  public override void Heuristic(in ActionBuffers actionsOut) {
    var continuousActionsOut = actionsOut.ContinuousActions;

    continuousActionsOut[0] = Input.GetAxis("Horizontal");
    continuousActionsOut[1] = Input.GetAxis("Vertical");
  }
  
  public override void OnActionReceived(ActionBuffers actionBuffers) {
    float moveX = actionBuffers.ContinuousActions[0];
    float moveZ = actionBuffers.ContinuousActions[1];

    gameObject.transform.position += new Vector3(moveX, 0, moveZ) * Time.deltaTime * moveSpeed;
  }

  void OnCollisionEnter(Collision col){
    if(col.gameObject.name == "Target") {
      SetReward(1.0f);
      EndEpisode();
    } else if(col.gameObject.name == "Wall") {
      SetReward(-1.0f);
      EndEpisode();
    }
  }
}
