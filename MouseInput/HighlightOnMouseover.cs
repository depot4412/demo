using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Object with this script will have all of its material's shaders replaced with a standout shader while mouseover'd.
/// </summary>

[RequireComponent(typeof(Renderer))]
public class HighlightOnMouseover : MonoBehaviour {

	Renderer rendererWithMaterialsToAdjust;

	void Start () {
		rendererWithMaterialsToAdjust = GetComponent<Renderer>();
	}

	void Update () {
		
	}


	void OnMouseEnter()
	{
		Shader s = Shader.Find("highlighted");
		Material[] myMaterials;
		myMaterials = rendererWithMaterialsToAdjust.materials;
		int i = 0;
		while(i < rendererWithMaterialsToAdjust.materials.Length)
		{
			myMaterials[i].shader = s;
			i++;
		}

		rendererWithMaterialsToAdjust.materials = myMaterials;


	}
	void OnMouseExit()
	{
		Shader s = Shader.Find("Diffuse");
		Material[] myMaterials;
		myMaterials = rendererWithMaterialsToAdjust.materials;
		int i = 0;
		while(i < rendererWithMaterialsToAdjust.materials.Length)
		{
			myMaterials[i].shader = s;
			i++;
		}

		rendererWithMaterialsToAdjust.materials = myMaterials;
	}
}
