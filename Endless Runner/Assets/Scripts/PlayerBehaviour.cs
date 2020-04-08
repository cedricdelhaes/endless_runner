using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{

    private bool spiritAngel;
    public Slider spiritSlider;
    public float spiritIncrement;

    public float colorFactor;
    public float r, v, b;
    public Color playerColor;

    private Renderer rendererPlayer;


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

        playerColor = new Color(0,0,0,125);
        rendererPlayer = gameObject.GetComponent<Renderer>();
    }  

    private void Update(){

        CheckSpiritValue();
        if (spiritAngel)
            spiritSlider.value += spiritIncrement;
        else
            spiritSlider.value -= spiritIncrement;

        //RGB value according spiritSlider value (/255 new Color() take 1) RED Demon => White Angel
        r = Mathf.Abs(spiritSlider.value*colorFactor) * 2.55f/255;
        v = spiritSlider.value < 0 ? 0 : spiritSlider.value * colorFactor * 2.55f/255;
        b = spiritSlider.value < 0 ? 0 : spiritSlider.value * colorFactor * 2.55f/255;
        playerColor.r = r;
        playerColor.g = v;
        playerColor.b = b;
        playerColor.a = 125;

        //playerColor = new Color(r, v, b, 125);

        rendererPlayer.material.color = new Color(r,v,b, 125);
    }


    //Lose life when triger ennemy
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy")){
            Destroy(other.gameObject);
            life--;
        }
    }

    //If spiritValue get max value or min value lose life get back to zero
    private void CheckSpiritValue()
    {
        if (spiritSlider.value == spiritSlider.maxValue || spiritSlider.value == spiritSlider.minValue)
        {
            life--;
            spiritSlider.value = 0;
        }
    }

    public void SwitchSpirit(){
        spiritAngel = !spiritAngel;
    }

}
