using System.Collections;
using UnityEngine;

// Food object
public class Food : MonoBehaviour
{
    public int points = 10;
    public int lifetime = 30;
    public int growthAmount = 1;
    private readonly string snakeTag = "Snake";
    private void OnEnable()
    {
        SpawnAtRandomLocation();
        StartCoroutine(DisableAfterLifetime());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator DisableAfterLifetime()
    {
        yield return new WaitForSeconds(lifetime);
        gameObject.SetActive(false);
    }

    public void SpawnAtRandomLocation()
    {
        float randomx, randomy, randomz;
        randomx = Random.Range(-10.0f, 10.0f);
        randomy = Random.Range(-10.0f, 10.0f);
        randomz = Random.Range(0.5f, 10.0f);
        transform.position = new Vector3(randomx, randomz, randomy);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(snakeTag))
        {
            gameObject.SetActive(false);
            GameManager.instance.AddPoints(points);
            SendGrowth();
        }
    }

    void SendGrowth()
    {
        GameManager.instance.AddBodyParts(growthAmount);
    }
}