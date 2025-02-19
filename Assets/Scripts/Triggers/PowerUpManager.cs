using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour{
    public static PowerUpManager instance;

    private void Awake() {
        if (instance == null) instance = this;
    }

    public void ComenzarPowerUp(Animator[] enemigosAnimator, float duracion) {
        foreach (Animator anim in enemigosAnimator){
            if (anim.gameObject.CompareTag("Enemy")){
                StartCoroutine(ResetPowerUp(anim,duracion));
            }
        }
    }

    private IEnumerator ResetPowerUp(Animator enemigoAnimator, float duracion){
        enemigoAnimator.SetTrigger("ComienzoPowerUp");
        Debug.Log("PowerUp comenzado");
        yield return new WaitForSeconds(duracion);
        if (enemigoAnimator != null && enemigoAnimator.gameObject != null) {
            enemigoAnimator.SetTrigger("FinPowerUp");
            Debug.Log("PowerUp terminado");
        } else {
            Debug.LogWarning("El enemigo fue destruido junto a su animator. Saltando fin del powwerUp.");
        }
    }
}
