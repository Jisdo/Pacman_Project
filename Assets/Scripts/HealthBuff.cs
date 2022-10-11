using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HealthBuff : MonoBehaviour
{
    public int points = 1;

    protected virtual void Eat()
    {
        FindObjectOfType<GameManager>().HealthBuffEaten(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman")) {
            Eat();
        }
    }

}
