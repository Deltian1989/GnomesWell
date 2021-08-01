using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BodyPart : MonoBehaviour
{
    public Sprite detachedSprite;

    public Sprite burntSprite;

    public Transform bloodFountainOrigin;

    bool detached = false;

    public void Detach()
    {
        detached = true;

        this.tag = "Untagged";

        transform.SetParent(null, true);
    }

    void Update()
    {
        if (detached == false)
            return;

        var rigidbody = GetComponent<Rigidbody2D>();

        if (rigidbody.IsSleeping())
        {
            foreach (var joint in GetComponentsInChildren<Joint2D>())
            {
                Destroy(joint);
            }

            foreach (var rb in GetComponentsInChildren<Rigidbody2D>())
            {
                Destroy(rb);
            }

            foreach (var collider in GetComponentsInChildren<Collider2D>())
            {
                Destroy(collider);
            }

            Destroy(this);
        }
    }

    public void ApplyDamageSprite(Gnome.DamageType damageType)
    {
        Sprite spriteToUse = null;

        switch (damageType)
        {
            case Gnome.DamageType.Burning:
                spriteToUse = burntSprite;
                break;
            case Gnome.DamageType.Slicing:
                spriteToUse = detachedSprite;
                break;
        }

        if (spriteToUse != null)
        {
            GetComponent<SpriteRenderer>().sprite = spriteToUse;
        }
    }
}
