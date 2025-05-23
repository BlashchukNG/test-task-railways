using UnityEditor;

namespace Editor
{
	public class SpriteDefaultSettings : AssetPostprocessor
	{
		void OnPreprocessTexture()
		{
			if (assetPath.StartsWith("Assets/_Project/Content"))
			{
				TextureImporter textureImporter = (TextureImporter)assetImporter;
				textureImporter.spritePixelsPerUnit = 100;
				textureImporter.spriteImportMode = SpriteImportMode.Single;
			}
		}
	}
}