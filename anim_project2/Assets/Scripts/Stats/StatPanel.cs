﻿using UnityEngine;

public class StatPanel : MonoBehaviour 
{
	[SerializeField] StatDisplay[] statDisplays;
	[SerializeField] string[] statNames;
	
	private CharacterStat[] stats;
	
	private void OnValidate ()
	{
		statDisplays = GetComponentsInChildren<StatDisplay>();
		UpdateStatNames ();
	}
	
	public void SetStats(params CharacterStat[] charStats)
	{
		stats = charStats;
	}
	
	/*public void UpdateStatValues ()
	{
		for (int i = 0; i < stats.Length; i++)
		{
			statDisplays[i].ValueText.text = stats[i].Value.ToString();
		}
	}*/
	
	public void UpdateStatNames ()
	{
		for (int i = 0; i < statNames.Length; i++)
		{
			statDisplays[i].NameText.text = statNames[i];
		}
	}
}
