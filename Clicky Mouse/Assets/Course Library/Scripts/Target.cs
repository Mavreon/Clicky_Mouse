using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    private float spawnXPos = 3.0f;
    private float spawnYPos = -6;
    private float maxForce = 14;
    private float minForce = 18;
    private float maxTorque = 12;
    private float minTorque = 16;
    public int scoreValue;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        RandomSpawnPos();
        RandomForce();
        RandomTorque();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
            gameManager.UpdateScore(scoreValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);
            if (gameObject.CompareTag("Bad"))
            {
                gameManager.GameOver();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    private void RandomSpawnPos()
    {
        transform.position = new Vector3(Random.Range(-spawnXPos, spawnXPos), spawnYPos);
    }
    private void RandomForce()
    {
        targetRB.AddForce(Vector3.up * Random.Range(minForce, maxForce), ForceMode.Impulse);
    }
    private void RandomTorque()
    {
        targetRB.AddTorque(Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), ForceMode.Impulse);
    }
}
