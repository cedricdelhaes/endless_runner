using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{

    /*Spirit slider*/
    private bool _spiritAngel;
    public Slider spiritSlider;
    public Image spiritFill;
    public float spiritIncrement;
    public int spiritMaxValue;
    public int spiritMinValue;
    public Gradient spiritGradiant;
    private float _sliderIncrementWidth;

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

        /*Init spirit bar data*/
        _spiritAngel = true;
        spiritSlider.minValue = spiritMinValue;
        spiritSlider.maxValue = spiritMaxValue;
        spiritSlider.value = (spiritMaxValue-Mathf.Abs(spiritMinValue))/2;

        spiritFill.color = spiritGradiant.Evaluate(spiritSlider.normalizedValue);

        _sliderIncrementWidth = spiritSlider.GetComponent<RectTransform>().rect.width / (spiritMaxValue - spiritMinValue);

    }

    private void spiritAutoUpdateValue()
    {
        if (_spiritAngel)
            spiritSlider.value += spiritIncrement * Time.deltaTime;

        else
            spiritSlider.value -= spiritIncrement * Time.deltaTime;
    }

    private void Update(){

        CheckSpiritValue();
        InvokeRepeating("spiritAutoUpdateValue", 0.5f, 10f);

        //Put correct color from gradiant color according to slider value
        spiritFill.color = spiritGradiant.Evaluate(spiritSlider.normalizedValue);

        /*Change slider behaviour to center the slider starting point*/
        spiritSlider.fillRect.rotation = new Quaternion(0, 0, 0, 0);
        spiritSlider.fillRect.pivot = new Vector2(spiritSlider.fillRect.localPosition.x, spiritSlider.fillRect.pivot.y);
        if (spiritSlider.value > 0)
             spiritSlider.fillRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _sliderIncrementWidth * spiritSlider.value);
        else
        {
            spiritSlider.fillRect.Rotate(0, 0, 180);
            spiritSlider.fillRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _sliderIncrementWidth * -spiritSlider.value);

        }
        spiritSlider.fillRect.localPosition = new Vector3(0, 0, 0);
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
        if (spiritSlider.value >= spiritSlider.maxValue || spiritSlider.value <= spiritSlider.minValue)
        {
            if(!invincible)
                life--;
            spiritSlider.value = (spiritMaxValue-Mathf.Abs(spiritMinValue))/2;
        }
    }

    public void SwitchSpirit(){
        _spiritAngel = !_spiritAngel;
    }

}
