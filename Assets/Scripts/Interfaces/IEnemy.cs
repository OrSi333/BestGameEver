﻿using UnityEngine;
using System.Collections;

public interface IEnemy {

	public float timeToFinishPath;
	public float minTimeForPath;
	public float maxTimeForPath;
	EnemyMode _mode;

	void Death();

	Vector2 MoveToPoint(Vector2 i_point);

	Vector2 FindPlayerLocation();

	void SetStats(AEnemyStats i_stats);

	void MoveInDirection(Vector2 i_direction);

	void Split(Vector2 i_location);


    void setPath(Vector3[] path,int speed);
}
