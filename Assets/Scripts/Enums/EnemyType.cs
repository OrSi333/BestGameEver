﻿using UnityEngine;
using System.Collections;

/**
 * Stupid - Can't attack, can be killed easely.
 * Spike - Can't attack, but has spikes that occasionaly apeare and hurt the player on touch.
 * Pion - Simple attacker
 * Ninja - Strong and quick attacks
 * Tank - Weak attacker, but need a few hits to be killed
 * 
 */
public enum EnemyType { 
    Stupid = 1,
	Spike,
	Pion
	//TBD: Ninja,Tank, Boss
}
