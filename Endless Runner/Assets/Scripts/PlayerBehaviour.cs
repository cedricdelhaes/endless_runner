using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{

    private bool spiritAngel;
    public Slider spiritSlider;
    public float spiritIncrement;

    public bool invincible;


    [SerializeField]
    private int _life;
    public int life{
        get{
            return _life;
        }
        set{
            _life = value;
        }
    }

    private void Start() {
        spiritAngel = true;
        spiritSlider.value = 0;
    }  

    private void Update(){

        CheckSpiritValue();
        if (spiritAngel)
            spiritSlider.value += spiritIncrement;
        else
            spiritSlider.value -= spiritIncrement;
    }


    //Lose life when triger ennemy
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy")){
            Destroy(other.gameObject);
            if(!invincible)
                life--;
        }
    }

    //If spiritValue get max value or min value lose life get back to zero
    private void CheckSpiritValue()
    {
        if (spiritSlider.value == spiritSlider.maxValue || spiritSlider.value == spiritSlider.minValue)
        {
            if(!invincible)
                life--;
            spiritSlider.value = 0;
        }
    }

    public void SwitchSpirit(){
        spiritAngel = !spiritAngel;
    }

}
