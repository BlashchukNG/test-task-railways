using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Roots.GameplayScene.View
{
	public sealed class GameplayButton : MonoBehaviour
	{
		public TMP_Text Label => _text;
		public Button Button => _button;
		public Image Image => _image;

		[SerializeField] private Button _button;
		[SerializeField] private TMP_Text _text;
		[SerializeField] private Image _image;
	}
}