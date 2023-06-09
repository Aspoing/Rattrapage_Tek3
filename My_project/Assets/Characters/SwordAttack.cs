using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    public Collider2D swordCollider;
    public float damage = 3;
    public float knockbackForce = 50f;
    Vector2 rightAttackOffset;

    // Start is called before the first frame update
    private void Start() {
        rightAttackOffset = transform.localPosition;
    }

    public void AttackRight() {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }
    
    public void AttackLeft() {
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(-rightAttackOffset.x, rightAttackOffset.y);
    }
    
    public void StopAttack() {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {

        IDamageable damageableObject = other.GetComponent<IDamageable>();

        if (damageableObject != null && other.gameObject.tag == "Enemy") {
            Vector3 parentPosition = transform.parent.position;

            Vector2 direction = (Vector2) (other.transform.position - parentPosition).normalized;
            Vector2 knockback = direction * knockbackForce;

            damageableObject.OnHit(damage, knockback);
        }
    }
}
