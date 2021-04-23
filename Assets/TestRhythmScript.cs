using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRhythmScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject PlayerObject;

    private float timer = 0.0f;
    private Song song;
    private int firingPointIndex = 0;

	private void Start()
	{
        song = new Song(120, PlayerObject.transform.localPosition.x, transform.localPosition.x);

        float beat = 0.0f;
        float twoMeasureOffset = 0.0f;
        for(int i = 0; i < 10; i++)
        {
            twoMeasureOffset = beat + 9.0f;
            song.AddFiringPoint(beat + 1.0f, twoMeasureOffset + 1.0f); // this way you can explicitly set which beat the projectile is shot on
            song.AddFiringPoint(beat + 2.0f, twoMeasureOffset + 2.0f);
            song.AddFiringPoint(beat + 3.0f, twoMeasureOffset + 3.0f);
            song.AddFiringPoint(beat + 3.5f, twoMeasureOffset + 3.5f);
            song.AddFiringPoint(beat + 4.0f, twoMeasureOffset + 4.0f);

            song.AddFiringPoint(beat + 5.0f, twoMeasureOffset + 5.0f);
            song.AddFiringPoint(beat + 5.5f, twoMeasureOffset + 5.5f);
            song.AddFiringPoint(beat + 6.0f, twoMeasureOffset + 6.0f);
            song.AddFiringPoint(beat + 6.5f, twoMeasureOffset + 6.5f);
            song.AddFiringPoint(beat + 7.0f, twoMeasureOffset + 7.0f);
            song.AddFiringPoint(beat + 7.5f, twoMeasureOffset + 7.5f);
            song.AddFiringPoint(beat + 8.0f, twoMeasureOffset + 8.0f);
            song.AddFiringPoint(beat + 8.5f, twoMeasureOffset + 8.5f);

            beat += 16.0f;
		}
	}

	private void Update()
	{
        timer += Time.deltaTime;

        if (firingPointIndex < song.firingPoints.Count && timer >= song.firingPoints[firingPointIndex].starttime)
		{
            projectilePrefab.GetComponent<Entity381>().velocity.x = song.firingPoints[firingPointIndex].velocity;
            Instantiate(projectilePrefab, transform.localPosition, Quaternion.identity);
            firingPointIndex++;
        }
	}
}

public class Song
{
    public int bpm;
    public List<FiringPoint> firingPoints;

    private float beatLength;
    private float playerEnemyDistance;

    public Song(int bpm, float playerPosition, float enemyPosition)
    {
        this.bpm = bpm;
        this.beatLength = 60.0f / this.bpm;
        this.playerEnemyDistance = enemyPosition - playerPosition; // WARNING: sign matters here

        firingPoints = new List<FiringPoint>();
    }

    public void AddFiringPoint(float fireBeat, float playerBeat)
    {
        fireBeat -= 1.0f; // convert to 0 index
        playerBeat -= 1.0f;
        float diff = playerBeat - fireBeat;
        float firingTime = fireBeat * beatLength;
        float projectileSpeed = playerEnemyDistance / (diff * beatLength);
        firingPoints.Add(new FiringPoint(firingTime, -projectileSpeed));
    }
}

public struct FiringPoint
{
    public float starttime;
    public float velocity;

    public FiringPoint(float starttime, float velocity)
	{
        this.starttime = starttime;
        this.velocity = velocity;
	}
}