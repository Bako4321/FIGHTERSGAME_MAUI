using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public GameObject shieldVisual; // assign in Inspector

    private bool shieldActive = false;
    private float shieldTimer;

    void Update()
    {
        if (shieldActive)
        {
            shieldTimer -= Time.deltaTime;

            if (shieldTimer <= 0)
            {
                DeactivateShield();
            }
        }
    }

    public void ActivateShield(float duration)
    {
        shieldActive = true;
        shieldTimer = duration;

        if (shieldVisual != null)
        {
            shieldVisual.SetActive(true);
        }
    }

    void DeactivateShield()
    {
        shieldActive = false;

        if (shieldVisual != null)
        {
            shieldVisual.SetActive(false);
        }
    }

    public bool IsShieldActive()
    {
        return shieldActive;
    }
}