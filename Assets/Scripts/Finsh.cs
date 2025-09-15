using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] ParticleSystem finishEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (finishEffect != null)
            {
                finishEffect.Play();
            }

            Mover mover = other.GetComponent<Mover>();
            if (mover != null)
            {
                Debug.Log("You reached the finish line!");
                Debug.Log("Total obstacles hit: " + mover.hitCount);
            }
        }
    }
}