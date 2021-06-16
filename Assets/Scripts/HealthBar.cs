using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

	public Slider slider;
	public Gradient gradient;
	public Image fill;
	

	public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;

		fill.color = gradient.Evaluate(1f);
	}

	public void SetHealth(int health)
	{
		slider.value = health;
		ChangeColor(slider.value);
	}

	public void Damage(int k)
    {
		slider.value -= k;
    }

	public void ChangeColor(float sliderValue)
    {
		if(sliderValue<75 && sliderValue >= 50)
        {
			fill.color = gradient.Evaluate(0.8f);
        }
		else if (sliderValue < 50 && sliderValue >= 25)
		{
			fill.color = gradient.Evaluate(0.5f);
		}
		else if (sliderValue < 25 && sliderValue >=0)
		{
			fill.color = gradient.Evaluate(0.2f);
		}
	}

}
