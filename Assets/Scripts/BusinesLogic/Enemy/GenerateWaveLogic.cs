﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
public class GenerateWaveLogic : MonoBehaviour {
	
	WaveLogicFactory _wave;
	EnemyGeneratorLogic enemyGenerator;
	private int waveNumber;
	public float numberOfSecBetweenEnemies = 0.5f;
	public Vector2 enemy1Loc;
	public Vector2 enemy2Loc;
	public Vector2 enemy3Loc;
    public Vector3[][] paths;
    public Vector2[] instantiateLocations;
	void Start () {
		 enemy1Loc = new Vector2(-10.5f, 14.9f);
		 enemy2Loc = new Vector2(10.5f, 14.9f);
		 enemy3Loc = new Vector2(0f, 14.9f);
        buildDictionaries();
		_wave = new WaveLogicFactory ();
		enemyGenerator = new EnemyGeneratorLogic ();
		waveNumber = 1;
	}
	// Use this for initialization
	public void generateWave(WaveGenerateModel i_model) {
		/** --omri's code
        if (!TypeOfEnemiesEachWave.ContainsKey(model.waveNumber))
        {
            return;
        }
        */
	    
		WaveLogic currentWave = _wave.createEasyWave ();
		StartCoroutine(GenerateEnemiesWithPause(currentWave));
		waveNumber++;
	}

     IEnumerator GenerateEnemiesWithPause(WaveLogic i_CurrentWave)
    {

		//EnemyType[] waveTypeArr = TypeOfEnemiesEachWave[model.waveNumber];
		//var typeMax = waveTypeArr.Length;
        var pathsMax = paths.Length;
		int waveLength = i_CurrentWave.getLength ();
		for (int i = 0; i < waveLength; i++)
        {
            //genereate enemies randomly 
			var enemyType = i_CurrentWave.GetNextEnemy();
            if (enemyType.Equals(EnemyType.End))
            {
               yield break;
            }
            var enemyLocation = new Vector2(0f, 40f); ;//instantiateLocations[UnityEngine.Random.Range(0, locationMax)];

            //instantiate enemeies in random location
            var path = paths[UnityEngine.Random.Range(0, pathsMax)];
            var enemy1 = Instantiate(enemyGenerator.getEnemy(enemyType), enemyLocation, Quaternion.identity) as GameObject;
            var enemyLogic = enemy1.GetComponent<IEnemy>();
            enemyLogic.StartRandomPath(5 * 10);
            
            //enemyLogic.StartRandomPath("EnemyPath" + UnityEngine.Random.Range(1, 3), model.waveNumber * 10);
			yield return new WaitForSeconds(numberOfSecBetweenEnemies);    //Wait 
        }
    } 


	public void buildDictionaries()
	{

        paths = new Vector3[][]
        {
           new Vector3[] {
               new Vector3(23.16821f,32.77761f,0f),
               new Vector3(16.53627f,23.94602f,0f),
               new Vector3(15.8f,-5.75f,0f),
               new Vector3(-30f,-10.11f,0f)
               //new Vector3(-19.64144f,-4.123909f,0f),
               //new Vector3(-7.596886f,-1.11f,0f),
               //new Vector3(-20.596886f,-1.11f,0f),
               //new Vector3(-34.6086f,0f,0f)
            },
            new Vector3[] {
               new Vector3(-10.59303f,32.91187f,0f),
               new Vector3(-8.758844f,14.06718f,0f),
               new Vector3(-11.58f,4.354736f,0f),
               new Vector3(40f,10.32509f,0f)
               //new Vector3(-8.758844f,14.06718f,0f),
               //new Vector3(-11.58f,4.354736f,0f),
               //new Vector3(14.8077f,10.32509f,0f),
               //new Vector3(-16.24f,10.62772f,0f)
            }
        };
        instantiateLocations = new Vector2[3] { enemy1Loc, enemy2Loc, enemy3Loc };
	}
}
