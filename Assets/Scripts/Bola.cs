using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour {

    public Vector3 direction;
    public float velocity;
    public GameObject blockParticle;
    public ParticleSystem leavesParticle;

	// Use this for initialization
	void Start () {
        direction.Normalize();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += direction * velocity * Time.deltaTime;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool invalidCollision = false;
        Vector2 normal = collision.contacts[0].normal;
        Plataforma plataform = collision.transform.GetComponent<Plataforma>();
        GeradorDeArestas geradorDeArestas = collision.transform.GetComponent<GeradorDeArestas>();
        if (plataform != null) // se existir o componente plataforma no game object com o qual a bolinha colidiu...
        { 
            if (normal != Vector2.up)
            {
                invalidCollision = true;
            }
            else
            {
                leavesParticle.transform.position = plataform.transform.position;
                leavesParticle.Play();
                
            }
        }

        else if (geradorDeArestas != null)
        {
            if (normal == Vector2.up)
            {
                invalidCollision = true;
            }
        }

    
        else // Caso caia aqui no else, estamos colidindo com um bloco, pois é o que sobra
        {
            invalidCollision = false;
            Bounds colliderBorder = collision.transform.GetComponent<SpriteRenderer>().bounds;
            Vector3 creationPosition = new Vector3(collision.transform.position.x + colliderBorder.extents.x, collision.transform.position.y - colliderBorder.extents.y, collision.transform.position.z);
            GameObject particle = (GameObject) Instantiate(blockParticle, creationPosition, Quaternion.identity);
            ParticleSystem particleComponent = particle.GetComponent<ParticleSystem>();
            Destroy(particle, particleComponent.main.duration);
            Destroy(collision.gameObject);
            GerenciadorDoGame.destroyedNumberOfBlocks++;
        }
        if (!invalidCollision)
        {
            direction = Vector2.Reflect(direction, normal);
            direction.Normalize();
        }
        else
        {
            GerenciadorDoGame.instancia.finishGame();
        }
    }
}
