using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRhythmScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject reflectableProjectilePrefab;
    public GameObject PlayerObject;

    private float timer = 0.0f;
    private Song song;
    private int firingPointIndex = 0;
    private bool ship = false;

	private void Start()
	{
        // inverted alps is *almost* exactly 159.5 bpm
        // i see why Osu! uses start times instead, it isn't prone to desync
        // the issue is finding those start times...
        song = new Song(160, PlayerObject.transform.localPosition.x, transform.localPosition.x);

        float beat = 0.0f;
        float twoMeasureOffset = 0.0f;
        for(int i = 0; i < 10; i++)
        {
            twoMeasureOffset = 8.0f;
            song.AddFiringPoint(beat + 1.0f, twoMeasureOffset, true); // this way you can explicitly set which beat the projectile is shot on
            song.AddFiringPoint(beat + 1.5f, twoMeasureOffset, false);
            song.AddFiringPoint(beat + 2.0f, twoMeasureOffset, false);
            song.AddFiringPoint(beat + 2.5f, twoMeasureOffset, false);
            song.AddFiringPoint(beat + 3.0f, twoMeasureOffset, false);
            song.AddFiringPoint(beat + 3.5f, twoMeasureOffset, false);
            song.AddFiringPoint(beat + 4.0f, twoMeasureOffset, false);
            song.AddFiringPoint(beat + 4.5f, twoMeasureOffset, false);

            song.AddFiringPoint(beat + 5.0f, twoMeasureOffset, true);
            song.AddFiringPoint(beat + 5.5f, twoMeasureOffset, false);
            song.AddFiringPoint(beat + 6.0f, twoMeasureOffset, false);
            song.AddFiringPoint(beat + 6.5f, twoMeasureOffset, false);
            song.AddFiringPoint(beat + 7.0f, twoMeasureOffset, false);
            song.AddFiringPoint(beat + 7.5f, twoMeasureOffset, false);
            song.AddFiringPoint(beat + 8.0f, twoMeasureOffset, false);
            song.AddFiringPoint(beat + 8.5f, twoMeasureOffset, false);

            beat += 16.0f;
		}
	}

	private void Update()
	{
        timer += Time.deltaTime;

        if (firingPointIndex < song.firingPoints.Count && timer >= song.firingPoints[firingPointIndex].startTime)
		{
            GameObject projectileToSpawn;
            if (song.firingPoints[firingPointIndex].isReflectable)
                projectileToSpawn = reflectableProjectilePrefab;
			else
                projectileToSpawn = projectilePrefab;

            projectileToSpawn.GetComponent<Entity381>().velocity.x = song.firingPoints[firingPointIndex].velocity;
            if (ship)
            {
                Instantiate(projectileToSpawn, transform.localPosition, Quaternion.identity);
            }
            else
			{
                Vector3 t = transform.localPosition;
                t.y += 3;
                Instantiate(projectileToSpawn, t, Quaternion.identity);

            }

            firingPointIndex++;
            ship = !ship;
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

    public void AddFiringPoint(float fireBeat, float playerBeatOffset, bool isReflectable)
    {
        float playerBeat = fireBeat + playerBeatOffset;
        fireBeat -= 1.0f; // convert to 0 index
        playerBeat -= 1.0f;
        float diff = playerBeat - fireBeat;
        float firingTime = fireBeat * beatLength;
        float projectileSpeed = playerEnemyDistance / (diff * beatLength);
        firingPoints.Add(new FiringPoint(firingTime, -projectileSpeed, isReflectable));
    }
}

public struct FiringPoint
{
    public float startTime;
    public float velocity;
    public bool isReflectable;

    public FiringPoint(float startTime, float velocity, bool isReflectable)
	{
        this.startTime = startTime;
        this.velocity = velocity;
        this.isReflectable = isReflectable;
	}
}