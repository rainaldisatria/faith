﻿

using System;
using UnityEngine;

public class PublisherReadme : ScriptableObject 
{
	public Texture2D icon;
	public string title;
	public Section[] sections;
	
	[Serializable]
	public class Section 
	{
		public string heading, text, linkText, url;
	}
}
