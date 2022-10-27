using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PianoKey : MonoBehaviour
{
	public Text text1;
	public Text text2;
	public Text text3;

	private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if( Input.GetMouseButtonDown( 0 ) )
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
			if( Physics.Raycast( ray, out hit ) )
			{
				Debug.Log( hit.transform.name );
				UpdateUI( GetKey( hit.transform.name ) );
			}
		}
    }

	private string GetKey( string name )
	{
		// map mesh name to key name
		switch( name )
		{
			case "M_White_15_Key":
				return "C";
			case "M_White_16_Key":
				return "D";
			case "M_White_17_Key":
				return "E";
		}
		
		return "";
	}

	private void UpdateUI( string key )
	{
		Debug.Log( count );
		// reset dialogue if hit 3 keys
		if( count >= 3 )
		{
			count = 0;
			text1.text = "";
			text2.text = "";
			text3.text = "";
		}

		// if no key pressed, do nothing
		if( key == "" )
			return;

		// put key name in correct place according the key pressed
		if( count == 0 )
		{
			text1.text = key;
			count++;
		}
		else if( count == 1 && key != text1.text )
		{
			text2.text = key;
			count++;
		}
		else if( count == 2 && key != text1.text && key != text2.text )
		{
			text3.text = key;
			count++;
		}
		
		return;
	}
}
