﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class TimedAction : MonoBehaviour {
	public GameObject subject;
	public GameObject collidedWith;
	public float fixedTimeStart;
	public float durationTime;
	public Vector2 impactForc;
	public Action<SuperHitModel> stopingFunc;
	public Func<MoveAfterCollisionModel,MoveAfterCollisionModel> whileGoingDo;
	public bool isRunning;
	private MoveAfterCollisionModel moveAfterCollisionModel;
	void FixedUpdate(){
		if (isRunning) {
			if(Time.fixedTime - fixedTimeStart < durationTime) {
                //if(whileGoingDo != null){
                //    moveAfterCollisionModel = moveAfterCollisionModel ?? new MoveAfterCollisionModel{subject = this.subject,impactForce = this.impactForc};
                //    moveAfterCollisionModel = whileGoingDo(moveAfterCollisionModel);
				
			} else {
                stopingFunc.Invoke(new SuperHitModel {character = subject, 
                enemy = collidedWith});
				Destroy(this);
			}
		}
	}

	public void doByTime(TimeActionModel model){
		impactForc = model.impactForce;
		this.subject = model.subject;
		this.fixedTimeStart = model.fixedTimeStart;
		this.durationTime = model.durationTime;
		stopingFunc = model.stopingFunc;
		whileGoingDo = model.whileGoingDo;
		collidedWith = model.collidedWith;
		isRunning = true;
	}
}
