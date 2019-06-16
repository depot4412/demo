#define EDITOR_DEBUG
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;


/// <summary>
/// Wrapper to make the logging compilation dependent on preproccor idenitfier.
/// </summary>
public class EditorDebug {


	[Conditional("EDITOR_DEBUG")]
	public static void Log(string message)
	{
		UnityEngine.Debug.Log(message);
	}
}
