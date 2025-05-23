using UnityEngine;

namespace Utils
{
	public sealed class GPUInstancingEnabler : MonoBehaviour
	{
		private void Awake()
		{
			GetComponent<Renderer>().SetPropertyBlock(new MaterialPropertyBlock());
		}
	}
}