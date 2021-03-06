﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
	[System.Serializable]
	public class Wave
	{
	
		public GameObject enemy;
		public int count;
		public int bursts;
		public float speedIncrease = 0.5f;
	}
	public static int EnemiesAlive = 0;

	public Wave[] waves;
	
	public Transform spawnPoint;

	public float timeBetweenWaves = 5f;
	public float timeBetweenBursts = 3f;
	public float timeBetweenEnemies = 1f;
	private float countdown = 3.0f;

	public Text waveCountdownText;

	private int waveIndex = 0;

	private float speed = 0;

	void Update()
	{
		if (EnemiesAlive > 0)
		{
			return;
		}
	
		if (waveIndex == waves.Length)
		{
			UnityEngine.Debug.Log("You Win! ");
			GameHandler.WinLevel();
			this.enabled = false;
		}
	
		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			return;
		}
	
		countdown -= Time.deltaTime;
	
		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
	
		waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}
	
	IEnumerator SpawnWave()
	{
		PlayerStats.Rounds++;

		Wave wave = waves[waveIndex];

		speed += waves[waveIndex].speedIncrease;
		EnemiesAlive = wave.count;
	
		for (int i = 0; i < wave.count; i++)
		{
			SpawnEnemy(wave.enemy);
			if ((i + 1) % wave.bursts == 0)
				yield return new WaitForSeconds(timeBetweenBursts);
			yield return new WaitForSeconds(timeBetweenEnemies);
		}
		waveIndex++;
	}
	
	void SpawnEnemy(GameObject enemy)
	{
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation).GetComponent<Character>().speed += speed;
	}
}